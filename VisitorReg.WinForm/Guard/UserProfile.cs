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

namespace VisitorReg.View.Guard
{
    public partial class UserProfile : Form
    {
        private UserService _userService = new UserService();
        public UserProfile()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmLogin = new Login();
            frmLogin.Show();
        }

        private void linkListVisitor_Click(object sender, EventArgs e)
        {
            var listVisitor = new ListVisitor();
            listVisitor.Show();
            this.Hide();
        }

        private void linkDashboard_Click(object sender, EventArgs e)
        {
            var register = new RegisterVisitor();
            register.Show();
            this.Hide();
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void LoadUser()
        {
            txtName.Text = UserInfo.Name;
            txtUsername.Text = UserInfo.Username;
            txtContactNo.Text = UserInfo.ContactNo;
            txtEmail.Text = UserInfo.Email;
            txtRole.Text = UserInfo.Role;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadUser();
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

            if(result.MessageType == MessageType.Success)
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

            if(txtNewPass.Text.Length == 0)
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
    }
}
