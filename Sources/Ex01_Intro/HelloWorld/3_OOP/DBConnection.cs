using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class DBConnection
    {
        SQLiteConnection sqliteConnection;
        string dbPath;

        public DBConnection(string path)
        {
            dbPath = path;
        }

        public void DropDatabaseConnection()
        {
            sqliteConnection = null;
            GC.Collect();
        }

        public void CreateDatabaseConnection()
        {
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

        public void SetVersion(string newVersion)
        {
            sqliteConnection.Open();

            using (SQLiteCommand command = sqliteConnection.CreateCommand())
            {
                command.CommandText = string.Format("INSERT INTO version (version) VALUES (\"{0}\")", newVersion);
                command.ExecuteNonQuery();
            }

            sqliteConnection.Close();
        }
    }
}
