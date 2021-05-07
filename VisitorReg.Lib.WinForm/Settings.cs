using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Configuration.ConfigurationManager;

namespace VisitorReg.Lib.WinForm
{
    public sealed class Settings
    {
        public static string ConnectionString;
        private static readonly Settings instance = new Settings();
        static Settings()
        {
            GetConnectionString();
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
    }
}
