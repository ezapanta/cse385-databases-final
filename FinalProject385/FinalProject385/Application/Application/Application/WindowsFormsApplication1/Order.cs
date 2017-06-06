using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Order
    {
        public static int currentOrder = 0;
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public decimal OrderTotal { get; set; }
        public string CreditCardNumber { get; set; }
        public string customerFName { get; set; }
        public string customerLName { get; set; }


        public Order(int OrderID, int EmployeeID, decimal OrderTotal, string CreditCardNumber, string CustomerFName, string CustomerLName)
        {
            this.OrderID = OrderID;
            this.EmployeeID = EmployeeID;
            this.OrderTotal = OrderTotal;
            this.CreditCardNumber = CreditCardNumber;
            this.customerFName = CustomerFName;
            this.customerLName = CustomerLName;
       

        }

        public override string ToString()
        {
            string pizzas = "";
            

            using (ds.spGetPizzasDataTable tblP = new dsTableAdapters.spGetPizzasTableAdapter().GetData(OrderID))
            {
                int j = 0;
                foreach (ds.spGetPizzasRow rP in tblP.Rows)
                {
                    string allToppings = "";
                    string[] toppings = new string[15];
                    pizzas = pizzas + "\n\t";
                    int pizzaID = rP.PizzaID;


                    using (ds.spGetToppingsDataTable tblT = new dsTableAdapters.spGetToppingsTableAdapter().GetData(pizzaID))
                    {
                        int h = 0;

                        foreach (ds.spGetToppingsRow rT in tblT.Rows)
                        {
                            toppings[h] = rT.ToppingName;
                            h = h + 1;
                        }
                        if (toppings[0] == null)
                        {
                            toppings[0] = "Cheese";
                        }

                        j = j + 1;
                        h = 0;
                    }

                    for (int k = 0; k < toppings.Length; k++)
                    {
                        
                        allToppings = allToppings + toppings[k] + " ";
                        
                    }
                    pizzas = String.Format("{0,-15} - {1,-5} - {2,-40}",pizzas, rP.Size, allToppings);
                   

                }
                return String.Format("${0,-5} - {1,-15} - {2,-15} - {3,-60}", OrderTotal, customerFName, customerLName, pizzas);

               
            }
        }
    }
}
