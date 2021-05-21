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
using VisitorReg.Lib.WinForm.Enum;
using VisitorReg.Lib.WinForm.Models.User;
using VisitorReg.View;
using VisitorReg.View.Admin;

namespace VisitorReg.WinForm.Admin
{
    public partial class AdminProfile : Form
    {
        private UserService _userService = new UserService();
        public AdminProfile()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UserModel userModel = new UserModel()
            {
                Id = UserInfo.UserID,
                Name = txtName.Text,
                Email = txtEmail.Text,
                ContactNo = txtContactNo.Text
            };

            var result = _userService.UpdateUserProfile(userModel);

            if (result.MessageType == MessageType.Success)
            {
                LoadUser();
            }

            MessageBox.Show(result.Message, result.MessageType.ToString());
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (validatePassword())
            {
                var result = _userService.UpdatePassword(txtNewPass.Text);
                MessageBox.Show(result.Message, result.MessageType.ToString());
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
                txtOldPass.Text = "";
            }
        }
        private void LoadUser()
        {
            txtName.Text = UserInfo.Name;
            txtUsername.Text = UserInfo.Username;
            txtContactNo.Text = UserInfo.ContactNo;
            txtEmail.Text = UserInfo.Email;
            txtRole.Text = UserInfo.Role;
        }
        private bool validatePassword()
        {
            if (_userService.CurrentPassword(txtOldPass.Text))
            {
                lblWrongPassword.Hide();
            }
            else
            {
                lblWrongPassword.Show();
                return false;
            }

            if (txtNewPass.Text.Length == 0)
            {
                lblNewPassRequired.Show();
                return false;
            }
            else
            {
                lblNewPassRequired.Hide();
            }

            if (txtNewPass.Text != txtConfirmPass.Text)
            {
                lblPassNotMatch.Show();
                return false;
            }
            else
            {
                lblPassNotMatch.Hide();
            }
            return true;
        }

        private void linkManageUsers_Click(object sender, EventArgs e)
        {
            var listVisitor = new ListVisitor();
            listVisitor.Show();
            this.Hide();
        }

        private void linkListVisitor_Click(object sender, EventArgs e)
        {
            var visitorList = new ListVisitor();
            visitorList.Show();
            this.Hide();
        }

        private void menuDashboard_Click(object sender, EventArgs e)
        {
            var dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void linkLogout_Click(object sender, EventArgs e)
        {
            _userService.Logout();
            this.Hide();
            var login = new Login();
            login.Show();
        }
    }
}
