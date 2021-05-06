using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorReg.Lib.WinForm;
using VisitorReg.Lib.WinForm.Models.User;

namespace VisitorReg.DAL
{
    public class UserService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UserService));
        public void Login(LoginUserModel userLogin)
        {
            LoginResponseModel result = new LoginResponseModel();
            string connectionString, sql;
            SqlConnection cnn;
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["VisitorRegDB"].ConnectionString;
            sql = "Select Id,Username,Name,Role from UserInfo Where Username = @Username and Password = @Password";
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
        public void Logout()
        {
            UserInfo.Name = "";
            UserInfo.UserID = 0;
            UserInfo.Role = "";
            UserInfo.Username = "";
        }
    }
}
