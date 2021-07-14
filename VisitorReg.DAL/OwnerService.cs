using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorReg.Lib.WinForm;
using VisitorReg.Lib.WinForm.Models.Owner;

namespace VisitorReg.DAL
{
    public class OwnerService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UserService));
        private string _connectionString;

        public OwnerService()
        {
            _connectionString = Settings.ConnectionString;
        }

        public List<OwnerNotesModel> GetOwnerNotes(string ownerHouse)
        {
            List<OwnerNotesModel> notes = new List<OwnerNotesModel>();
            string sql;
            SqlConnection cnn;

            sql = "SELECT OwnerNotes,OwnerNotesDesc,ExpiryDate from OwnerNotes where OwnerHouseNo = @OwnerHouseNo";

            using (cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.Add("@OwnerHouseNo", SqlDbType.VarChar).Value = ownerHouse;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return notes;
        }
    }
}
