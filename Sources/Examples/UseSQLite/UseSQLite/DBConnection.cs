using System;
using System.Data.SQLite;

namespace UseSQLite
{
    class DBConnection
    {
        SQLiteConnection sqliteConnection;
        string dbPath;

        public DBConnection(string path)
        {
            dbPath = path;
            sqliteConnection = new SQLiteConnection(string.Format("Data Source = {0}; Version = 3;", dbPath));
        }

        public string GetVersion()
        {
            string versionString = String.Empty;
            sqliteConnection.Open();

            using (SQLiteCommand command = sqliteConnection.CreateCommand())
            {
                command.CommandText = "SELECT version FROM version ORDER BY version DESC";
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        versionString = (string)reader["version"];
                    }
                }
            }

            sqliteConnection.Close();

            return versionString;
        }

    }
}
