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
using VisitorReg.Lib.WinForm.Models.User;

namespace VisitorReg.DAL
{
    public class UserService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UserService));
        private string _connectionString;
        public UserService()
        {
            _connectionString = Settings.ConnectionString;
        }
        public void Login(LoginUserModel userLogin)
        {
            LoginResponseModel result = new LoginResponseModel();
            string sql;
            SqlConnection cnn;
                      

            sql = "Select Id,Username,Name,Role,ContactNo,Email from UserInfo Where Username = @Username and Password = @Password";
            using (cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, cnn);
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = userLogin.Username;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = userLogin.Password;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserInfo.UserID = (int)reader.GetInt32(0);
                            UserInfo.Username = reader.GetString(1);
                            UserInfo.Name = reader.GetString(2);
                            UserInfo.Role = reader.GetString(3);
                            UserInfo.ContactNo = reader.GetString(4);
                            UserInfo.Email = reader.GetString(5);

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
        }
        public ResponseMessageModel UpdateUserProfile(UserModel userModel)
        {
            ResponseMessageModel result = new ResponseMessageModel();
            SqlConnection cnn;
            using (cnn = new SqlConnection(_connectionString))
            {
                cnn.Open();
                try
                {
                    using(SqlCommand cmd = cnn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE UserInfo SET Name = @name,ContactNo = @contactNo,Email=@email WHERE Id=@id";
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = userModel.Id;
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = userModel.Name;
                        cmd.Parameters.Add("@contactNo", SqlDbType.NVarChar).Value = userModel.ContactNo;
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = userModel.Email;

                        int i = cmd.ExecuteNonQuery();

                        if (i != 0)
                        {
                            UserInfo.Name = userModel.Name;
                            UserInfo.ContactNo = userModel.ContactNo;
                            UserInfo.Email = userModel.Email;
                            result.MessageType = MessageType.Success;
                            result.Message = "User profile record updated!";
                        }

                        log.Debug($"Successfully update user profile record");
                    }
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
        public void Logout()
        {
            UserInfo.Name = "";
            UserInfo.UserID = 0;
            UserInfo.Role = "";
            UserInfo.Username = "";
        }
    }
}
