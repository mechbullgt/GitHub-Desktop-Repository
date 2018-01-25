using Adsroid.Models.DataAccessLayer;
using Adsroid.Models;
using System;
using System.Collections.Generic;

namespace TestingConsole_Adsroid
{
    class Test_Campaign
    {
       static void Main1(string [] args)
        {
            //GetAllCampaigns
            List<Campaign> cmplist = new List<Campaign>();
            DAL_Campaign dalObj = new DAL_Campaign();
            cmplist = dalObj.GetAllCampaigns(2);

            foreach (var item in cmplist)
            {
                Console.WriteLine(item.campaign_id);
                Console.WriteLine(item.cname);
            }
            Console.ReadLine();

            //Campaign Creation Testing
            //string rstr;
            //DAL_Campaign dalObj = new DAL_Campaign();
            //Campaign e = new Campaign()
            //{
            //    cname = "A",
            //    title = "Title",
            //    details = "Details",
            //    landing_page = "lp",
            //    payout = "payout",
            //    kpi = "kpi",
            //    audience = "aud",
            //    start_date = "2019-1-19",
            //    end_date = "2020-1-19",
            //    budget = "100",
            //};
            //rstr = dalObj.CreateCampaign(e, 2);
            //Console.WriteLine("Testing Campaign Block Over");
            //Console.ReadLine();


        }
    }
}
