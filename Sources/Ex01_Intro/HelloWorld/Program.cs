using System;
using System.Data.SQLite;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region Monolitikus programozás

            const string OfflineContentFolder = "DataBase";
            const string FullyQualifiedResourceName = "HelloWorld.DataBase.sqlite";
            const string DatabaseFileName = "DataBase.sqlite";
            const string CurrentVersion = "1.0.0";
            string offlineDataFile = Path.Combine(OfflineContentFolder, DatabaseFileName);

            IsolatedStorageFile isoStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            SQLiteConnection sqliteConnection;
            string dbPath;

            using (IsolatedStorageFileStream output = isoStorage.OpenFile(offlineDataFile, FileMode.Open))
            {
                dbPath = output.GetType().GetField("m_FullPath", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(output).ToString();
            }

            if (!isoStorage.DirectoryExists(OfflineContentFolder))
            {
                isoStorage.CreateDirectory(OfflineContentFolder);
            }

            Assembly _assembly = Assembly.GetExecutingAssembly();

            if (!isoStorage.FileExists(offlineDataFile))
            {
                using (Stream input = _assembly.GetManifestResourceStream(FullyQualifiedResourceName))
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

            sqliteConnection = new SQLiteConnection(string.Format("Data Source = {0}; Version = 3;", dbPath));
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

            if (versionString != CurrentVersion)
            {
                sqliteConnection = null;
                GC.Collect();

                using (Stream input = _assembly.GetManifestResourceStream(FullyQualifiedResourceName))
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

                sqliteConnection = new SQLiteConnection(string.Format("Data Source = {0}; Version = 3;", dbPath));

                sqliteConnection.Open();

                using (SQLiteCommand command = sqliteConnection.CreateCommand())
                {
                    command.CommandText = string.Format("INSERT INTO version (version) VALUES (\"{0}\")", CurrentVersion);
                    command.ExecuteNonQuery();
                }

                sqliteConnection.Close();
            }

            #endregion

            #region Moduláris programozás

            InitDB();

            #endregion

            #region Static object

            DBManager_static.InitDB();

            #endregion

            #region God object

            IsolatedStorageFile isolatedStorageForGod = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            DBManager_god dbmGod = new DBManager_god(isolatedStorageForGod, "DataBase", "HelloWorld.DataBase.sqlite", "DataBase.sqlite", "1.0.0");

            dbmGod.InitDB();

            #endregion

            #region OOP

            IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            DBManager dbm = new DBManager(isolatedStorage, "DataBase", "HelloWorld.DataBase.sqlite", "DataBase.sqlite", "1.0.0");

            dbm.InitDB();

            #endregion
        }

        #region Moduláris programozás

        const string OfflineContentFolder = "DataBase";
        const string FullyQualifiedResourceName = "HelloWorld.DataBase.sqlite";
        const string DatabaseFileName = "DataBase.sqlite";
        const string CurrentVersion = "1.0.0";
        static string offlineDataFile = Path.Combine(OfflineContentFolder, DatabaseFileName);

        static IsolatedStorageFile isoStorage = null;
        static SQLiteConnection sqliteConnection;
        static string dbPath;

        public static void InitDB()
        {
            isoStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);

            CreateFolderIfNotExsists();
            CopyReferenceDatabase(false);

            GetDatabasePath();

            CreateDatabaseConnection();

            if (GetVersion() != CurrentVersion)
            {
                DropDatabaseConnection();
                CopyReferenceDatabase(true);
                CreateDatabaseConnection();
                SetVersion();
            }
        }

        public static void CreateFolderIfNotExsists()
        {
            if (!isoStorage.DirectoryExists(OfflineContentFolder))
            {
                isoStorage.CreateDirectory(OfflineContentFolder);
            }
        }

        public static void GetDatabasePath()
        {
            using (IsolatedStorageFileStream output = isoStorage.OpenFile(offlineDataFile, FileMode.Open))
            {
                dbPath = output.GetType().GetField("m_FullPath", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(output).ToString();
            }
        }

        public static void DropDatabaseConnection()
        {
            sqliteConnection = null;
            GC.Collect();
        }

        public static void CreateDatabaseConnection()
        {
            sqliteConnection = new SQLiteConnection(string.Format("Data Source = {0}; Version = 3;", dbPath));
        }

        public static string GetVersion()
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

        public static void CopyReferenceDatabase(Boolean forceOverwrite)
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();

            if (!isoStorage.FileExists(offlineDataFile) || forceOverwrite)
            {
                using (Stream input = _assembly.GetManifestResourceStream(FullyQualifiedResourceName))
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

        public static void SetVersion()
        {
            sqliteConnection.Open();

            using (SQLiteCommand command = sqliteConnection.CreateCommand())
            {
                command.CommandText = string.Format("INSERT INTO version (version) VALUES (\"{0}\")", CurrentVersion);
                command.ExecuteNonQuery();
            }

            sqliteConnection.Close();
        }

        #endregion

    }
}
