using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstEmployees.SelectedIndex > -1)
            {

                Employee emp = (Employee)lstEmployees.SelectedItem;

                double wage = Convert.ToDouble(emp.Wage);
                txtFName.Text = emp.FName;
                txtLName.Text = emp.LName;
                txtPassword.Text = emp.Password;
                txtUserName.Text = emp.UserName;
                txtWage.Text = Convert.ToString(wage);

                if(emp.isAdmin == true)
                {
                    rdbYes.Checked = true;
                }
                else
                {
                    rdbNo.Checked = true;
                }
            }
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            addEmployees();
            addOrders();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            if (txtFName.Text != string.Empty && txtLName.Text != string.Empty && txtPassword.Text != string.Empty && txtUserName.Text != string.Empty && txtWage.Text != string.Empty) {
                bool admin = false;

                if (rdbYes.Checked == true)
                    admin = true;

                string fName = txtFName.Text;
                string LName = txtLName.Text;

                double wage = Convert.ToDouble(txtWage.Text);


                int ret = (int)new dsTableAdapters.QueriesTableAdapter().spAddUpdateDeleteEmployees(0, txtFName.Text, txtLName.Text, txtPassword.Text, admin, wage, txtUserName.Text, false);


                if(ret > 0)
                {
                    reset();
                    addEmployees();
                    MessageBox.Show(fName + " " + LName + " was successfully added.");
                }
                else
                {
                    MessageBox.Show(fName + " " + LName + " has already been added.");
                }
                

                
            }
            else
            {
                MessageBox.Show("Please fill out all of the text boxes.");
            }
            
        }

        private void reset()
        {
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtWage.Text = string.Empty;
            rdbYes.Checked = false;
            rdbNo.Checked = true;
        }

        private void btnUpdateEmplyee_Click(object sender, EventArgs e)
        {
            if (txtFName.Text != string.Empty && txtLName.Text != string.Empty && txtPassword.Text != string.Empty && txtUserName.Text != string.Empty && txtWage.Text != string.Empty)
            {
            

                bool admin = rdbYes.Checked;
                
                
              
                
                try
                {
                    double wage = Convert.ToDouble(txtWage.Text);
                    new dsTableAdapters.QueriesTableAdapter().spAddUpdateDeleteEmployees(-1, txtFName.Text, txtLName.Text, txtPassword.Text, admin, wage, txtUserName.Text, false);

                    //maybe add a message box saying if anything was updated

                    lstEmployees.Items.Clear();
                    addEmployees();
                    reset();
                    MessageBox.Show("Employee updated successfully");
                }
                catch
                {
                    MessageBox.Show("Wage must be in the form XXXX.XX");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all of the text boxes when Updating.");
            }

        }

        private void addEmployees()
        {
            lstEmployees.Items.Clear();

            using (ds.spGetEmployeeWageDataTable tbl = new dsTableAdapters.spGetEmployeeWageTableAdapter().GetData())
            {
                foreach (ds.spGetEmployeeWageRow r in tbl.Rows)
                {
                  
                    lstEmployees.Items.Add(new Employee(r.EmployeeID, r.FName, r.LName, r.Password, r.isAdmin, Convert.ToDouble(r.Wage), r.UserName));
                }
            }
        }

        private void addOrders()
        {
            lstOrders.Items.Clear();

            using (ds.spAllOrdersDataTable tbl = new dsTableAdapters.spAllOrdersTableAdapter().GetData())
            {
                foreach (ds.spAllOrdersRow r in tbl.Rows)
                {
                    

                    lstOrders.Items.Add(new Order(r.OrderID, r.EmployeeID, r.OrderTotal, r.CreditCardNumber, r.CustomerFName, r.CustomerLName));
                }
            }


        }

        private void addSpecialOrders()
        {
            bool paid = rdbPaid.Checked;
            bool deleted = rdbCancelled.Checked;

            lstOrders.Items.Clear();

            using (ds.spGetActiveOrPastOrdersDataTable tbl = new dsTableAdapters.spGetActiveOrPastOrdersTableAdapter().GetData(deleted, paid))
            {
                foreach (ds.spGetActiveOrPastOrdersRow r in tbl.Rows)
                {

                    lstOrders.Items.Add(new Order(r.OrderID, r.EmployeeID, r.OrderTotal, r.CreditCardNumber, r.CustomerFName, r.CustomerLName));
                }
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (lstEmployees.SelectedIndex > -1)
            {
                Employee employee = (Employee)lstEmployees.SelectedItem;
                int ret = 0;

                ret = (int)new dsTableAdapters.QueriesTableAdapter().spAddUpdateDeleteEmployees(employee.EmployeeID, employee.FName, employee.LName, employee.Password, employee.isAdmin, employee.Wage, employee.UserName, true);



                if (ret > -1)
                {
                    lstEmployees.Items.RemoveAt(lstEmployees.SelectedIndex);
                    MessageBox.Show(employee.FName + " " + employee.LName + " was successfully deleted.");
                    reset();
                }
                else
                {
                    MessageBox.Show("Error while trying to delete");
                }
            }else
            {
                MessageBox.Show("Please select an Employee.");
            }
        }

        private void lstOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstOrders.SelectedIndex > -1)
            {
                Order o = (Order)lstOrders.SelectedItem;

                MessageBox.Show(o.ToString());

            }
        }

        private void rdbPaid_CheckedChanged(object sender, EventArgs e)
        {
            addSpecialOrders();
        }

        private void rdbCancelled_CheckedChanged(object sender, EventArgs e)
        {
            addSpecialOrders();
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            addOrders();
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            if (lstOrders.SelectedIndex > -1)
            {
                Order o = (Order)lstOrders.SelectedItem;

                using (ds.spRefundOrderDataTable tbl = new dsTableAdapters.spRefundOrderTableAdapter().GetData(o.OrderID))
                {
                    foreach (ds.spRefundOrderRow r in tbl)
                    {
                        int success = r.success;

                        if (success == 1)
                        {
                            if (rdbCancelled.Checked == true || rdbPaid.Checked == true)
                            {
                                addSpecialOrders();
                            }
                            else
                            {
                                addOrders();
                            }

                            MessageBox.Show(o.customerFName + " " + o.customerLName + "'s Order was refunded for an amount of: " + o.OrderTotal);
                        }
                        else
                        {
                            MessageBox.Show(o.customerFName + " " + o.customerLName + "'s Order has not been paid yet. It cannot be refunded.");
                        }

                    }
                }
            }else
            {
                MessageBox.Show("No order has been selected.");
            }
            
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            using (ds.spGetIncomeDataTable tbl = new dsTableAdapters.spGetIncomeTableAdapter().GetData())
            {
                foreach(ds.spGetIncomeRow r in tbl)
                {
                    decimal income = r.Income;

                    MessageBox.Show("The company has made $" + income);
                }
            }
            
        }

        private void dgbEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
