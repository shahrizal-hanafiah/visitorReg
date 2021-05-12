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
using VisitorReg.Lib.WinForm.Enum;
using VisitorReg.Lib.WinForm.Models.Visitor;

namespace VisitorReg.View.Guard
{
    public partial class ListVisitor : Form
    {
        private VisitorService _visitorService = new VisitorService();
        private UserService _userService = new UserService();
        private int PgSize = 20;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0;
        private SqlConnection connection;

        public ListVisitor()
        {
            InitializeComponent();
            var connectionString = Settings.ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        private void ListVisitor_Load(object sender, EventArgs e)
        {
            txtDateFrom.Text = DateTime.Now.Date.ToString();
            txtDateTo.Text = DateTime.Now.Date.ToString();
            txtDateOut.Mask = "00/00/0000";
            this.CurrentPageIndex = 1;
            PopulateTableVisitor(CurrentPageIndex);
            reset();
        }

        private void PopulateTableVisitor(int page)
        {
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataSet ds = new DataSet();
            int i = 0;
            try
            {
                connection.Open();

                int PreviousPageOffSet = page == 1? PgSize : (page - 1) * PgSize;

                //var sql = "select TOP " + PreviousPageOffSet + " ROW_NUMBER() OVER(ORDER BY b.id ASC) AS #,a.Name,a.ICNo as 'IC No.',a.OldICNo as 'Old Ic No.'," +
                var sql = "select TOP " + PreviousPageOffSet + " b.id AS Id,a.Name,a.ICNo as 'IC No.',a.OldICNo as 'Old Ic No.'," +
                      " b.NoPlate as 'Car No. Plate',b.PassNo as 'Pass No.',b.HouseNo as 'House No.',b.PurposeVisit as 'Purpose of visit',b.DateTimeIn as 'Date & Time In'," +
                      " b.DateTimeOut as 'Date & Time Out', b.CreatedDate as 'Created Date',b.CreatedBy as 'Created By' from VisitorInfo a " +
                      " Inner Join Visits b on b.VisitorInfoId = a.Id " +
                      " where b.DateTimeIn between @DateFrom and @DateTo";

                command = new SqlCommand(sql, connection);
                command.Parameters.Add("@DateFrom", SqlDbType.DateTime);
                command.Parameters["@DateFrom"].Value = Convert.ToDateTime(txtDateFrom.Text).ToString("yyyy-MM-dd 00:00:00");
                command.Parameters.Add("@DateTo", SqlDbType.DateTime);
                command.Parameters["@DateTo"].Value = Convert.ToDateTime(txtDateTo.Text).ToString("yyyy-MM-dd 23:59:59");
                adapter.SelectCommand = command;
                ds.Tables.Add("VisitorInfo");
                adapter.Fill(ds, "VisitorInfo");

                TotalPage = ds.Tables[0].Rows.Count;
                dgVisitorList.AutoGenerateColumns = true;
                dgVisitorList.DataSource = ds;
                dgVisitorList.DataMember = "VisitorInfo";

                adapter.Dispose();
                command.Dispose();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can not open visitor list ! Error: {ex.Message}");
            }
        }

        private void linkRegisterVisitor_Click(object sender, EventArgs e)
        {
            var register = new RegisterVisitor();
            register.Show();
            this.Hide();
        }
        private void linkLogout_Click(object sender, EventArgs e)
        {
            _userService.Logout();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = 1;
            PopulateTableVisitor(CurrentPageIndex);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = 1;
            PopulateTableVisitor(CurrentPageIndex);
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPage)
            {
                CurrentPageIndex = 1;
                PopulateTableVisitor(CurrentPageIndex);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                CurrentPageIndex--;
                PopulateTableVisitor(CurrentPageIndex);
            }
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = TotalPage;
            PopulateTableVisitor(CurrentPageIndex);
        }

        private void dgVisitorList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int counter;
            var cell = dgVisitorList.SelectedCells;
            reset();
            for (counter = 0; counter < (cell.Count); counter++)
            {
                if (cell[counter].ColumnIndex == 0)
                {
                    txtId.Text = cell[counter].Value.ToString();
                }
                else if (cell[counter].ColumnIndex == 1)
                {
                    txtVisitorName.Text = cell[counter].Value.ToString();
                }
                else if (cell[counter].ColumnIndex == 8)
                {
                    txtDateTimeIn.Text = cell[counter].Value.ToString();
                }
            }
        }

        private bool Validation()
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Please select 1 record from the table");
                return false;
            }
            else if (txtDateOut.Text.Replace("/", "").Trim().Length <= 7)
            {
                lblDatetimeOutRequired.Show();
                txtDateOut.Focus();
                return false;
            }

            if (cmbHourOut.SelectedIndex < 0 || cmbMinutesOut.SelectedIndex < 0 || cmbPeriodOut.SelectedIndex < 0)
            {
                lblTimeOutRequired.Show();
                cmbHourOut.Focus();
                return false;
            }
            else if (cmbHourOut.SelectedIndex > 0 && cmbMinutesOut.SelectedIndex > 0 && cmbPeriodOut.SelectedIndex > 0)
            {
                lblTimeOutRequired.Hide();
                btnSubmit.Focus();
            }

            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                var visitor = new VisitorModel()
                {
                    Id = Convert.ToInt32(txtId.Text),
                    DateTimeOut = Convert.ToDateTime($"{txtDateOut.Text} {cmbHourOut.SelectedItem}:{cmbMinutesOut.SelectedItem} {cmbPeriodOut.SelectedItem}", new CultureInfo("ms-MY"))
                };
                var result = _visitorService.UpdateDateTimeOut(visitor);
                MessageBox.Show(result.Message, result.MessageType.ToString());
                if(result.MessageType == MessageType.Success)
                {
                    reset();
                }
            }
        }
        private void reset()
        {
            lblTimeOutRequired.Hide();
            lblDatetimeOutRequired.Hide();
            txtVisitorName.Text = "";
            txtDateTimeIn.Text = "";
            txtDateOut.Text = "";
            cmbHourOut.SelectedIndex = -1;
            cmbMinutesOut.SelectedIndex = -1;
            cmbPeriodOut.SelectedIndex = -1;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateTableVisitor(CurrentPageIndex);
        }
    }
}
