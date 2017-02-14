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
    class DBManager_god
    {
        IsolatedStorageFile isolatedStorageFile;
        string databaseFolder;
        string fullyQualifiedResourceName;
        string databaseFileName;
        string databaseVersion;
        string offlineDataFile;

        IsolatedStorageFile isoStorage = null;
        SQLiteConnection sqliteConnection;
        string dbPath;

        public DBManager_god(IsolatedStorageFile isoStorage, string folder, string resourceName, string fileName, string version)
        {
            isolatedStorageFile = isoStorage;
            databaseFolder = folder;
            fullyQualifiedResourceName = resourceName;
            databaseFileName = fileName;
            databaseVersion = version;

            offlineDataFile = Path.Combine(databaseFolder, databaseFileName);
        }

        public void InitDB()
        {
            isoStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            CreateFolderIfNotExsists();
            CopyReferenceDatabase(false);

            GetDatabasePath();

            CreateDatabaseConnection();

            if (GetVersion() != databaseVersion)
            {
                DropDatabaseConnection();
                CopyReferenceDatabase(true);
                CreateDatabaseConnection();
                SetVersion();
            }
        }

        void CreateFolderIfNotExsists()
        {
            if (!isoStorage.DirectoryExists(databaseFolder))
            {
                isoStorage.CreateDirectory(databaseFolder);
            }
        }

        void GetDatabasePath()
        {
            using (IsolatedStorageFileStream output = isoStorage.OpenFile(offlineDataFile, FileMode.Open))
            {
                dbPath = output.GetType().GetField("m_FullPath", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(output).ToString();
            }
        }

        void DropDatabaseConnection()
        {
            sqliteConnection = null;
            GC.Collect();
        }

        void CreateDatabaseConnection()
        {
            sqliteConnection = new SQLiteConnection(string.Format("Data Source = {0}; Version = 3;", dbPath));
        }

        string GetVersion()
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

        void CopyReferenceDatabase(Boolean forceOverwrite)
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();

            if (!isoStorage.FileExists(offlineDataFile) || forceOverwrite)
            {
                using (Stream input = _assembly.GetManifestResourceStream(fullyQualifiedResourceName))
                {
                    using (IsolatedStorageFileStream output = isoStorage.CreateFile(offlineDataFile))
                    {
                        byte[] readBuffer = new byte[4096];
                        int bytesRead = -1;

                        while ((bytesRead = input.Read(readBuffer, 0, readBuffer.Length)) > 0)
                        {
                            output.Write(readBuffer, 0, bytesRead);
                        }
                    }
                }
            }
        }

        void SetVersion()
        {
            sqliteConnection.Open();

            using (SQLiteCommand command = sqliteConnection.CreateCommand())
            {
                command.CommandText = string.Format("INSERT INTO version (version) VALUES (\"{0}\")", databaseVersion);
                command.ExecuteNonQuery();
            }

            sqliteConnection.Close();
        }
    }
}
