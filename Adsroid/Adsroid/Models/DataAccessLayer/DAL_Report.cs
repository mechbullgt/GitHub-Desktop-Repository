using System;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Adsroid.Models.DataAccessLayer
{
    public class DAL_Report
    {
        public static string conString = string.Empty;

        static DAL_Report()
        {
            conString = @"server=localhost;user id=root;database=adsroid;sslmode=None";
        }
        public static DataTable GetReportSummary()
        {
            DataTable dt = new DataTable("ReportSummary");
            string query = "select impressions,clicks,conversions from reports_master;";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;//@"server=localhost;user id=root;database=adsroid;sslmode=None";
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = con;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            con.Open();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public class Summary
        {
            public int impressions { get; set; }
            public int clicks { get; set; }
            public int conversion { get; set; }
            
        }

        [HttpGet]
        //public async Task<ActionResult> ReportSummary()
        public JsonResult ReportSummary()
        {
            List<Summary> lstSummary = new List<Summary>();
            Summary summary = new Summary();
            foreach (DataRow dr in GetReportSummary().Rows)
            {
                summary.impressions = Convert.ToInt32(dr[0].ToString());
                summary.clicks = Convert.ToInt32(dr[1].ToString());
                summary.conversion = Convert.ToInt32(dr[2].ToString());
                lstSummary.Add(summary);
            }
            return Json(JsonConvert.SerializeObject(lstSummary),JsonRequestBehavior
                .AllowGet);
        }

        private JsonResult Json(string v, JsonRequestBehavior allowGet)
        {
            throw new NotImplementedException();
        }
    }
}