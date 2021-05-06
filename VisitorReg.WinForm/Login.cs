using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisitorReg.DAL;
using VisitorReg.Lib.WinForm;
using VisitorReg.Lib.WinForm.Models.User;
using VisitorReg.View.Admin;
using VisitorReg.View.Guard;

namespace VisitorReg.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userService = new UserService();
            var userLogin = new LoginUserModel()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            userService.Login(userLogin);
            
            if(UserInfo.UserID> 0)
            {
                this.Hide();
                if (UserInfo.Role == "SuperAdmin")
                {
                    var adminDashboard = new Dashboard();
                    adminDashboard.Show();
                }
                else if(UserInfo.Role == "Guard")
                {
                    var guard = new RegisterVisitor();
                    guard.Show();
                }
                else
                {
                    this.Show();
                    MessageBox.Show("Something went wrong, couldn't find user's role");
                }
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect");
            }
            
        }
    }
}
