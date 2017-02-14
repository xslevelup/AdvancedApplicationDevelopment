using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class DBFile
    {
        string OfflineContentFolder;
        string FullyQualifiedResourceName;
        string DatabaseFileName;
        string offlineDataFile;

        IsolatedStorageFile isoStorage = null;
        string dbPath;

        public string DbFilePath { get { return dbPath; } }

        public DBFile(IsolatedStorageFile storage, string folder, string resourceName, string fileName)
        {
            isoStorage = storage;

            OfflineContentFolder = folder;
            FullyQualifiedResourceName = resourceName;
            DatabaseFileName = fileName;

            offlineDataFile = Path.Combine(OfflineContentFolder, DatabaseFileName);
        }

        public void CreateFolderIfNotExsists()
        {
            if (!isoStorage.DirectoryExists(OfflineContentFolder))
            {
                isoStorage.CreateDirectory(OfflineContentFolder);
            }
        }

        public void GetDatabasePath()
        {
            using (IsolatedStorageFileStream output = isoStorage.OpenFile(offlineDataFile, FileMode.Open))
            {
                dbPath = output.GetType().GetField("m_FullPath", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(output).ToString();
            }
        }

        public void CopyReferenceDatabase(Boolean forceOverwrite)
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
    }
}
