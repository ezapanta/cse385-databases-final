using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Employee
    {
        public static int currentLoginUser = 0;
        public int EmployeeID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
        public double Wage { get; set; }
        public string UserName { get; set; }

        public Employee(int EmployeeID, string FName, string LName, string Password, bool isAdmin, double Wage, string UserName)
        {
            this.EmployeeID = EmployeeID;
            this.FName = FName;
            this.LName = LName;
            this.Password = Password;
            this.isAdmin = isAdmin;
            this.Wage = Wage;
            this.UserName = UserName;
        }

        public override string ToString()
        {
            return String.Format("{0,-15} - {1,-15} - {2,-50} - {3,-50} - {4,-4}", UserName,Password,FName,LName,Wage);
            //return UserName + "\t\t" + Password + "\t\t" + FName + " " + LName + "\t\t" + Wage;
        }
    }
}
