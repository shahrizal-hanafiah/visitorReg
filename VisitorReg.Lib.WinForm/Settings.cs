using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Configuration.ConfigurationManager;

namespace VisitorReg.Lib.WinForm
{
    public sealed class Settings
    {
        public static string ConnectionString;
        public static string ReaderSettings;
        public static string PhotoSettings;
        private static readonly Settings instance = new Settings();
        static Settings()
        {
            GetConnectionString();
            GetFolderPath();
            GetImagesPath();
        }
        private Settings()
        {

        }
        public static Settings Instance
        {
            get
            {
                return instance;
            }
        }
        private static void GetConnectionString()
        {
            ConnectionString = ConnectionStrings["VisitorRegDB"].ConnectionString;
        }

        private static void GetFolderPath()
        {
            ReaderSettings = ConfigurationManager.AppSettings["MyKadReader"];
        }
        private static void GetImagesPath()
        {
            PhotoSettings = ConfigurationManager.AppSettings["MyKadPhotos"];
        }
    }
}
