using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adsroid.Models.DataAccessLayer;
using static Adsroid.Models.DataAccessLayer.DAL_Report;

namespace TestingConsole_Adsroid
{
    class Test_Data
    {
        public static void Main(String []args)
        {
            DAL_Report dalObj = new DAL_Report();
            string mylist = dalObj.ReportSummary();
            Console.WriteLine(mylist);
            Console.ReadLine();
        }
    }
}
