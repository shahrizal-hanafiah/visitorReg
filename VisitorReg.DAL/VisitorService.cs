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
        private string _connectionString;
        public VisitorService()
        {
            _connectionString = Settings.ConnectionString;
        }
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
                    cmd.Parameters.AddWithValue("@Gender", visitor.Gender);
                    cmd.Parameters.AddWithValue("@Race", visitor.Race);
                    cmd.Parameters.AddWithValue("@Address", visitor.Address);
                    cmd.Parameters.AddWithValue("@PhotoUrl", visitor.PhotoUrl);
                    cmd.Parameters.AddWithValue("@NoPlate", visitor.NoPlate);
                    cmd.Parameters.AddWithValue("@PassNo", visitor.PassNo);
                    cmd.Parameters.AddWithValue("@HouseNo", visitor.HouseNo);
                    cmd.Parameters.AddWithValue("@PurposeVisit", visitor.PurposeVisit);
                    cmd.Parameters.AddWithValue("@Remarks", visitor.Remarks);
                    cmd.Parameters.AddWithValue("@DateTimeIn", visitor.DateTimeIn);
                    cmd.Parameters.AddWithValue("@DateTimeOut", visitor.DateTimeOut);
                    cmd.Parameters.AddWithValue("@CreatedDate", visitor.CreatedDate);
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
        public ResponseMessageModel UpdateDateTimeOut(VisitorModel visitor)
        {
            ResponseMessageModel result = new ResponseMessageModel()
            {
                MessageType = MessageType.Failed,
                Message = "Failed to update visitor record"
            };
            string connectionString;
            SqlConnection cnn;
            connectionString = Settings.ConnectionString;
            using (cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_update", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DateTimeOut", visitor.DateTimeOut);
                    cmd.Parameters.AddWithValue("@Id", visitor.Id);

                    int i = cmd.ExecuteNonQuery();

                    if (i != 0)
                    {
                        result.MessageType = MessageType.Success;
                        result.Message = "Visitor record updated!";
                    }

                    log.Debug($"Successfully update visitor record");
                }
                catch (Exception ex)
                {
                    log.Error($"{ex.Message}");
                    result.MessageType = MessageType.Error;
                    result.Message = ex.Message;
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
        public List<DashboardModel> GetDashboardStats()
        {
            string sql;
            SqlConnection cnn;
            List<DashboardModel> result = new List<DashboardModel>();

            sql = "  SELECT [IntMonth],[MonthPurpose],[YearPurpose],[Visitor] , [Contractor], [Contractor Overnight], [Courier], [Food Delivery],[Goverment Agencies],[Others] " + 
                  " FROM(Select * from(SELECT a.Id, b.PurposeVisit, Month(b.DateTimeIn) as IntMonth, DATENAME(month, b.DateTimeIn) MonthPurpose, Year(b.DateTimeIn) YearPurpose " + 
                  " from VisitorInfo a inner " + 
                  " join Visits b on b.VisitorInfoId = a.Id " + 
                  " Where Year(DateTimeIn) = Year(GETDATE())) as a group by a.IntMonth, a.MonthPurpose, a.PurposeVisit, a.YearPurpose, a.Id) p " + 
                  " PIVOT(COUNT(Id)  FOR PurposeVisit IN( [Visitor], [Contractor], [Contractor Overnight], [Courier], [Food Delivery],[Goverment Agencies],[Others])  ) AS pvt  ";
            using (cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var item = new DashboardModel() {
                                intMonth = reader.GetInt32(0),
                                Month = reader.GetString(1),
                                Year = reader.GetInt32(2),
                                Visitors = reader.GetInt32(3),
                                Contractors = reader.GetInt32(4) + reader.GetInt32(5),
                                Couriers = reader.GetInt32(6),
                                FoodDeliveries = reader.GetInt32(7) 
                            };
                            result.Add(item);
                        }                        
                        reader.NextResult();
                    }
                    log.Debug($"Login success");
                }
                catch (Exception ex)
                {
                    log.Error($"{ex.Message}");
                }
                finally
                {
                    cnn.Close();
                }
            }

            return result;
        }
        public VisitorModel GetVisitorInfo(string ICNo)
        {
            string sql;
            SqlConnection cnn;
            VisitorModel result = new VisitorModel();

            sql = " SELECT Id,Name,ICNo,OldICNo,ContactNo,Gender,Race,Address,PhotoUrl FROM VisitorInfo WHERE ICNo = @ICNo ";
            using (cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.Add("@ICNo", SqlDbType.VarChar).Value = ICNo;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Id = reader.GetInt32(0);
                            result.Name = reader.GetString(1);
                            result.ICNo = reader.GetString(2);
                            result.OldICNo = reader.GetString(3);
                            result.ContactNo = reader.GetString(4);
                            result.Gender = reader.GetString(5);
                            result.Race = reader.GetString(6);
                            result.Address = reader.GetString(7);
                            result.PhotoUrl = reader.GetString(8);
                        }
                        reader.NextResult();
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"{ex.Message}");
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
