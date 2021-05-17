using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

namespace VisitorReg.WinForm.Admin
{
    public partial class ManageUser : Form
    {
        private UserService _userService = new UserService();
        private int PgSize = 20;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;
        private SqlConnection connection;
        public ManageUser()
        {
            InitializeComponent();
            LoadForm();
            connection = new SqlConnection(Settings.ConnectionString);
        }

        private void ManageUser_Load(object sender, EventArgs e)
        {
            PopulateTableUsers(CurrentPageIndex);
        }

        private void PopulateTableUsers(int page)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                connection.Open();

                int PreviousPageOffSet = page == 1 ? PgSize : (page - 1) * PgSize;
                var sql = "select TOP " + PreviousPageOffSet + " ROW_NUMBER() OVER(ORDER BY id ASC) AS #,Username,Name,Role,ContactNo,Email from UserInfo where role != 'SuperAdmin'";

                command = new SqlCommand(sql, connection);
                adapter.SelectCommand = command;
                ds.Tables.Add("UserInfo");
                adapter.Fill(ds, "UserInfo");

                TotalPage = ds.Tables[0].Rows.Count;
                dgUserList.AutoGenerateColumns = true;
                dgUserList.DataSource = ds;
                dgUserList.DataMember = "UserInfo";

                adapter.Dispose();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can not open user list ! Error: {ex.Message}");
            }
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = 1;
            PopulateTableUsers(CurrentPageIndex);
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {
                CurrentPageIndex = 1;
                PopulateTableUsers(CurrentPageIndex);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                CurrentPageIndex--;
                PopulateTableUsers(CurrentPageIndex);
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = TotalPage;
            PopulateTableUsers(CurrentPageIndex);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateTableUsers(CurrentPageIndex);
        }

        private void linkLogout_Click(object sender, EventArgs e)
        {
            _userService.Logout();
            this.Hide();
            var login = new Login();
            login.Show();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if(txtName.Text.Length <= 0)
            {
                lblNameRequired.Show();
            }
            else
            {
                lblNameRequired.Hide();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length <= 0)
            {
                lblUsernameRequired.Show();
            }
            else
            {
                lblUsernameRequired.Hide();
            }
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRole.SelectedIndex < 0)
            {
                lblRoleRequired.Show();
            }
            else
            {
                lblRoleRequired.Hide();
            }
        }

        private void LoadForm()
        {
            txtName.Text = "";
            txtUsername.Text = "";
            txtEmail.Text = "";
            txtContactNo.Text = "";
            cmbRole.SelectedIndex = 0;
            lblNameRequired.Show();
            lblRoleRequired.Show();
            lblUsernameRequired.Show();
            btnInsert.Text = "Insert";
        }

        private bool Validation()
        {
            if (txtName.Text.Length <= 0)
            {
                lblNameRequired.Show();
                return false;
            }
            else
            {
                lblNameRequired.Hide();
            }

            if (txtUsername.Text.Length <= 0)
            {
                lblUsernameRequired.Show();
                return false;
            }
            else
            {
                lblUsernameRequired.Hide();
            }
            if (cmbRole.SelectedIndex < 0)
            {
                lblRoleRequired.Show();
                return false;
            }
            else
            {
                lblRoleRequired.Hide();
            }
            return true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validation())
                {
                    var newUser = new UserModel()
                    {
                        Name = txtName.Text,
                        Username = txtName.Text,
                        Email = txtEmail.Text,
                        ContactNo = txtContactNo.Text,
                        Role = cmbRole.SelectedItem.ToString()
                    };

                    var result = _userService.Insert(newUser);

                    if (result.MessageType == MessageType.Success)
                    {
                        LoadForm();
                    }

                    MessageBox.Show(result.Message, result.MessageType.ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dgUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int counter;
            var cell = dgUserList.SelectedCells;
            LoadForm();
            
            for (counter = 0; counter < (cell.Count); counter++)
            {
                if (cell[counter].ColumnIndex == 0)
                {
                    txtId.Text = "Update";
                }
                else if (cell[counter].ColumnIndex == 1)
                {
                    txtUsername.Text = cell[counter].Value.ToString();
                    txtUsername.Enabled = false;
                }
                else if (cell[counter].ColumnIndex == 2)
                {
                    txtName.Text = cell[counter].Value.ToString();
                }
                else if (cell[counter].ColumnIndex == 3)
                {
                    cmbRole.SelectedItem = cell[counter].Value.ToString();
                }
                else if (cell[counter].ColumnIndex == 4)
                {
                    txtContactNo.Text = cell[counter].Value.ToString();
                }
                else if (cell[counter].ColumnIndex == 5)
                {
                    txtEmail.Text = cell[counter].Value.ToString();
                }
            }
            btnInsert.Text = "Update";
        }

        private void linkListVisitor_Click(object sender, EventArgs e)
        {

        }

        private void menuDashboard_Click(object sender, EventArgs e)
        {

        }
    }
}
