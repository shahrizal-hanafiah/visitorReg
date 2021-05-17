using LiveCharts;
using LiveCharts.Wpf;
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
using VisitorReg.WinForm.Admin;

namespace VisitorReg.View.Admin
{
    public partial class Dashboard : Form
    {
        private VisitorService _visitorService = new VisitorService();
        private UserService _userService = new UserService();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCountBoard();
                LoadGraph();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
            
        }

        private void LoadGraph()
        {
            cartesianChart1.Series.Clear();
            Random random = new Random();
            SeriesCollection series = new SeriesCollection();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Month",
                Labels = new[] { "Jan","Feb", "Mac", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Total",
                LabelFormatter = value => value.ToString()
            });

            cartesianChart1.LegendLocation = LegendLocation.Right;

            List<int> contractorValues = new List<int>();
            List<int> visitorValues = new List<int>();
            List<int> courierValues = new List<int>();
            List<int> deliveryValues = new List<int>();

            var stats = _visitorService.GetDashboardStats().Where(t => t.Year == DateTime.Now.Year).ToList();

            for (int i = 1; i <= 12; i++)
            {
                var existData = false;
                for (int p = 0; p < stats.Count; p++)
                {
                    if (stats[p].intMonth == i)
                    {
                        contractorValues.Add(stats[p].Contractors);
                        visitorValues.Add(stats[p].Visitors);
                        courierValues.Add(stats[p].Couriers);
                        deliveryValues.Add(stats[p].FoodDeliveries);
                        existData = true;
                    }
                }
                if (!existData)
                {
                    contractorValues.Add(0);
                    visitorValues.Add(0);
                    courierValues.Add(0);
                    deliveryValues.Add(0);
                }
            }

            series.Add(new LineSeries() { Title = "Contractors",Values = new ChartValues<int>(contractorValues) });
            series.Add(new LineSeries() { Title = "Visitor", Values = new ChartValues<int>(visitorValues) });
            series.Add(new LineSeries() { Title = "Courier", Values = new ChartValues<int>(courierValues) });
            series.Add(new LineSeries() { Title = "Food Delivery", Values = new ChartValues<int>(deliveryValues) });
            cartesianChart1.Series = series;
        }

        private void LoadCountBoard()
        {
            var stats = _visitorService.GetDashboardStats().Where(t => t.Month == DateTime.Now.ToString("MMMM") && t.Year == DateTime.Now.Year).FirstOrDefault();
            if (stats!= null)
            {
                lblVisitorCount.Text = stats.Visitors.ToString();
                lblContractorCount.Text = stats.Contractors.ToString();
                lblFoodDeliveryCount.Text = stats.FoodDeliveries.ToString();
                lblCouriersCount.Text = stats.Couriers.ToString();
            }
        }

        private void linkListVisitor_Click(object sender, EventArgs e)
        {
            var visitorList = new ListVisitor();
            visitorList.Show();
            this.Hide();
        }

        private void linkLogout_Click(object sender, EventArgs e)
        {
            _userService.Logout();
            this.Hide();
            var login = new Login();
            login.Show();
        }

        private void linkManageUsers_Click(object sender, EventArgs e)
        {
            var manage = new ManageUser();
            manage.Show();
            this.Hide();
        }
    }
}
