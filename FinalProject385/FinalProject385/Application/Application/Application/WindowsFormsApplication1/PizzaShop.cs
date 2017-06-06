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
    public partial class frmPizzaShop : Form
    {


        public frmPizzaShop()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //retrieve order
            addOrders();
        }

        private void addOrders()
        {
            lstOrders.Items.Clear();
            using (ds.spGetActiveOrPastOrdersDataTable tbl = new dsTableAdapters.spGetActiveOrPastOrdersTableAdapter().GetData(false, false))
            {
                foreach (ds.spGetActiveOrPastOrdersRow r in tbl.Rows)
                {
                    lstOrders.Items.Add(new Order(r.OrderID, r.EmployeeID, r.OrderTotal, r.CreditCardNumber, r.CustomerFName, r.CustomerLName));
                }
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {

        }



        private void tabPage1_Click(object sender, EventArgs e)
        {


        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbSize_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmitEmployees_Click(object sender, EventArgs e)
        {

            using (ds.spEmployeeLoginDataTable tbl = new dsTableAdapters.spEmployeeLoginTableAdapter().GetData(txtUserName.Text, txtPassword.Text))
            {

                if (tbl.Rows.Count > 0)
                {
                    ds.spEmployeeLoginRow row = (ds.spEmployeeLoginRow)tbl.Rows[0];


                    Employee.currentLoginUser = row.EmployeeID;
                    bool Admin = row.isAdmin;

                    if (Employee.currentLoginUser > 0)
                    {
                        btnLogout.Enabled = true;

                        if (Admin == true)
                        {
                            btnSettings.Enabled = true;
                        }

                        //clear the text boxes
                        txtUserName.Text = String.Empty;
                        txtPassword.Text = String.Empty;
                        btnEnterName.Enabled = true;

                        MessageBox.Show("Successful Login");

                    } 
                }
                else
                {
                    MessageBox.Show("Invalid Login");
                }
            }
        }

        private void txtEmployeeID_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
            frm.Dispose();

        }

        private void listBoxOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstOrders.SelectedIndex > -1)
            {
                Order o = (Order)lstOrders.SelectedItem;
               
                MessageBox.Show(o.ToString());
                
            }
            
        }

        private void btnOrderPaid_Click(object sender, EventArgs e)
        {
            if (lstOrders.SelectedIndex > -1)
            {
                Order o = (Order)lstOrders.SelectedItem;

                new dsTableAdapters.QueriesTableAdapter().spOrderPaid(o.OrderID, true);


                lstOrders.Items.RemoveAt(lstOrders.SelectedIndex);

            }else
            {
                MessageBox.Show("No Order has been selected.");
            }



        }

        private void OrderCancelled_Click(object sender, EventArgs e)
        {
            if (lstOrders.SelectedIndex > -1)
            {

                Order o = (Order)lstOrders.SelectedItem;

                new dsTableAdapters.QueriesTableAdapter().spOrderCancelled(o.OrderID, true);

                lstOrders.Items.RemoveAt(lstOrders.SelectedIndex);
            }
            else
            {
                MessageBox.Show("No Order has been selected.");
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            btnSettings.Enabled = false;
            btnLogout.Enabled = false;
            txtUserName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            btnEnterName.Enabled = false;
            Employee.currentLoginUser = 0;
        }

        private void btnEnterName_Click(object sender, EventArgs e)
        {
            bool tempBool = false;
            string tempCC = "Cash";
            double tempTotal = 0;


            using (ds.spAddOrderDataTable tbl = new dsTableAdapters.spAddOrderTableAdapter().GetData(Employee.currentLoginUser, tempTotal, tempCC, txtCustomerFName.Text, txtCusomterLName.Text, tempBool, tempBool))
            {
                if (tbl.Rows.Count > 0)
                {
                    Order.currentOrder = Convert.ToInt32(Convert.ToString(tbl.Rows[0][0]));
                    lblTotalCost.Text = "$6.00";        //DEFAULT value of 6.00 for small cheese pizza
                }
                txtCusomterLName.Text = string.Empty;
                txtCustomerFName.Text = string.Empty;
                pnlAnchovies.Enabled = true;
                pnlBacon.Enabled = true;
                pnlBlackOlives.Enabled = true;
                pnlBP.Enabled = true;
                pnlGreenOlives.Enabled = true;
                pnlGreenPeppers.Enabled = true;
                pnlHam.Enabled = true;
                pnlJalapenos.Enabled = true;
                pnlMushrooms.Enabled = true;
                pnlOnions.Enabled = true;
                pnlPepperoni.Enabled = true;
                pnlPineapple.Enabled = true;
                pnlSausage.Enabled = true;
                pnlSize.Enabled = true;
                pnlSpinach.Enabled = true;
                pnlTomato.Enabled = true;
                btnEnterName.Enabled = false;
                btnAddPizza.Enabled = true;
                btnScrap.Enabled = true;

            }



        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddPizza_Click(object sender, EventArgs e)
        {
            //determines the size
            int size = 1;

            if (rdbMd.Checked == true)
            {
                size = 2;
            }
            if (rdbLg.Checked == true)
            {
                size = 3;
            }


            //creates the pizza  
            int pizzaID = 0;
                      
            using (ds.spAddPizzaDataTable tbl = new dsTableAdapters.spAddPizzaTableAdapter().GetData(Order.currentOrder, size, 0.00))
            {
                if (tbl.Rows.Count > 0)
                {
                    pizzaID = Convert.ToInt32(Convert.ToString(tbl.Rows[0][0]));
                }
            }


                //gets prices of each of the toppings
            double anchovies = 0;
            double pepperoni = 0;
            double sausage = 0;
            double bacon = 0;
            double onions = 0;
            double pineapple = 0;
            double ham = 0;
            double gp = 0;
            double BO = 0;
            double GO = 0;
            double spinach = 0;
            double mush = 0;
            double tomato = 0;
            double BP = 0;
            double jalapeno = 0;


            if (rdbAddPepperoni.Checked == true)
            {
                pepperoni = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Pepperoni");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(1, pizzaID);
            }

            if (rdbAddSasuage.Checked == true)
            {
                sausage = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Sausage");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(2, pizzaID);
            }

            if (rdbAddBacon.Checked == true)
            {
                bacon = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Bacon");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(3, pizzaID);
            }

            if (rdbAddHam.Checked == true)
            {
                ham = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Ham");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(4, pizzaID);
            }

            if (rdbAddPineapple.Checked == true)
            {
                pineapple = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Pineapple");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(5, pizzaID);
            }

            if (rdbAddGreenPeppers.Checked == true)
            {

                gp = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Green Peppers");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(6, pizzaID);
            }

            if (rdbAddOnions.Checked == true)
            {
                onions = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Onions");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(7, pizzaID);
            }

            if (rdbAddBlackOlives.Checked == true)
            {
                BO = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Black Olives");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(8, pizzaID);
            }

            if (rdbAddGreenOlives.Checked == true)
            {
                GO = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Green Olives");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(9, pizzaID);
            }

            if (rdbAddAnchovies.Checked == true)
            {
                anchovies = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Anchovies");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(10, pizzaID);
            }

            if (rdbAddSpinach.Checked == true)
            {
                spinach = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Spinach");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(11, pizzaID);
            }

            if (rdbAddMushrooms.Checked == true)
            {
                mush = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Mushrooms");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(12, pizzaID);
            }

            if (rdbAddTomato.Checked == true)
            {
                tomato = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Tomato");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(13, pizzaID);
            }

            if (rdbAddBanana.Checked == true)
            {
                BP = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Banana Peppers");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(14, pizzaID);
            }

            if (rdbAddJalapenos.Checked == true)
            {
                jalapeno = (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Jalapenos");
                new dsTableAdapters.QueriesTableAdapter().spAddTopping(15, pizzaID);
            }

            //add all of the toppings that are currently there
            double pizzaamount = Convert.ToDouble(new dsTableAdapters.QueriesTableAdapter().spGetSizeCost(size));

            double orderTotal = pizzaamount + anchovies + pepperoni + bacon + sausage + ham + pineapple + gp + onions + BO + GO + spinach + mush + tomato + BP + jalapeno;

            int orderID = Order.currentOrder;

            //update the total orders cost
            new dsTableAdapters.QueriesTableAdapter().spUpdateOrderTotal(orderID, orderTotal);

            //update the amount the pziza costs
            new dsTableAdapters.QueriesTableAdapter().spUpdatePizzaPrice(pizzaID, orderTotal);

            MessageBox.Show("Pizza Added!");

            getPizzas();
            resetPizzaPage();
        }

        private void setPrice()
        {
                int size = 1;

                if (rdbMd.Checked == true)
                {
                    size = 2;
                }
                if (rdbLg.Checked == true)
                {
                    size = 3;
                }

                double pizzaamount = Convert.ToDouble(new dsTableAdapters.QueriesTableAdapter().spGetSizeCost(size));

                if (rdbAddAnchovies.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Anchovies");

                }

                if (rdbAddPepperoni.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Pepperoni");

                }

                if (rdbAddSasuage.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Sausage");
                }

                if (rdbAddBacon.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Bacon");
                }

                if (rdbAddHam.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Ham");
                }

                if (rdbAddPineapple.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Pineapple");
                }

                if (rdbAddGreenPeppers.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Green Peppers");
                }

                if (rdbAddOnions.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Onions");
                }

                if (rdbAddBlackOlives.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Black Olives");
                }

                if (rdbAddGreenOlives.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Green Olives");
                }

                if (rdbAddSpinach.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Spinach");
                }

                if (rdbAddMushrooms.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Mushrooms");
                }

                if (rdbAddTomato.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Tomato");
                }

                if (rdbAddBanana.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Banana Peppers");
                }

                if (rdbAddJalapenos.Checked == true)
                {
                    pizzaamount = pizzaamount + (double)new dsTableAdapters.QueriesTableAdapter().spGetToppingPrice("Jalapenos");
                }

                lblTotalCost.Text = "$" + String.Format("{0:0.00}", pizzaamount);

            }

        private void lstPizzas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void getPizzas()
        {

            lstPizzas.Items.Clear();

            //adding to the Pizzas list
            using (ds.spGetPizzasDataTable tblP = new dsTableAdapters.spGetPizzasTableAdapter().GetData(Order.currentOrder))
            {
                foreach (ds.spGetPizzasRow row in tblP.Rows)
                {
                    int PizzaID = row.PizzaID;
                    string[] toppings = new string[15];

                    using (ds.spGetToppingsDataTable tblT = new dsTableAdapters.spGetToppingsTableAdapter().GetData(PizzaID))
                    {
                        int i = 0;

                        foreach (ds.spGetToppingsRow r in tblT.Rows)
                        {
                            toppings[i] = r.ToppingName;
                            //if there are no toppings, state Cheese
                           
                            i = i + 1;
                        }

                        if (toppings[0] == null)
                        {
                            toppings[0] = "Cheese";
                        }

                    }

                    lstPizzas.Items.Add(new Pizza(row.PizzaID, row.Size, toppings, row.Price));

                }
            }
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            if (lstPizzas.Items.Count > 0)
            {
                double total = Convert.ToDouble(new dsTableAdapters.QueriesTableAdapter().spGetOrderTotal(Order.currentOrder));

                MessageBox.Show("The current Order Total will be: $" + total);
            }
            else
            {
                MessageBox.Show("There is nothing on the order.");
            }
        }

        private void btnRemovePizza_Click(object sender, EventArgs e)
        {
            if (lstPizzas.SelectedIndex > -1)
            {
                Pizza p = (Pizza)(lstPizzas.SelectedItem);
                int ret = 0;
                ret = (int)new dsTableAdapters.QueriesTableAdapter().spDeletePizza(p.pizzaID);

                if (ret > 0)
                {
                    lstPizzas.Items.RemoveAt(lstPizzas.SelectedIndex);
                    MessageBox.Show(p.size + " pizza was deleted.");
                    
                }
                else
                {
                    MessageBox.Show("An error has occurred.");
                }
            }else
            {
                MessageBox.Show("There is nothing to remove or nothing has been selected.");
            }
        }

        private void btnScrap_Click(object sender, EventArgs e)
        {
            
            int ret = (int)new dsTableAdapters.QueriesTableAdapter().spDeleteOrder(Order.currentOrder);

            if(ret > 0)
            {
                orderReset();
            }
            else
            {
                MessageBox.Show("The order still has pizzas on it and cannot be scrapped.");
            }
        }

        private void radioButton28_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            string cc = txtCreditCard.Text;
            if(txtCreditCard.Text == string.Empty)
            {
                cc = "Cash";
            }   

           int ret = (int) new dsTableAdapters.QueriesTableAdapter().spUpdateCC(Order.currentOrder, cc);

            if(ret > 0)
            {
                orderReset();
                addOrders(); 
            }
            else
            {
                MessageBox.Show("There are no pizzas on this order.");
            }
        }

        private void orderReset()
        {
            MessageBox.Show("The Order will now start over");
            txtCreditCard.Text = string.Empty;
            txtCusomterLName.Text = string.Empty;
            txtCustomerFName.Text = string.Empty;
            btnEnterName.Enabled = true;
            pnlAnchovies.Enabled = false;
            pnlBacon.Enabled = false;
            pnlBlackOlives.Enabled = false;
            pnlBP.Enabled = false;
            pnlGreenOlives.Enabled = false;
            pnlGreenPeppers.Enabled = false;
            pnlHam.Enabled = false;
            pnlJalapenos.Enabled = false;
            pnlMushrooms.Enabled = false;
            pnlOnions.Enabled = false;
            pnlPepperoni.Enabled = false;
            pnlPineapple.Enabled = false;
            pnlSausage.Enabled = false;
            pnlSize.Enabled = false;
            pnlSpinach.Enabled = false;
            pnlTomato.Enabled = false;
            btnAddPizza.Enabled = false;
            btnScrap.Enabled = false;
            lstPizzas.Items.Clear();

            resetPizzaPage();
            

        }

        private void resetPizzaPage()
        {
            rdbNoAnchovies.Checked = true;
            rdbNoBacon.Checked = true;
            rdbNoBO.Checked = true;
            rdbNoBP.Checked = true;
            rdbNoGO.Checked = true;
            rdbNoGP.Checked = true;
            rdbNoHam.Checked = true;
            rdbNoJalapenos.Checked = true;
            rdbNoMush.Checked = true;
            rdbNoOnions.Checked = true;
            rdbNopepperoni.Checked = true;
            rdbNoPineapple.Checked = true;
            rdbNoSausage.Checked = true;
            rdbNoSpinach.Checked = true;
            rdbNoTomato.Checked = true;
            rdbSm.Checked = true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            setPrice();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTotalCost_Click(object sender, EventArgs e)
        {

        }

        private void lbLoginpage2_Click(object sender, EventArgs e)
        {

        }
    }
    
}
