using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyKhachHang.GUI;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;

namespace QuanLyKhachHang
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String DatabaseName = "ABCLogistic";

            Server SqlServer = new Server(@".\SQLEXPRESS");
            ServerConnection SqlServerConnection = SqlServer.ConnectionContext;
            SqlServerConnection.LoginSecure = false;
            SqlServerConnection.Login = "sa";
            SqlServerConnection.Password = "123456";
            SqlServerConnection.DatabaseName = "master";

            Database NewDatabase = new Database(SqlServer, DatabaseName);

            FileGroup DatabaseFileGroup = new FileGroup(NewDatabase, "PRIMARY");
            NewDatabase.FileGroups.Add(DatabaseFileGroup);

            DataFile DatabaseDataFile = new DataFile(DatabaseFileGroup, DatabaseName);
            DatabaseFileGroup.Files.Add(DatabaseDataFile);

            DatabaseDataFile.FileName = @"E:\Data\Data v1.7\" + DatabaseName + ".mdf";

            LogFile DatabaseLogFile = new LogFile(NewDatabase, DatabaseName + "_log");
            NewDatabase.LogFiles.Add(DatabaseLogFile);

            DatabaseLogFile.FileName = @"E:\Data\Data v1.7\" + DatabaseName + "_log.ldf";

            StringCollection DatabaseFilesCollection = new StringCollection();

            DatabaseFilesCollection.Add(DatabaseDataFile.FileName);
            DatabaseFilesCollection.Add(DatabaseLogFile.FileName);

            SqlServer.AttachDatabase(DatabaseName, DatabaseFilesCollection);

            Application.Run(new Login());
        }
    }
}
