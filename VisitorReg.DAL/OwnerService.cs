using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

            sql = "SELECT OwnerNotes,OwnerNotesDesc,ExpiryDate from OwnerNotes where OwnerHouseNo = @OwnerHouseNo and IsActive = 1";

            using (cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.Add("@OwnerHouseNo", SqlDbType.VarChar).Value = ownerHouse;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            OwnerNotesModel ownerDet = new OwnerNotesModel();
                            ownerDet.OwnerNotes = reader.GetString(0);
                            ownerDet.OwnerNotesDesc = reader.GetString(1);
                            ownerDet.NotesExpiryDate = reader.GetDateTime(2);
                            reader.NextResult();
                            notes.Add(ownerDet);
                        }
                        reader.NextResult();
                    }
                    log.Debug($"Get Owner Notes");
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
