using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorReg.Lib.WinForm;
using VisitorReg.Lib.WinForm.Enum;
using VisitorReg.Lib.WinForm.Models.Messages;
using VisitorReg.Lib.WinForm.Models.Visitor;

namespace VisitorReg.DAL
{
    public class VisitorService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UserService));
        public ResponseMessageModel Insert(VisitorModel visitor)
        {
            ResponseMessageModel result = new ResponseMessageModel()
            {
                MessageType = MessageType.Failed,
                Message = "Failed to insert visitor record"
            };
            string connectionString;
            SqlConnection cnn;
            connectionString = Settings.ConnectionString;
            using (cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_insert", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", visitor.Name);
                    cmd.Parameters.AddWithValue("@ICNo", visitor.ICNo);
                    cmd.Parameters.AddWithValue("@OldICNo", visitor.OldICNo);
                    cmd.Parameters.AddWithValue("@ContactNo", visitor.ContactNo);
                    cmd.Parameters.AddWithValue("@NoPlate", visitor.NoPlate);
                    cmd.Parameters.AddWithValue("@PassNo", visitor.PassNo);
                    cmd.Parameters.AddWithValue("@HouseNo", visitor.HouseNo);
                    cmd.Parameters.AddWithValue("@PurposeVisit", visitor.PurposeVisit);
                    cmd.Parameters.AddWithValue("@DateTimeIn", visitor.DateTimeIn);
                    cmd.Parameters.AddWithValue("@DateTimeOut", visitor.DateTimeOut);
                    cmd.Parameters.AddWithValue("@CreateDate", visitor.CreateDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", visitor.CreatedBy);

                    int i = cmd.ExecuteNonQuery();

                    if (i != 0)
                    {
                        result.MessageType = MessageType.Success;
                        result.Message = "Visitor record inserted!";
                    }

                    log.Debug($"Successfully insert visitor record");
                }
                catch (Exception ex)
                {
                    log.Error($"{ex.Message}");
                    result.MessageType = MessageType.Error;
                    result.Message = "Error occured!";
                    var error = new Error()
                    {
                        Message = ex.Message,
                        Details = $"Stack Trace:{ex.StackTrace}"
                    };
                    result.Error = error;
                }
                finally
                {
                    cnn.Close();
                }
            }
            return result;
        }
    }
}
