using System;
using System.IO;
using System.Text.Json;

namespace MoneyMap.Authentication
{
    public class UserSession
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public DateTime LoginTime { get; set; }
        public DateTime ExpiryTime { get; set; }
    }

    public static class SessionManager
    {
        private static readonly string AppDataFolder = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MoneyMap");

        private static readonly string SessionFilePath = Path.Combine(AppDataFolder, "session.json");
        private static readonly TimeSpan SessionDuration = TimeSpan.FromHours(2);

        /// <summary>
        /// Saves a new persistent session valid for 2 hours.
        /// </summary>
        public static void SaveSession(int userId, string username)
        {
            try
            {
                if (!Directory.Exists(AppDataFolder))
                {
                    Directory.CreateDirectory(AppDataFolder);
                }

                DateTime now = DateTime.UtcNow;
                UserSession session = new UserSession
                {
                    UserId = userId,
                    Username = username,
                    LoginTime = now,
                    ExpiryTime = now.Add(SessionDuration)
                };

                string json = JsonSerializer.Serialize(session, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SessionFilePath, json);
            }
            catch
            {
                // Non-critical if writing fails
            }
        }

        /// <summary>
        /// Retrieves the active session if it exists and is less than 2 hours old.
        /// Returns null if missing or expired.
        /// </summary>
        public static UserSession? GetActiveSession()
        {
            try
            {
                if (!File.Exists(SessionFilePath))
                {
                    return null;
                }

                string json = File.ReadAllText(SessionFilePath);
                if (string.IsNullOrWhiteSpace(json))
                {
                    return null;
                }

                UserSession? session = JsonSerializer.Deserialize<UserSession>(json);
                if (session == null)
                {
                    return null;
                }

                // Check if session is within the 2-hour limit
                if (DateTime.UtcNow < session.ExpiryTime)
                {
                    return session;
                }

                // Expired: clean up
                ClearSession();
                return null;
            }
            catch
            {
                ClearSession();
                return null;
            }
        }

        /// <summary>
        /// Clears the saved session on logout or expiration.
        /// </summary>
        public static void ClearSession()
        {
            try
            {
                if (File.Exists(SessionFilePath))
                {
                    File.Delete(SessionFilePath);
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Returns remaining session time, or TimeSpan.Zero if expired/none.
        /// </summary>
        public static TimeSpan GetRemainingTime()
        {
            var session = GetActiveSession();
            if (session == null) return TimeSpan.Zero;

            TimeSpan remaining = session.ExpiryTime - DateTime.UtcNow;
            return remaining > TimeSpan.Zero ? remaining : TimeSpan.Zero;
        }
    }
}
