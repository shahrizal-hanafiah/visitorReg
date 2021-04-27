using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            if(txtUsername.Text.ToLower() == "admin")
            {
                var adminDashboard = new Dashboard();
                adminDashboard.Show();
            }
            else
            {
                var guard = new RegisterVisitor();
                guard.Show();
            }
            this.Hide();
        }
    }
}
