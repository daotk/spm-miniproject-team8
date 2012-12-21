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
        private static string strusernameserver, strpasswordserver, strlinkdata;
        private static bool showform = true;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            String DatabaseName = "ABCLogistic";
            Server SqlServe1r = new Server(@".\SQLEXPRESS");
            if (SqlServe1r.Databases[DatabaseName] == null)
            {
                Fm_CauHinh fmcauhinh = new Fm_CauHinh();
                fmcauhinh.returndata += new Fm_CauHinh.ReturnResult(fmcauhinh_returndata);
                fmcauhinh.ShowDialog();
                Server SqlServer = new Server(@".\SQLEXPRESS");
                ServerConnection SqlServerConnection = SqlServer.ConnectionContext;
                SqlServerConnection.LoginSecure = false;
                SqlServerConnection.Login = strusernameserver;
                SqlServerConnection.Password = strpasswordserver;
                SqlServerConnection.DatabaseName = "master";
                try
                {

                    Database NewDatabase = new Database(SqlServer, DatabaseName);
                    FileGroup DatabaseFileGroup = new FileGroup(NewDatabase, "PRIMARY");
                    NewDatabase.FileGroups.Add(DatabaseFileGroup);
                    DataFile DatabaseDataFile = new DataFile(DatabaseFileGroup, DatabaseName);
                    DatabaseFileGroup.Files.Add(DatabaseDataFile);
                    DatabaseDataFile.FileName = @strlinkdata + "\\" + DatabaseName + ".mdf";
                    LogFile DatabaseLogFile = new LogFile(NewDatabase, DatabaseName + "_log");
                    NewDatabase.LogFiles.Add(DatabaseLogFile);
                    DatabaseLogFile.FileName = @strlinkdata + "\\" + DatabaseName + "_log.ldf";
                    StringCollection DatabaseFilesCollection = new StringCollection();
                    DatabaseFilesCollection.Add(DatabaseDataFile.FileName);
                    DatabaseFilesCollection.Add(DatabaseLogFile.FileName);
                    SqlServer.AttachDatabase(DatabaseName, DatabaseFilesCollection);

                }
                catch (Exception ex)
                {
                    DialogResult result = MessageBox.Show("Lỗi trong khi kết nối tới Server.\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (result == DialogResult.OK)
                    {
                        fmcauhinh.ShowDialog();
                    }
                    showform = false;
                }
            }
            if (showform == true)
            {
                Application.Run(new Login());
            }
        }

        static void fmcauhinh_returndata(string strUerName, string strPassWord, string strLinkFile)
        {
            strusernameserver = strUerName;
            strpasswordserver = strPassWord;
            strlinkdata = strLinkFile;
        }
    }
}
