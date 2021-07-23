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
using VisitorReg.View;
using VisitorReg.View.Guard;

namespace VisitorReg.WinForm.Guard
{
    public partial class OwnerNotes : Form
    {
        private UserService userService = new UserService();
        public OwnerNotes()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void menuDashboard_Click(object sender, EventArgs e)
        {
            var register = new RegisterVisitor();
            register.Show();
            this.Hide();
        }

        private void linkListVisitor_Click(object sender, EventArgs e)
        {
            var listVisitor = new ListVisitor();
            listVisitor.Show();
            this.Hide();
        }

        private void linkProfile_Click(object sender, EventArgs e)
        {
            var profile = new UserProfile();
            profile.Show();
            this.Hide();
        }

        private void linkLogout_Click(object sender, EventArgs e)
        {
            userService.Logout();
            this.Hide();
            var login = new Login();
            login.Show();
        }
    }
}
