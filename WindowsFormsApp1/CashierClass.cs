using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class CashierClass
    {
        private int x = 10000;
 
        public static Queue<string> CashierQueue = new Queue<string>();
        public static string getNumberInQueue = "";

 
        public CashierClass()
        {
        }

 
        public string CashierGeneratedNumber(string CashierNumber)
        {
            x++;
            CashierNumber = CashierNumber + x.ToString();
            return CashierNumber;
        }
    }
}
