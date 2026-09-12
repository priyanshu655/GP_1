using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Npgsql;

namespace MoneyMap.AdminPanel.Analysis
{
    public partial class AnalysisControl : UserControl
    {
        private List<KeyValuePair<string, double>> userData;
        private List<KeyValuePair<string, double>> transactionData;
        private List<KeyValuePair<string, double>> categoryData;
        private List<KeyValuePair<string, double>> budgetData;

        private string userGraphTitle;
        private string transactionGraphTitle;
        private string categoryGraphTitle;
        private string budgetGraphTitle;

        #region Constructor

        public AnalysisControl()
        {
            InitializeComponent();

            userData = new List<KeyValuePair<string, double>>();
            transactionData = new List<KeyValuePair<string, double>>();
            categoryData = new List<KeyValuePair<string, double>>();
            budgetData = new List<KeyValuePair<string, double>>();

            LoadUserData();
            LoadTransactionData();
            LoadCategoryData();
            LoadBudgetData();

            pnlUsers.Paint += PnlUsers_Paint;
            pnlTransactions.Paint += PnlTransactions_Paint;
            pnlCategories.Paint += PnlCategories_Paint;
            pnlBudgets.Paint += PnlBudgets_Paint;

            pnlUsers.Invalidate();
            pnlTransactions.Invalidate();
            pnlCategories.Invalidate();
            pnlBudgets.Invalidate();
        }

        #endregion

        #region Events

        private void PnlUsers_Paint(
            object sender,
            PaintEventArgs e)
        {
            DrawGraph(
                e.Graphics,
                pnlUsers,
                userData,
                userGraphTitle,
                "Month",
                "User Count");
        }

        private void PnlTransactions_Paint(
            object sender,
            PaintEventArgs e)
        {
            DrawGraph(
                e.Graphics,
                pnlTransactions,
                transactionData,
                transactionGraphTitle,
                "Month",
                "Transaction Count");
        }

        private void PnlCategories_Paint(
            object sender,
            PaintEventArgs e)
        {
            DrawGraph(
                e.Graphics,
                pnlCategories,
                categoryData,
                categoryGraphTitle,
                "Category",
                "Total Amount");
        }

        private void PnlBudgets_Paint(
            object sender,
            PaintEventArgs e)
        {
            DrawGraph(
                e.Graphics,
                pnlBudgets,
                budgetData,
                budgetGraphTitle,
                "Month",
                "Budget Count");
        }

        #endregion

        #region Methods

        private void LoadUserData()
        {
            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        TO_CHAR(
                            DATE_TRUNC(
                                'month',
                                c_created_at
                            ),
                            'Mon YYYY'
                        ) AS month_name,
                        COUNT(*) AS user_count,
                        'Users Registered Per Month (' ||
                        COUNT(*) OVER () ||
                        ' Months)' AS graph_title
                    FROM t_user
                    GROUP BY
                        DATE_TRUNC(
                            'month',
                            c_created_at
                        )
                    ORDER BY
                        DATE_TRUNC(
                            'month',
                            c_created_at
                        )";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userData.Add(
                                new KeyValuePair<string, double>(
                                    reader["month_name"].ToString(),
                                    Convert.ToDouble(
                                        reader["user_count"])));

                            userGraphTitle =
                                reader["graph_title"].ToString();
                        }
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(userGraphTitle))
            {
                userGraphTitle =
                    "Users Registered Per Month";
            }
        }

        private void LoadTransactionData()
        {
            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        TO_CHAR(
                            DATE_TRUNC(
                                'month',
                                c_transaction_date
                            ),
                            'Mon YYYY'
                        ) AS month_name,
                        COUNT(*) AS transaction_count,
                        'Transactions Per Month (' ||
                        COUNT(*) OVER () ||
                        ' Months)' AS graph_title
                    FROM t_transaction
                    GROUP BY
                        DATE_TRUNC(
                            'month',
                            c_transaction_date
                        )
                    ORDER BY
                        DATE_TRUNC(
                            'month',
                            c_transaction_date
                        )";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            transactionData.Add(
                                new KeyValuePair<string, double>(
                                    reader["month_name"].ToString(),
                                    Convert.ToDouble(
                                        reader["transaction_count"])));

                            transactionGraphTitle =
                                reader["graph_title"].ToString();
                        }
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(
                transactionGraphTitle))
            {
                transactionGraphTitle =
                    "Transactions Per Month";
            }
        }

        private void LoadCategoryData()
        {
            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        c.c_category_name,
                        SUM(t.c_amount) AS total_amount,
                        'Transaction Amount By Category (' ||
                        COUNT(*) OVER () ||
                        ' Categories)' AS graph_title
                    FROM t_transaction t
                    INNER JOIN t_category c
                        ON t.c_category_id =
                           c.c_category_id
                    GROUP BY
                        c.c_category_name
                    ORDER BY
                        total_amount DESC";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categoryData.Add(
                                new KeyValuePair<string, double>(
                                    reader["c_category_name"]
                                        .ToString(),
                                    Convert.ToDouble(
                                        reader["total_amount"])));

                            categoryGraphTitle =
                                reader["graph_title"].ToString();
                        }
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(
                categoryGraphTitle))
            {
                categoryGraphTitle =
                    "Transaction Amount By Category";
            }
        }

        private void LoadBudgetData()
        {
            using (NpgsqlConnection connection =
                GP_1.Database.CreateConnection())
            {
                connection.Open();

                string query = @"
                    SELECT
                        TO_CHAR(
                            DATE_TRUNC(
                                'month',
                                c_budget_month
                            ),
                            'Mon YYYY'
                        ) AS month_name,
                        COUNT(*) AS budget_count,
                        'Budgets Created Per Month (' ||
                        COUNT(*) OVER () ||
                        ' Months)' AS graph_title
                    FROM t_budget
                    GROUP BY
                        DATE_TRUNC(
                            'month',
                            c_budget_month
                        )
                    ORDER BY
                        DATE_TRUNC(
                            'month',
                            c_budget_month
                        )";

                using (NpgsqlCommand command =
                    new NpgsqlCommand(query, connection))
                {
                    using (NpgsqlDataReader reader =
                        command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            budgetData.Add(
                                new KeyValuePair<string, double>(
                                    reader["month_name"].ToString(),
                                    Convert.ToDouble(
                                        reader["budget_count"])));

                            budgetGraphTitle =
                                reader["graph_title"].ToString();
                        }
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(
                budgetGraphTitle))
            {
                budgetGraphTitle =
                    "Budgets Created Per Month";
            }
        }

        private void DrawGraph(
            Graphics graphics,
            Panel panel,
            List<KeyValuePair<string, double>> data,
            string title,
            string xAxisTitle,
            string yAxisTitle)
        {
            graphics.Clear(Color.White);

            using (Font titleFont =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold))
            {
                graphics.DrawString(
                    title,
                    titleFont,
                    new SolidBrush(
                        Color.FromArgb(15, 23, 42)),
                    new PointF(15, 12));
            }

            int left = 60;
            int top = 55;
            int right = 20;
            int bottom = 55;

            int graphWidth =
                panel.Width - left - right;

            int graphHeight =
                panel.Height - top - bottom;

            if (graphWidth <= 0 || graphHeight <= 0)
            {
                return;
            }

            using (Pen axisPen =
                new Pen(
                    Color.FromArgb(100, 116, 139),
                    1))
            {
                graphics.DrawLine(
                    axisPen,
                    left,
                    top,
                    left,
                    top + graphHeight);

                graphics.DrawLine(
                    axisPen,
                    left,
                    top + graphHeight,
                    left + graphWidth,
                    top + graphHeight);
            }

            using (Font axisFont =
                new Font(
                    "Segoe UI",
                    8F))
            {
                graphics.DrawString(
                    xAxisTitle,
                    axisFont,
                    new SolidBrush(
                        Color.FromArgb(71, 85, 105)),
                    new PointF(
                        left + graphWidth / 2 - 20,
                        panel.Height - 22));

                graphics.DrawString(
                    yAxisTitle,
                    axisFont,
                    new SolidBrush(
                        Color.FromArgb(71, 85, 105)),
                    new PointF(
                        5,
                        top - 15));
            }

            if (data.Count == 0)
            {
                using (Font emptyFont =
                    new Font(
                        "Segoe UI",
                        10F))
                {
                    graphics.DrawString(
                        "No data available",
                        emptyFont,
                        new SolidBrush(
                            Color.FromArgb(100, 116, 139)),
                        new PointF(
                            left + 20,
                            top + 40));
                }

                return;
            }

            double maximumValue = 0;

            foreach (
                KeyValuePair<string, double> item in data)
            {
                if (item.Value > maximumValue)
                {
                    maximumValue = item.Value;
                }
            }

            if (maximumValue <= 0)
            {
                maximumValue = 1;
            }

            int gridCount = 5;

            using (Pen gridPen =
                new Pen(
                    Color.FromArgb(226, 232, 240),
                    1))
            {
                using (Font gridFont =
                    new Font(
                        "Segoe UI",
                        7F))
                {
                    for (int i = 0; i <= gridCount; i++)
                    {
                        int y =
                            top +
                            graphHeight -
                            (i * graphHeight / gridCount);

                        graphics.DrawLine(
                            gridPen,
                            left,
                            y,
                            left + graphWidth,
                            y);

                        double value =
                            maximumValue *
                            i /
                            gridCount;

                        graphics.DrawString(
                            FormatValue(value),
                            gridFont,
                            new SolidBrush(
                                Color.FromArgb(
                                    100,
                                    116,
                                    139)),
                            new PointF(
                                8,
                                y - 7));
                    }
                }
            }

            int itemCount = data.Count;

            if (itemCount > 12)
            {
                itemCount = 12;
            }

            float spacing =
                (float)graphWidth / itemCount;

            float barWidth =
                spacing * 0.55F;

            using (Brush barBrush =
                new SolidBrush(
                    Color.FromArgb(16, 185, 129)))
            {
                using (Font valueFont =
                    new Font(
                        "Segoe UI",
                        7F,
                        FontStyle.Bold))
                {
                    using (Font labelFont =
                        new Font(
                            "Segoe UI",
                            7F))
                    {
                        for (int i = 0;
                             i < itemCount;
                             i++)
                        {
                            double value =
                                data[i].Value;

                            float barHeight =
                                (float)(
                                    value /
                                    maximumValue *
                                    graphHeight);

                            float x =
                                left +
                                i * spacing +
                                (spacing - barWidth) / 2;

                            float y =
                                top +
                                graphHeight -
                                barHeight;

                            graphics.FillRectangle(
                                barBrush,
                                x,
                                y,
                                barWidth,
                                barHeight);

                            string valueText =
                                FormatValue(value);

                            SizeF valueSize =
                                graphics.MeasureString(
                                    valueText,
                                    valueFont);

                            graphics.DrawString(
                                valueText,
                                valueFont,
                                new SolidBrush(
                                    Color.FromArgb(
                                        15,
                                        23,
                                        42)),
                                new PointF(
                                    x +
                                    (barWidth -
                                     valueSize.Width) / 2,
                                    y - 16));

                            string label =
                                data[i].Key;

                            if (label.Length > 10)
                            {
                                label =
                                    label.Substring(0, 10);
                            }

                            SizeF labelSize =
                                graphics.MeasureString(
                                    label,
                                    labelFont);

                            graphics.DrawString(
                                label,
                                labelFont,
                                new SolidBrush(
                                    Color.FromArgb(
                                        71,
                                        85,
                                        105)),
                                new PointF(
                                    x +
                                    (barWidth -
                                     labelSize.Width) / 2,
                                    top +
                                    graphHeight +
                                    5));
                        }
                    }
                }
            }
        }

        private string FormatValue(double value)
        {
            if (value >= 1000000)
            {
                return (value / 1000000)
                    .ToString("0.0") + "M";
            }

            if (value >= 1000)
            {
                return (value / 1000)
                    .ToString("0.0") + "K";
            }

            return value.ToString("0.##");
        }

        #endregion
    }
}