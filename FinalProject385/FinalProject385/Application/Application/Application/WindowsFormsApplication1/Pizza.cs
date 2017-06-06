using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Pizza
    {
        public int pizzaID { get; set; }
        public string size { get; set; }
        public string[] toppings { get; set; }
        public double Total { get; set; }

        public Pizza(int pizzaID, string size, string[] toppings, double Total)
        {
            this.pizzaID = pizzaID;
            this.size = size;
            this.toppings = toppings;
            this.Total = Total;
        }

        public override string ToString()
        {
            string allToppings = " ";
            
            for(int i = 0; i < toppings.Length; i++)
            {
                allToppings = allToppings + toppings[i] + " ";
            } 

            return String.Format("{0,-5} - {2,-5} - {2,-50}",Total, size, allToppings);
        }
    }

    
}
