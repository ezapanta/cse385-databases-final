namespace WindowsFormsApplication1
{
    partial class frmSettings
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
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.txtWage = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.rdbYes = new System.Windows.Forms.RadioButton();
            this.lbAdmin = new System.Windows.Forms.Label();
            this.lbWage = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbLName = new System.Windows.Forms.Label();
            this.lbFName = new System.Windows.Forms.Label();
            this.btnUpdateEmplyee = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.lstEmployees = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRefund = new System.Windows.Forms.Button();
            this.btnIncome = new System.Windows.Forms.Button();
            this.lbTypes = new System.Windows.Forms.Label();
            this.rdbCancelled = new System.Windows.Forms.RadioButton();
            this.rdbPaid = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.lstOrders = new System.Windows.Forms.ListBox();
            this.employeeBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 537);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtUserName);
            this.tabPage1.Controls.Add(this.lbUserName);
            this.tabPage1.Controls.Add(this.txtWage);
            this.tabPage1.Controls.Add(this.txtLName);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.txtFName);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.lbWage);
            this.tabPage1.Controls.Add(this.lbPassword);
            this.tabPage1.Controls.Add(this.lbLName);
            this.tabPage1.Controls.Add(this.lbFName);
            this.tabPage1.Controls.Add(this.btnUpdateEmplyee);
            this.tabPage1.Controls.Add(this.btnAddEmployee);
            this.tabPage1.Controls.Add(this.btnDeleteEmployee);
            this.tabPage1.Controls.Add(this.lstEmployees);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Employees";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(192, 364);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(163, 20);
            this.txtUserName.TabIndex = 15;
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.Location = new System.Drawing.Point(85, 362);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(93, 20);
            this.lbUserName.TabIndex = 14;
            this.lbUserName.Text = "User Name:";
            // 
            // txtWage
            // 
            this.txtWage.Location = new System.Drawing.Point(517, 306);
            this.txtWage.Name = "txtWage";
            this.txtWage.Size = new System.Drawing.Size(163, 20);
            this.txtWage.TabIndex = 13;
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(517, 256);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(163, 20);
            this.txtLName.TabIndex = 12;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(192, 308);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(163, 20);
            this.txtPassword.TabIndex = 11;
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(192, 256);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(163, 20);
            this.txtFName.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbNo);
            this.panel1.Controls.Add(this.rdbYes);
            this.panel1.Controls.Add(this.lbAdmin);
            this.panel1.Location = new System.Drawing.Point(415, 345);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 66);
            this.panel1.TabIndex = 9;
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.Checked = true;
            this.rdbNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNo.Location = new System.Drawing.Point(184, 19);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(47, 24);
            this.rdbNo.TabIndex = 10;
            this.rdbNo.TabStop = true;
            this.rdbNo.Text = "No";
            this.rdbNo.UseVisualStyleBackColor = true;
            // 
            // rdbYes
            // 
            this.rdbYes.AutoSize = true;
            this.rdbYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbYes.Location = new System.Drawing.Point(102, 19);
            this.rdbYes.Name = "rdbYes";
            this.rdbYes.Size = new System.Drawing.Size(55, 24);
            this.rdbYes.TabIndex = 9;
            this.rdbYes.Text = "Yes";
            this.rdbYes.UseVisualStyleBackColor = true;
            // 
            // lbAdmin
            // 
            this.lbAdmin.AutoSize = true;
            this.lbAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAdmin.Location = new System.Drawing.Point(23, 19);
            this.lbAdmin.Name = "lbAdmin";
            this.lbAdmin.Size = new System.Drawing.Size(63, 20);
            this.lbAdmin.TabIndex = 8;
            this.lbAdmin.Text = "Admin?";
            // 
            // lbWage
            // 
            this.lbWage.AutoSize = true;
            this.lbWage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWage.Location = new System.Drawing.Point(446, 306);
            this.lbWage.Name = "lbWage";
            this.lbWage.Size = new System.Drawing.Size(55, 20);
            this.lbWage.TabIndex = 7;
            this.lbWage.Text = "Wage:";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(96, 308);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(82, 20);
            this.lbPassword.TabIndex = 6;
            this.lbPassword.Text = "Password:";
            // 
            // lbLName
            // 
            this.lbLName.AutoSize = true;
            this.lbLName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLName.Location = new System.Drawing.Point(411, 256);
            this.lbLName.Name = "lbLName";
            this.lbLName.Size = new System.Drawing.Size(90, 20);
            this.lbLName.TabIndex = 5;
            this.lbLName.Text = "Last Name:";
            // 
            // lbFName
            // 
            this.lbFName.AutoSize = true;
            this.lbFName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFName.Location = new System.Drawing.Point(88, 254);
            this.lbFName.Name = "lbFName";
            this.lbFName.Size = new System.Drawing.Size(90, 20);
            this.lbFName.TabIndex = 4;
            this.lbFName.Text = "First Name:";
            // 
            // btnUpdateEmplyee
            // 
            this.btnUpdateEmplyee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateEmplyee.Location = new System.Drawing.Point(282, 432);
            this.btnUpdateEmplyee.Name = "btnUpdateEmplyee";
            this.btnUpdateEmplyee.Size = new System.Drawing.Size(180, 73);
            this.btnUpdateEmplyee.TabIndex = 3;
            this.btnUpdateEmplyee.Text = "Update";
            this.btnUpdateEmplyee.UseVisualStyleBackColor = true;
            this.btnUpdateEmplyee.Click += new System.EventHandler(this.btnUpdateEmplyee_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEmployee.Location = new System.Drawing.Point(6, 432);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(180, 73);
            this.btnAddEmployee.TabIndex = 2;
            this.btnAddEmployee.Text = "Add";
            this.btnAddEmployee.UseVisualStyleBackColor = true;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteEmployee.Location = new System.Drawing.Point(566, 432);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(180, 73);
            this.btnDeleteEmployee.TabIndex = 1;
            this.btnDeleteEmployee.Text = "Delete ";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // lstEmployees
            // 
            this.lstEmployees.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEmployees.FormattingEnabled = true;
            this.lstEmployees.HorizontalScrollbar = true;
            this.lstEmployees.ItemHeight = 16;
            this.lstEmployees.Location = new System.Drawing.Point(6, 6);
            this.lstEmployees.Name = "lstEmployees";
            this.lstEmployees.Size = new System.Drawing.Size(740, 212);
            this.lstEmployees.TabIndex = 0;
            this.lstEmployees.SelectedIndexChanged += new System.EventHandler(this.lstEmployees_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnRefund);
            this.tabPage2.Controls.Add(this.btnIncome);
            this.tabPage2.Controls.Add(this.lbTypes);
            this.tabPage2.Controls.Add(this.rdbCancelled);
            this.tabPage2.Controls.Add(this.rdbPaid);
            this.tabPage2.Controls.Add(this.rdbAll);
            this.tabPage2.Controls.Add(this.lstOrders);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Orders";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRefund
            // 
            this.btnRefund.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefund.Location = new System.Drawing.Point(416, 438);
            this.btnRefund.Name = "btnRefund";
            this.btnRefund.Size = new System.Drawing.Size(330, 67);
            this.btnRefund.TabIndex = 6;
            this.btnRefund.Text = "Refund";
            this.btnRefund.UseVisualStyleBackColor = true;
            this.btnRefund.Click += new System.EventHandler(this.btnRefund_Click);
            // 
            // btnIncome
            // 
            this.btnIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncome.Location = new System.Drawing.Point(6, 438);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(330, 67);
            this.btnIncome.TabIndex = 5;
            this.btnIncome.Text = "Get Income of Restaurant";
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // lbTypes
            // 
            this.lbTypes.AutoSize = true;
            this.lbTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTypes.Location = new System.Drawing.Point(2, 394);
            this.lbTypes.Name = "lbTypes";
            this.lbTypes.Size = new System.Drawing.Size(257, 20);
            this.lbTypes.TabIndex = 4;
            this.lbTypes.Text = "What Orders would you like to see?";
            // 
            // rdbCancelled
            // 
            this.rdbCancelled.AutoSize = true;
            this.rdbCancelled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbCancelled.Location = new System.Drawing.Point(389, 390);
            this.rdbCancelled.Name = "rdbCancelled";
            this.rdbCancelled.Size = new System.Drawing.Size(97, 24);
            this.rdbCancelled.TabIndex = 3;
            this.rdbCancelled.Text = "Cancelled";
            this.rdbCancelled.UseVisualStyleBackColor = true;
            this.rdbCancelled.CheckedChanged += new System.EventHandler(this.rdbCancelled_CheckedChanged);
            // 
            // rdbPaid
            // 
            this.rdbPaid.AutoSize = true;
            this.rdbPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPaid.Location = new System.Drawing.Point(325, 390);
            this.rdbPaid.Name = "rdbPaid";
            this.rdbPaid.Size = new System.Drawing.Size(58, 24);
            this.rdbPaid.TabIndex = 2;
            this.rdbPaid.Text = "Paid";
            this.rdbPaid.UseVisualStyleBackColor = true;
            this.rdbPaid.CheckedChanged += new System.EventHandler(this.rdbPaid_CheckedChanged);
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Checked = true;
            this.rdbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbAll.Location = new System.Drawing.Point(275, 390);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(44, 24);
            this.rdbAll.TabIndex = 1;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "All";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
            // 
            // lstOrders
            // 
            this.lstOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstOrders.FormattingEnabled = true;
            this.lstOrders.HorizontalScrollbar = true;
            this.lstOrders.ItemHeight = 20;
            this.lstOrders.Location = new System.Drawing.Point(6, 6);
            this.lstOrders.Name = "lstOrders";
            this.lstOrders.Size = new System.Drawing.Size(740, 364);
            this.lstOrders.TabIndex = 0;
            this.lstOrders.SelectedIndexChanged += new System.EventHandler(this.lstOrders_SelectedIndexChanged);
            // 
            // employeeBindingSource1
            // 
            this.employeeBindingSource1.DataSource = typeof(WindowsFormsApplication1.Employee);
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(WindowsFormsApplication1.Employee);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.ListBox lstEmployees;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lbFName;
        private System.Windows.Forms.Button btnUpdateEmplyee;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.TextBox txtWage;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.RadioButton rdbYes;
        private System.Windows.Forms.Label lbAdmin;
        private System.Windows.Forms.Label lbWage;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbLName;
        private System.Windows.Forms.ListBox lstOrders;
        private System.Windows.Forms.Button btnRefund;
        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.Label lbTypes;
        private System.Windows.Forms.RadioButton rdbCancelled;
        private System.Windows.Forms.RadioButton rdbPaid;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private System.Windows.Forms.BindingSource employeeBindingSource1;
    }
}