
namespace VisitorReg.WinForm.Admin
{
    partial class ManageUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUser));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAdminDashboard = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.linkListVisitor = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.linkLogout = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.linkUserProfile = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.linkAudit = new System.Windows.Forms.PictureBox();
            this.lblManageUser = new System.Windows.Forms.Label();
            this.linkManageUsers = new System.Windows.Forms.PictureBox();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMainNavi = new System.Windows.Forms.Label();
            this.menuDashboard = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgUserList = new System.Windows.Forms.DataGridView();
            this.lblManageUsers = new System.Windows.Forms.Label();
            this.grpPagination = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRoleRequired = new System.Windows.Forms.Label();
            this.lblUsernameRequired = new System.Windows.Forms.Label();
            this.lblNameRequired = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.linkListVisitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkUserProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkAudit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkManageUsers)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgUserList)).BeginInit();
            this.grpPagination.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblAdminDashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1679, 50);
            this.panel1.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(113, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 33);
            this.label7.TabIndex = 9;
            // 
            // lblAdminDashboard
            // 
            this.lblAdminDashboard.AutoSize = true;
            this.lblAdminDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminDashboard.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblAdminDashboard.Location = new System.Drawing.Point(4, 9);
            this.lblAdminDashboard.Name = "lblAdminDashboard";
            this.lblAdminDashboard.Size = new System.Drawing.Size(218, 29);
            this.lblAdminDashboard.TabIndex = 3;
            this.lblAdminDashboard.Text = "AdminVisitorReg";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(72)))), ((int)(((byte)(80)))));
            this.pnlLeft.Controls.Add(this.label23);
            this.pnlLeft.Controls.Add(this.linkListVisitor);
            this.pnlLeft.Controls.Add(this.label9);
            this.pnlLeft.Controls.Add(this.linkLogout);
            this.pnlLeft.Controls.Add(this.label8);
            this.pnlLeft.Controls.Add(this.linkUserProfile);
            this.pnlLeft.Controls.Add(this.label2);
            this.pnlLeft.Controls.Add(this.linkAudit);
            this.pnlLeft.Controls.Add(this.lblManageUser);
            this.pnlLeft.Controls.Add(this.linkManageUsers);
            this.pnlLeft.Controls.Add(this.lblDashboard);
            this.pnlLeft.Controls.Add(this.panel2);
            this.pnlLeft.Controls.Add(this.menuDashboard);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(260, 1024);
            this.pnlLeft.TabIndex = 6;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label23.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label23.Location = new System.Drawing.Point(85, 350);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(73, 17);
            this.label23.TabIndex = 15;
            this.label23.Text = "List Visitor";
            // 
            // linkListVisitor
            // 
            this.linkListVisitor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkListVisitor.Image = ((System.Drawing.Image)(resources.GetObject("linkListVisitor.Image")));
            this.linkListVisitor.Location = new System.Drawing.Point(56, 211);
            this.linkListVisitor.Name = "linkListVisitor";
            this.linkListVisitor.Size = new System.Drawing.Size(135, 136);
            this.linkListVisitor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.linkListVisitor.TabIndex = 16;
            this.linkListVisitor.TabStop = false;
            this.linkListVisitor.Click += new System.EventHandler(this.linkListVisitor_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(99, 985);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Logout";
            // 
            // linkLogout
            // 
            this.linkLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLogout.Image = ((System.Drawing.Image)(resources.GetObject("linkLogout.Image")));
            this.linkLogout.Location = new System.Drawing.Point(56, 858);
            this.linkLogout.Name = "linkLogout";
            this.linkLogout.Size = new System.Drawing.Size(135, 124);
            this.linkLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.linkLogout.TabIndex = 14;
            this.linkLogout.TabStop = false;
            this.linkLogout.Click += new System.EventHandler(this.linkLogout_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(99, 827);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Profile";
            // 
            // linkUserProfile
            // 
            this.linkUserProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkUserProfile.Image = ((System.Drawing.Image)(resources.GetObject("linkUserProfile.Image")));
            this.linkUserProfile.Location = new System.Drawing.Point(56, 700);
            this.linkUserProfile.Name = "linkUserProfile";
            this.linkUserProfile.Size = new System.Drawing.Size(135, 124);
            this.linkUserProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.linkUserProfile.TabIndex = 12;
            this.linkUserProfile.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(82, 668);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Audit Log";
            // 
            // linkAudit
            // 
            this.linkAudit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkAudit.Image = ((System.Drawing.Image)(resources.GetObject("linkAudit.Image")));
            this.linkAudit.Location = new System.Drawing.Point(56, 541);
            this.linkAudit.Name = "linkAudit";
            this.linkAudit.Size = new System.Drawing.Size(135, 124);
            this.linkAudit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.linkAudit.TabIndex = 10;
            this.linkAudit.TabStop = false;
            // 
            // lblManageUser
            // 
            this.lblManageUser.AutoSize = true;
            this.lblManageUser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblManageUser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblManageUser.Location = new System.Drawing.Point(78, 506);
            this.lblManageUser.Name = "lblManageUser";
            this.lblManageUser.Size = new System.Drawing.Size(95, 19);
            this.lblManageUser.TabIndex = 7;
            this.lblManageUser.Text = "Manage User";
            // 
            // linkManageUsers
            // 
            this.linkManageUsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.linkManageUsers.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.linkManageUsers.Image = ((System.Drawing.Image)(resources.GetObject("linkManageUsers.Image")));
            this.linkManageUsers.Location = new System.Drawing.Point(56, 379);
            this.linkManageUsers.Name = "linkManageUsers";
            this.linkManageUsers.Size = new System.Drawing.Size(135, 124);
            this.linkManageUsers.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.linkManageUsers.TabIndex = 8;
            this.linkManageUsers.TabStop = false;
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDashboard.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblDashboard.Location = new System.Drawing.Point(83, 182);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(78, 17);
            this.lblDashboard.TabIndex = 3;
            this.lblDashboard.Text = "Dashboard";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.panel2.Controls.Add(this.lblMainNavi);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 38);
            this.panel2.TabIndex = 4;
            // 
            // lblMainNavi
            // 
            this.lblMainNavi.AutoSize = true;
            this.lblMainNavi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainNavi.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMainNavi.Location = new System.Drawing.Point(53, 11);
            this.lblMainNavi.Name = "lblMainNavi";
            this.lblMainNavi.Size = new System.Drawing.Size(110, 15);
            this.lblMainNavi.TabIndex = 3;
            this.lblMainNavi.Text = "MAIN NAVIGATION";
            // 
            // menuDashboard
            // 
            this.menuDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuDashboard.Image = ((System.Drawing.Image)(resources.GetObject("menuDashboard.Image")));
            this.menuDashboard.Location = new System.Drawing.Point(56, 55);
            this.menuDashboard.Name = "menuDashboard";
            this.menuDashboard.Size = new System.Drawing.Size(135, 124);
            this.menuDashboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.menuDashboard.TabIndex = 4;
            this.menuDashboard.TabStop = false;
            this.menuDashboard.Click += new System.EventHandler(this.menuDashboard_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(260, 1028);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1419, 46);
            this.panel3.TabIndex = 8;
            // 
            // dgUserList
            // 
            this.dgUserList.AllowUserToAddRows = false;
            this.dgUserList.AllowUserToDeleteRows = false;
            this.dgUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgUserList.Location = new System.Drawing.Point(286, 127);
            this.dgUserList.Name = "dgUserList";
            this.dgUserList.RowHeadersWidth = 51;
            this.dgUserList.RowTemplate.Height = 24;
            this.dgUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUserList.Size = new System.Drawing.Size(1252, 532);
            this.dgUserList.TabIndex = 9;
            this.dgUserList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUserList_CellClick);
            // 
            // lblManageUsers
            // 
            this.lblManageUsers.AutoSize = true;
            this.lblManageUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManageUsers.Location = new System.Drawing.Point(280, 73);
            this.lblManageUsers.Name = "lblManageUsers";
            this.lblManageUsers.Size = new System.Drawing.Size(189, 33);
            this.lblManageUsers.TabIndex = 11;
            this.lblManageUsers.Text = "Manage User";
            // 
            // grpPagination
            // 
            this.grpPagination.Controls.Add(this.btnRefresh);
            this.grpPagination.Controls.Add(this.btnLastPage);
            this.grpPagination.Controls.Add(this.btnPrevious);
            this.grpPagination.Controls.Add(this.btnNextPage);
            this.grpPagination.Controls.Add(this.btnFirstPage);
            this.grpPagination.Location = new System.Drawing.Point(286, 674);
            this.grpPagination.Name = "grpPagination";
            this.grpPagination.Size = new System.Drawing.Size(1252, 78);
            this.grpPagination.TabIndex = 12;
            this.grpPagination.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(895, 24);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(109, 37);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Location = new System.Drawing.Point(678, 25);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(109, 37);
            this.btnLastPage.TabIndex = 3;
            this.btnLastPage.Text = "Last Page";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(480, 25);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(109, 37);
            this.btnPrevious.TabIndex = 2;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(285, 24);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(109, 37);
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.Text = "Next Page";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Location = new System.Drawing.Point(98, 24);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(109, 37);
            this.btnFirstPage.TabIndex = 0;
            this.btnFirstPage.Text = "First Page";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRoleRequired);
            this.groupBox2.Controls.Add(this.lblUsernameRequired);
            this.groupBox2.Controls.Add(this.lblNameRequired);
            this.groupBox2.Controls.Add(this.cmbRole);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtContactNo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtUsername);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtId);
            this.groupBox2.Controls.Add(this.btnInsert);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(286, 774);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1252, 220);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New User";
            // 
            // lblRoleRequired
            // 
            this.lblRoleRequired.AutoSize = true;
            this.lblRoleRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleRequired.ForeColor = System.Drawing.Color.Red;
            this.lblRoleRequired.Location = new System.Drawing.Point(498, 146);
            this.lblRoleRequired.Name = "lblRoleRequired";
            this.lblRoleRequired.Size = new System.Drawing.Size(66, 15);
            this.lblRoleRequired.TabIndex = 103;
            this.lblRoleRequired.Text = "* Required";
            // 
            // lblUsernameRequired
            // 
            this.lblUsernameRequired.AutoSize = true;
            this.lblUsernameRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameRequired.ForeColor = System.Drawing.Color.Red;
            this.lblUsernameRequired.Location = new System.Drawing.Point(1165, 28);
            this.lblUsernameRequired.Name = "lblUsernameRequired";
            this.lblUsernameRequired.Size = new System.Drawing.Size(66, 15);
            this.lblUsernameRequired.TabIndex = 102;
            this.lblUsernameRequired.Text = "* Required";
            // 
            // lblNameRequired
            // 
            this.lblNameRequired.AutoSize = true;
            this.lblNameRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameRequired.ForeColor = System.Drawing.Color.Red;
            this.lblNameRequired.Location = new System.Drawing.Point(491, 28);
            this.lblNameRequired.Name = "lblNameRequired";
            this.lblNameRequired.Size = new System.Drawing.Size(66, 15);
            this.lblNameRequired.TabIndex = 101;
            this.lblNameRequired.Text = "* Required";
            // 
            // cmbRole
            // 
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Guard",
            "Admin"});
            this.cmbRole.Location = new System.Drawing.Point(100, 146);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(392, 24);
            this.cmbRole.TabIndex = 5;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 20);
            this.label6.TabIndex = 99;
            this.label6.Text = "Role";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(767, 86);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(392, 34);
            this.txtContactNo.TabIndex = 4;
            this.txtContactNo.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(610, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 97;
            this.label5.Text = "Contact No.";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(767, 25);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(392, 34);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Text = "";
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(611, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 95;
            this.label4.Text = "Username";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 86);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(392, 34);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 93;
            this.label3.Text = "Email";
            // 
            // txtId
            // 
            this.txtId.AutoSize = true;
            this.txtId.Location = new System.Drawing.Point(485, 22);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(0, 17);
            this.txtId.TabIndex = 92;
            this.txtId.Visible = false;
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.ForestGreen;
            this.btnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnInsert.Location = new System.Drawing.Point(995, 158);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(118, 45);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(100, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(392, 34);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 87;
            this.label1.Text = "Name";
            // 
            // ManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1679, 1074);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpPagination);
            this.Controls.Add(this.lblManageUsers);
            this.Controls.Add(this.dgUserList);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManageUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageUser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ManageUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.linkListVisitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkUserProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkAudit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkManageUsers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgUserList)).EndInit();
            this.grpPagination.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAdminDashboard;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.PictureBox linkListVisitor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox linkLogout;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox linkUserProfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox linkAudit;
        private System.Windows.Forms.Label lblManageUser;
        private System.Windows.Forms.PictureBox linkManageUsers;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblMainNavi;
        private System.Windows.Forms.PictureBox menuDashboard;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgUserList;
        private System.Windows.Forms.Label lblManageUsers;
        private System.Windows.Forms.GroupBox grpPagination;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label txtId;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.RichTextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtContactNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblUsernameRequired;
        private System.Windows.Forms.Label lblNameRequired;
        private System.Windows.Forms.Label lblRoleRequired;
    }
}