using System;
using VisitorReg.Lib.WinForm.Models.User;
using System.Data.SqlClient;
using System.Data;
using VisitorReg.Lib.WinForm;
using log4net;

namespace VisitorReg.DAL
{
    public class UserService
    {
        private ILog _logger;
        public UserService(ILog logger)
        {
            _logger = logger;
        }
        public LoginResponseModel Login(LoginUserModel userLogin)
        {
            LoginResponseModel result = new LoginResponseModel();
            string connectionString, sql;
            SqlConnection cnn;
            connectionString = @"Data Source=USD-SQLServer02\SQLSERVER,1433;Database=myDataBase;Trusted_Connection=True;";
            sql = "Select Id,Username,Role from UserInfo Where Username = @Username and Password = @Password";
            using (cnn = new SqlConnection(connectionString))
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
                        }
                        reader.NextResult();
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error($"{ex.Message}");
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
