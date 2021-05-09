using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
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
    public partial class RegisterVisitor : Form
    {
        private VisitorService visitorService = new VisitorService();
        private UserService userService = new UserService();
        public RegisterVisitor()
        {
            InitializeComponent();
            OnLoad();
        }

        private void OnLoad()
        {
            txtDateIn.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtDateOut.Mask = "00/00/0000";
            cmbHourIn.SelectedItem = DateTime.Now.ToString("HH");
            cmbMinutesIn.SelectedItem = DateTime.Now.ToString("mm");
            cmbPeriodIn.SelectedItem = DateTime.Now.ToString("tt");
            txtOthers.Enabled = false;
            lblNameRequired.Show();
            lblICNoRequired.Show();
            lblNoPlateRequired.Show();
            lblPassNoRequired.Show();
            lblHouseNoRequired.Show();
            lblPurposeVisitRequired.Show();
            lblOtherRequired.Hide();
            lblTimeInRequired.Hide();
            lblTimeOutRequired.Hide();
            lblDatetimeOutRequired.Hide();
        }

        private void cmbPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPurpose.SelectedIndex < 0)
            {
                lblPurposeVisitRequired.Show();
                cmbPurpose.Focus();
                return;
            }
            else
            {
                lblPurposeVisitRequired.Hide();
                if (cmbPurpose.SelectedItem.ToString() == "Others")
                {
                    txtOthers.ReadOnly = false;
                    txtOthers.Enabled = true;
                    lblOtherRequired.Show();
                }
                else
                {
                    txtOthers.Text = "";
                    txtOthers.ReadOnly = true;
                    txtOthers.Enabled = false;
                    lblOtherRequired.Hide();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                DateTime? NullDatetime = null;
                var visitor = new VisitorModel()
                {
                    Name = txtVisitorName.Text,
                    ICNo = txtVisitorIC.Text,
                    ContactNo = txtContactNo.Text,
                    OldICNo = txtVisitorICOld.Text,
                    NoPlate  =txtNoPlate.Text,
                    PassNo = txtPassNo.Text,
                    HouseNo = txtHouseNo.Text,
                    PurposeVisit = cmbPurpose.SelectedItem.ToString() == "Others"?txtOthers.Text:cmbPurpose.SelectedText,
                    DateTimeIn = Convert.ToDateTime($"{txtDateIn.Text} {cmbHourIn.SelectedItem}:{cmbMinutesIn.SelectedItem} {cmbPeriodIn.SelectedItem}", new CultureInfo("ms-MY")),
                    DateTimeOut = cmbHourOut.SelectedIndex > 0 || cmbMinutesOut.SelectedIndex > 0 || cmbPeriodOut.SelectedIndex > 0 ? Convert.ToDateTime($"{txtDateOut.Text} {cmbHourOut.SelectedItem}:{cmbMinutesOut.SelectedItem} {cmbPeriodOut.SelectedItem}", new CultureInfo("ms-MY")) : NullDatetime,
                    CreatedBy = UserInfo.Username,
                    CreateDate = DateTime.Now
                };
                var result = visitorService.Insert(visitor);
                if (result.MessageType == MessageType.Success)
                {
                    Reset();
                }

                MessageBox.Show(result.Message, result.MessageType.ToString());
            }
            else
            {
                MessageBox.Show("Please fill in all required field(s)");
            }
        }

        private bool Validation()
        {
            if (txtVisitorName.Text.Length == 0)
            {
                lblNameRequired.Show();
                txtVisitorName.Focus();
                return false;
            } else if (txtVisitorIC.Text.Length == 0)
            {
                lblICNoRequired.Show();
                txtVisitorIC.Focus();
                return false;
            } else if (txtNoPlate.Text.Length == 0)
            {
                lblNoPlateRequired.Show();
                txtNoPlate.Focus();
                return false;
            } else if (txtPassNo.Text.Length == 0)
            {
                lblPassNoRequired.Show();
                txtPassNo.Focus();
                return false;
            } else if (cmbPurpose.SelectedIndex < 0) 
            {
                lblPurposeVisitRequired.Show();
                cmbPurpose.Focus();
                return false;
            } else if (cmbPurpose.SelectedIndex > 0 && cmbPurpose.SelectedItem.ToString() == "Others" && txtOthers.Text.Length == 0 )
            {
                lblOtherRequired.Show();
                txtOthers.Focus();
                return false;
            } else if (txtHouseNo.Text.Length == 0) 
            {
                lblHouseNoRequired.Show();
                txtHouseNo.Focus();
                return false;
            } else if(txtDateOut.Text.Length > 0 && (cmbHourOut.SelectedIndex < 0 || cmbMinutesOut.SelectedIndex < 0 || cmbPeriodOut.SelectedIndex < 0))
            {
                lblTimeOutRequired.Show();
                cmbHourOut.Focus();
                return false;
            } else if(txtDateOut.Text.Length == 0 && (cmbHourOut.SelectedIndex > 0 || cmbMinutesOut.SelectedIndex > 0 || cmbPeriodOut.SelectedIndex > 0))
            {
                lblDatetimeOutRequired.Show();
                txtDateOut.Focus();
                return false;
            }

            return true;
        }

        private void txtVisitorName_TextChanged(object sender, EventArgs e)
        {
            if (txtVisitorName.Text.Length == 0)
            {
                lblNameRequired.Show();
                txtVisitorName.Focus();
            }
            else
            {
                lblNameRequired.Hide();
            }
        }

        private void txtVisitorIC_TextChanged(object sender, EventArgs e)
        {
            if (txtVisitorIC.Text.Length == 0)
            {
                lblICNoRequired.Show();
                txtVisitorIC.Focus();
            }
            else
            {
                lblICNoRequired.Hide();
                txtVisitorIC.Text.ToUpper();
            }
        }

        private void txtNoPlate_TextChanged(object sender, EventArgs e)
        {
            if (txtNoPlate.Text.Length == 0)
            {
                lblNoPlateRequired.Show();
                txtNoPlate.Focus();
            }
            else
            {
                txtNoPlate.Text = txtNoPlate.Text.ToUpper();
                txtNoPlate.SelectionStart = txtNoPlate.Text.Length;
                txtNoPlate.SelectionLength = 0;
                lblNoPlateRequired.Hide();
            }
        }

        private void txtPassNo_TextChanged(object sender, EventArgs e)
        {
            if (txtPassNo.Text.Length == 0)
            {
                lblPassNoRequired.Show();
                txtPassNo.Focus();
            }
            else
            {
                txtPassNo.Text = txtPassNo.Text.ToUpper();
                txtPassNo.SelectionStart = txtPassNo.Text.Length;
                txtPassNo.SelectionLength = 0;
                lblPassNoRequired.Hide();
            }
        }

        private void txtHouseNo_TextChanged(object sender, EventArgs e)
        {
            if (txtHouseNo.Text.Length == 0)
            {
                lblHouseNoRequired.Show();
                txtHouseNo.Focus();
            }
            else
            {
                lblHouseNoRequired.Hide();
                txtHouseNo.Text.ToUpper();
            }
        }

        private void txtOthers_TextChanged(object sender, EventArgs e)
        {
            if (txtOthers.Text.Length == 0)
            {
                lblOtherRequired.Show();
                txtOthers.Focus();
                return;
            }
            else
            {
                lblOtherRequired.Hide();
            }
        }

        private void cmbHourIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHourIn.SelectedIndex < 0)
            {
                lblTimeInRequired.Show();
                cmbHourIn.Focus();
            }
            else
            {
                lblTimeInRequired.Hide();
            }
        }

        private void cmbMinutesIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMinutesIn.SelectedIndex < 0)
            {
                lblTimeInRequired.Show();
                cmbMinutesIn.Focus();
            }
            else
            {
                lblTimeInRequired.Hide();
            }
        }

        private void cmbPeriodIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPeriodIn.SelectedIndex < 0)
            {
                lblTimeInRequired.Show();
                cmbPeriodIn.Focus();
            }
            else
            {
                lblTimeInRequired.Hide();
            }
        }

        private void txtDateOut_TextChanged(object sender, EventArgs e)
        {
        }

        private void Reset()
        {
            txtVisitorName.Text = "";
            txtVisitorIC.Text = "";
            txtContactNo.Text = "";
            txtVisitorICOld.Text = "";
            txtNoPlate.Text = "";
            txtPassNo.Text = "";
            txtHouseNo.Text = "";
            cmbPurpose.SelectedIndex = -1;
            txtOthers.Text = "";
            txtOthers.ReadOnly = true;
            txtOthers.Enabled = false;
            txtDateIn.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmbHourIn.SelectedItem = DateTime.Now.ToString("HH");
            cmbMinutesIn.SelectedItem = DateTime.Now.ToString("mm");
            cmbPeriodIn.SelectedItem = DateTime.Now.ToString("tt");
            lblTimeOutRequired.Hide();
            lblDatetimeOutRequired.Hide();
        }

        private void linkLogout_Click(object sender, EventArgs e)
        {
            userService.Logout();
            this.Hide();
            var login = new Login();
            login.Show();
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

        private void btnReadMyKad_Click(object sender, EventArgs e)
        {
            ReadMyKad();
        }

        private void ReadMyKad()
        {
            Process proc = null;
            try
            {
                string batDir = string.Format(Settings.ReaderSettings);
                proc = new Process();
                proc.StartInfo.WorkingDirectory = batDir;
                proc.StartInfo.FileName = "automatic_reader.bat";
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
                readOutput();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }
        private void readOutput()
        {
            var textFile = Settings.ReaderSettings + "\\output.txt";
            if (File.Exists(textFile))
            {
                string[] lines = File.ReadAllLines(textFile);
                foreach (string line in lines)
                {
                    var test = line.Substring(0, 5);
                    if (line.Length > 5 && line.Substring(0, 5) == "Name:")
                    {
                        txtVisitorName.Text = line.Substring(6, line.Length-6).Trim();
                    }
                }
            }
        }
    }
}
