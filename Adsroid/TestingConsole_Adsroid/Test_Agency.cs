using System;
using Adsroid.Models.DataAccessLayer;
using Adsroid.Models;


namespace Adsroid_TestingConsole
{
    class Test_Agency
    {
        static void Main1(string[]args)
        {
//Login Testing
            Agency a = new Agency();
            a.emailid = "E";
            a.password = "P";
            Connected_DALAgency dalObj = new Connected_DALAgency();
            //Login Testing
            int r = dalObj.AgencyLogin(a);
            if (r > 0)
            {
                Console.WriteLine("Login Success");
                Console.WriteLine("Agency Id:" + r);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Failed Try Again");
                Console.WriteLine("R is :" + r);
                Console.ReadLine();
            }



//AgencyRegistration Testing
            //Connected_DALAgency dalObj = new Connected_DALAgency();
            //Agency a = new Agency()
            //{
            //    name = "A",
            //    address = "B",
            //    city = "C",
            //    state = "R",
            //    country = "X",
            //    zipcode = "z",
            //    website = "website",
            //    contactno = "D",
            //    username = "Username",
            //    emailid = "E",
            //    skypeid = "s",
            //    mobileno = "M",
            //    password = "P"
            //};
            //string s = dalObj.CreateAgency(a);
            //Console.WriteLine(s);
            //Console.ReadLine();


//Other Testing
            //int n = 4;
            //string r = dalObj.AgencyUser(n);
            //if (r!=null)
            //{
            //    Console.WriteLine("Got Username");
            //    Console.WriteLine("Username:" + r);
            //    Console.ReadLine();
            //}
            //else
            //{
            //    Console.WriteLine("Failed Try Again");
            //    Console.WriteLine("R is :" + r);
            //    Console.ReadLine();
            //}
        }
    }
}
