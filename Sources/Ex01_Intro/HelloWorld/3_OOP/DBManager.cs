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
    class DBManager
    {

        private IsolatedStorageFile isolatedStorageFile;
        private string databaseFolder;
        private string fullyQualifiedResourceName;
        private string databaseFileName;
        private string databaseVersion;

        private DBFile dbFile;
        private DBConnection cbConn;

        public DBManager(IsolatedStorageFile isoStorage, string folder, string resourceName, string fileName, string version)
        {
            isolatedStorageFile = isoStorage;
            databaseFolder = folder;
            fullyQualifiedResourceName = resourceName;
            databaseFileName = fileName;
            databaseVersion = version;
        }

        public void InitDB()
        {
            dbFile = new DBFile(isolatedStorageFile, databaseFolder, fullyQualifiedResourceName, databaseFileName);

            dbFile.CreateFolderIfNotExsists();
            dbFile.CopyReferenceDatabase(false);

            dbFile.GetDatabasePath();

            cbConn = new DBConnection(dbFile.DbFilePath);

            cbConn.CreateDatabaseConnection();

            if (cbConn.GetVersion() != databaseVersion)
            {
                cbConn.DropDatabaseConnection();
                dbFile.CopyReferenceDatabase(true);

                cbConn = new DBConnection(dbFile.DbFilePath);
                cbConn.CreateDatabaseConnection();
                cbConn.SetVersion(databaseVersion);
            }
        }

    }
}
