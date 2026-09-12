using System;
using System.Collections.Generic;
using System.Data;
using GP_1;
using Npgsql;

namespace MoneyMap.Budget.Services
{
    public class BudgetCategoryItem
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public decimal MonthlyLimit { get; set; }
        public decimal CurrentSpent { get; set; }
        public decimal Percentage => MonthlyLimit > 0 ? Math.Min(999, Math.Round((CurrentSpent / MonthlyLimit) * 100, 1)) : 0;
        public bool HasLimit => MonthlyLimit > 0;
        public bool IsExceeded => HasLimit && CurrentSpent >= MonthlyLimit;
        public bool IsWarning => HasLimit && !IsExceeded && Percentage >= 80;
    }

    public class BudgetSummary
    {
        public decimal TotalBalance { get; set; }
        public decimal ThisMonthIncome { get; set; }
        public decimal ThisMonthExpense { get; set; }
        public decimal OverallLimit { get; set; }
        public decimal OverallSpent { get; set; }
        public decimal OverallPercentage => OverallLimit > 0 ? Math.Min(999, Math.Round((OverallSpent / OverallLimit) * 100, 1)) : 0;
        public bool HasOverallLimit => OverallLimit > 0;
        public bool IsOverallExceeded => HasOverallLimit && OverallSpent >= OverallLimit;
        public bool IsOverallWarning => HasOverallLimit && !IsOverallExceeded && OverallPercentage >= 80;
        public List<string> Alerts { get; set; } = new List<string>();
        public List<BudgetCategoryItem> CategoryBudgets { get; set; } = new List<BudgetCategoryItem>();
    }

    public static class BudgetService
    {
        public static void EnsureTableExists()
        {
            string[] migrationSteps = new[]
            {
                @"CREATE TABLE IF NOT EXISTS t_budget (
                    c_budget_id SERIAL PRIMARY KEY,
                    c_user_id INT NOT NULL REFERENCES t_user(c_user_id) ON DELETE CASCADE,
                    c_category_id INT NOT NULL DEFAULT 0,
                    c_monthly_limit NUMERIC(12, 2) NOT NULL DEFAULT 0
                );",
                "ALTER TABLE t_budget ADD COLUMN IF NOT EXISTS c_category_id INT NOT NULL DEFAULT 0;",
                "ALTER TABLE t_budget ADD COLUMN IF NOT EXISTS c_monthly_limit NUMERIC(12, 2) NOT NULL DEFAULT 0;",
                "ALTER TABLE t_budget DROP CONSTRAINT IF EXISTS chk_budget_percentage;",
                "ALTER TABLE t_budget ALTER COLUMN c_budget_percentage DROP NOT NULL;",
                "ALTER TABLE t_budget ALTER COLUMN c_budget_month DROP NOT NULL;",
                "CREATE UNIQUE INDEX IF NOT EXISTS uq_user_budget_category ON t_budget (c_user_id, c_category_id);"
            };

            try
            {
                using var conn = Database.CreateConnection();
                conn.Open();
                foreach (string step in migrationSteps)
                {
                    try
                    {
                        using var cmd = new NpgsqlCommand(step, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception stepEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"Migration step notice ({step}): {stepEx.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("EnsureTableExists connection error: " + ex.Message);
            }
        }

        public static BudgetSummary GetBudgetSummary(int userId)
        {
            EnsureTableExists();
            var summary = new BudgetSummary();
            DateTime now = DateTime.Now;
            DateTime startOfMonth = new DateTime(now.Year, now.Month, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);

            try
            {
                using var conn = Database.CreateConnection();
                conn.Open();

                // 1. Total Balance all time
                string balanceSql = @"
                    SELECT 
                        COALESCE(SUM(CASE WHEN LOWER(tt.c_type_name) = 'income' THEN t.c_amount ELSE 0 END), 0) AS total_income,
                        COALESCE(SUM(CASE WHEN LOWER(tt.c_type_name) = 'expense' THEN t.c_amount ELSE 0 END), 0) AS total_expense
                    FROM t_transaction t
                    JOIN t_category c ON c.c_category_id = t.c_category_id
                    JOIN t_transaction_type tt ON tt.c_type_id = c.c_type_id
                    WHERE t.c_user_id = @userId;";
                using (var cmd = new NpgsqlCommand(balanceSql, conn))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    using var rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        decimal allIncome = rdr.GetDecimal(0);
                        decimal allExpense = rdr.GetDecimal(1);
                        summary.TotalBalance = allIncome - allExpense;
                    }
                }

                // 2. This month income and expense
                string monthSql = @"
                    SELECT 
                        COALESCE(SUM(CASE WHEN LOWER(tt.c_type_name) = 'income' THEN t.c_amount ELSE 0 END), 0) AS month_income,
                        COALESCE(SUM(CASE WHEN LOWER(tt.c_type_name) = 'expense' THEN t.c_amount ELSE 0 END), 0) AS month_expense
                    FROM t_transaction t
                    JOIN t_category c ON c.c_category_id = t.c_category_id
                    JOIN t_transaction_type tt ON tt.c_type_id = c.c_type_id
                    WHERE t.c_user_id = @userId
                      AND t.c_transaction_date >= @startOfMonth
                      AND t.c_transaction_date <= @endOfMonth;";
                using (var cmd = new NpgsqlCommand(monthSql, conn))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("startOfMonth", DateOnly.FromDateTime(startOfMonth));
                    cmd.Parameters.AddWithValue("endOfMonth", DateOnly.FromDateTime(endOfMonth));
                    using var rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        summary.ThisMonthIncome = rdr.GetDecimal(0);
                        summary.ThisMonthExpense = rdr.GetDecimal(1);
                        summary.OverallSpent = summary.ThisMonthExpense;
                    }
                }

                // 3. Overall monthly budget limit
                string overallBudgetSql = "SELECT c_monthly_limit FROM t_budget WHERE c_user_id = @userId AND c_category_id = 0 LIMIT 1;";
                using (var cmd = new NpgsqlCommand(overallBudgetSql, conn))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    object? res = cmd.ExecuteScalar();
                    if (res != null && res != DBNull.Value)
                    {
                        summary.OverallLimit = Convert.ToDecimal(res);
                    }
                }

                // 4. Category-wise expense limits and spending for current month
                string catBudgetSql = @"
                    SELECT 
                        c.c_category_id,
                        c.c_category_name,
                        COALESCE(b.c_monthly_limit, 0) AS budget_limit,
                        COALESCE(spent.total_spent, 0) AS current_spent
                    FROM t_category c
                    JOIN t_transaction_type tt ON tt.c_type_id = c.c_type_id AND LOWER(tt.c_type_name) = 'expense'
                    LEFT JOIN t_budget b ON b.c_category_id = c.c_category_id AND b.c_user_id = @userId
                    LEFT JOIN (
                        SELECT c_category_id, SUM(c_amount) AS total_spent
                        FROM t_transaction
                        WHERE c_user_id = @userId
                          AND c_transaction_date >= @startOfMonth
                          AND c_transaction_date <= @endOfMonth
                        GROUP BY c_category_id
                    ) spent ON spent.c_category_id = c.c_category_id
                    ORDER BY budget_limit DESC, current_spent DESC, c.c_category_name;";

                using (var cmd = new NpgsqlCommand(catBudgetSql, conn))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("startOfMonth", DateOnly.FromDateTime(startOfMonth));
                    cmd.Parameters.AddWithValue("endOfMonth", DateOnly.FromDateTime(endOfMonth));
                    using var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        var item = new BudgetCategoryItem
                        {
                            CategoryId = rdr.GetInt32(0),
                            CategoryName = rdr.GetString(1),
                            MonthlyLimit = rdr.GetDecimal(2),
                            CurrentSpent = rdr.GetDecimal(3)
                        };
                        summary.CategoryBudgets.Add(item);

                        // Alerts
                        if (item.IsExceeded)
                        {
                            summary.Alerts.Add($"⚠️ Category '{item.CategoryName}' has exceeded its budget! Spent: ₹{item.CurrentSpent:N2} / Limit: ₹{item.MonthlyLimit:N2}");
                        }
                        else if (item.IsWarning)
                        {
                            summary.Alerts.Add($"🔔 Category '{item.CategoryName}' reached {item.Percentage}% of its budget limit (Spent: ₹{item.CurrentSpent:N2} / Limit: ₹{item.MonthlyLimit:N2})");
                        }
                    }
                }

                // Overall Alerts
                if (summary.IsOverallExceeded)
                {
                    summary.Alerts.Insert(0, $"🚨 Overall Monthly Budget Exceeded! Spent: ₹{summary.OverallSpent:N2} / Limit: ₹{summary.OverallLimit:N2}");
                }
                else if (summary.IsOverallWarning)
                {
                    summary.Alerts.Insert(0, $"⚠️ Overall Monthly Budget at {summary.OverallPercentage}% (Spent: ₹{summary.OverallSpent:N2} / Limit: ₹{summary.OverallLimit:N2})");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error getting budget summary: " + ex.Message);
            }

            return summary;
        }

        public static bool SaveAllBudgets(int userId, decimal overallLimit, Dictionary<int, decimal> categoryLimits, out string errorMessage)
        {
            errorMessage = string.Empty;
            EnsureTableExists();
            try
            {
                using var conn = Database.CreateConnection();
                conn.Open();
                using var trans = conn.BeginTransaction();

                // 1. Delete previous limits for this user
                string deleteSql = "DELETE FROM t_budget WHERE c_user_id = @userId;";
                using (var delCmd = new NpgsqlCommand(deleteSql, conn, trans))
                {
                    delCmd.Parameters.AddWithValue("userId", userId);
                    delCmd.ExecuteNonQuery();
                }

                // 2. Insert overall limit (c_category_id = 0)
                string insertSql = "INSERT INTO t_budget (c_user_id, c_category_id, c_monthly_limit) VALUES (@userId, @categoryId, @limit);";
                using (var cmd = new NpgsqlCommand(insertSql, conn, trans))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.Parameters.AddWithValue("categoryId", 0);
                    cmd.Parameters.AddWithValue("limit", overallLimit);
                    cmd.ExecuteNonQuery();
                }

                // 3. Insert category limits
                foreach (var kvp in categoryLimits)
                {
                    if (kvp.Value > 0)
                    {
                        using var cmd = new NpgsqlCommand(insertSql, conn, trans);
                        cmd.Parameters.AddWithValue("userId", userId);
                        cmd.Parameters.AddWithValue("categoryId", kvp.Key);
                        cmd.Parameters.AddWithValue("limit", kvp.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                System.Diagnostics.Debug.WriteLine("Error saving budgets: " + ex.Message);
                return false;
            }
        }

        public static List<string> CheckNewTransactionBudgetAlert(int userId, int categoryId, decimal amount, DateTime txDate)
        {
            var alerts = new List<string>();
            DateTime now = DateTime.Now;
            if (txDate.Month != now.Month || txDate.Year != now.Year)
            {
                return alerts; // Not for current month
            }

            try
            {
                var summary = GetBudgetSummary(userId);

                // Check category
                var catItem = summary.CategoryBudgets.Find(c => c.CategoryId == categoryId);
                if (catItem != null && catItem.HasLimit)
                {
                    decimal newTotal = catItem.CurrentSpent + amount;
                    if (newTotal >= catItem.MonthlyLimit)
                    {
                        alerts.Add($"⚠️ Warning: This transaction of ₹{amount:N2} exceeds your '{catItem.CategoryName}' monthly budget!\nTotal will become ₹{newTotal:N2} / Limit: ₹{catItem.MonthlyLimit:N2}");
                    }
                    else if ((newTotal / catItem.MonthlyLimit) >= 0.85m)
                    {
                        alerts.Add($"🔔 Notice: This transaction brings '{catItem.CategoryName}' spending to {Math.Round((newTotal / catItem.MonthlyLimit) * 100)}% of limit.");
                    }
                }

                // Check overall
                if (summary.HasOverallLimit)
                {
                    decimal newOverall = summary.OverallSpent + amount;
                    if (newOverall >= summary.OverallLimit)
                    {
                        alerts.Add($"🚨 Alert: This transaction exceeds your Overall Monthly Budget!\nTotal spent will be ₹{newOverall:N2} / Limit: ₹{summary.OverallLimit:N2}");
                    }
                }
            }
            catch { }

            return alerts;
        }
    }
}
