using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisitorReg.DAL;
using VisitorReg.Lib.WinForm;

namespace VisitorReg.View.Guard
{
    public partial class ListVisitor : Form
    {
        private VisitorService visitorService = new VisitorService();
        private UserService userService = new UserService();
        public ListVisitor()
        {
            InitializeComponent();
        }

        

        private void ListVisitor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'visitorRegDataSet.VisitorInfo' table. You can move, or remove it, as needed.
            string connetionString = null;
            SqlConnection connection;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;

            connetionString = Settings.ConnectionString;
            var sql = "select ROW_NUMBER() OVER(ORDER BY id ASC) AS #,* from VisitorInfo where DateIn between @DateFrom and @DateTo";

            connection = new SqlConnection(connetionString);

            try
            {
                connection.Open();
                command = new SqlCommand(sql, connection);
                command.Parameters.Add("@DateFrom", SqlDbType.DateTime);
                command.Parameters["@DateFrom"].Value = txtDateFrom.Text;
                command.Parameters.Add("@DateTo", SqlDbType.DateTime);
                command.Parameters["@DateTo"].Value = txtDateTo.Text;
                adapter.SelectCommand = command;
                ds.Tables.Add("VisitorInfo");
                adapter.Fill(ds, "VisitorInfo");

                dgVisitorList.AutoGenerateColumns = true;
                dgVisitorList.DataSource = ds;
                dgVisitorList.DataMember = "VisitorInfo";

                adapter.Dispose();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }

        }

        private void linkRegisterVisitor_Click(object sender, EventArgs e)
        {
            this.Hide();
            var register = new RegisterVisitor();
            register.Show();
        }
        private void linkLogout_Click(object sender, EventArgs e)
        {
            userService.Logout();
            this.Hide();
            var login = new Login();
            login.Show();
        }

        private void linkProfile_Click(object sender, EventArgs e)
        {
            var profile = new UserProfile();
            profile.Show();
            this.Hide();
        }
    }
}
