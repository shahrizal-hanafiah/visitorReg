using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisitorReg.View.Guard
{
    public partial class RegisterVisitor : Form
    {
        public RegisterVisitor()
        {
            InitializeComponent();
            OnLoad();
        }

        private void OnLoad()
        {
            txtDateIn.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDateOut.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmbHourIn.SelectedItem = DateTime.Now.ToString("HH");
            cmbMinutesIn.SelectedItem = DateTime.Now.ToString("mm");
            cmbPeriodIn.SelectedItem = DateTime.Now.ToString("tt");
            cmbHourOut.SelectedItem = DateTime.Now.ToString("HH");
            cmbMinutesOut.SelectedItem = DateTime.Now.ToString("mm");
            cmbPeriodOut.SelectedItem = DateTime.Now.ToString("tt");
            txtOthers.Enabled = false;
            lblNameRequired.Hide();
            lblICNoRequired.Hide();
            lblNoPlateRequired.Hide();
            lblPassNoRequired.Hide();
            lblHouseNoRequired.Hide();
            lblPurposeVisitRequired.Hide();
            lblOtherRequired.Hide();
            lblTimeInRequired.Hide();
        }

        private void cmbPurpose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPurpose.SelectedIndex < 0)
            {
                lblPurposeVisitRequired.Show();
                cmbPurpose.Focus();
                return;
            }
            if (cmbPurpose.SelectedItem != null){
                if (cmbPurpose.SelectedItem.ToString() == "Others")
                {
                    txtOthers.ReadOnly = false;
                    txtOthers.Enabled = true;
                }
                else
                {
                    txtOthers.Text = "";
                    txtOthers.ReadOnly = true;
                    txtOthers.Enabled = false;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
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
            txtDateOut.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmbHourIn.SelectedItem = DateTime.Now.ToString("HH");
            cmbMinutesIn.SelectedItem = DateTime.Now.ToString("mm");
            cmbPeriodIn.SelectedItem = DateTime.Now.ToString("tt");
            cmbHourOut.SelectedItem = DateTime.Now.ToString("HH");
            cmbMinutesOut.SelectedItem = DateTime.Now.ToString("mm");
            cmbPeriodOut.SelectedItem = DateTime.Now.ToString("tt");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                MessageBox.Show("Successfully saved visitor record!");
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
            } else if(cmbHourIn.SelectedIndex < 0 || cmbMinutesIn.SelectedIndex < 0 || cmbPeriodIn.SelectedIndex < 0)
            {
                lblTimeInRequired.Show();
                cmbHourIn.Focus();
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
                txtPassNo.Text.ToUpper();
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
        }

        private void cmbHourIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHourIn.SelectedIndex < 0)
            {
                lblTimeInRequired.Show();
                cmbHourIn.Focus();
            }
        }

        private void cmbMinutesIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMinutesIn.SelectedIndex < 0)
            {
                lblTimeInRequired.Show();
                cmbMinutesIn.Focus();
            }
        }

        private void cmbPeriodIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPeriodIn.SelectedIndex < 0)
            {
                lblTimeInRequired.Show();
                cmbPeriodIn.Focus();
            }
        }
    }
}
