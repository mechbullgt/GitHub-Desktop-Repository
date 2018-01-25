using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Adsroid.Models.DataAccessLayer
{
    public class DAL_Campaign
    {
        public static string conString = string.Empty;

        static DAL_Campaign()
        {
            //conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\CDAC\Cdac Aug17 1157\Major Project\ACMS\Adsroid\Adsroid\Adsroid\App_Data\AdsroidDb.mdf;Integrated Security=True";
            conString = @"server=localhost;user id=root;database=adsroid;sslmode=None";
        }

        //Create Campaign Only Creative Detail and upload

        //Create Campaign No Creative Detail
        public string CreateCampaign(Campaign e, int aid)
        {
            String str = "";
            try
            {
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    //string insertQuery = "INSERT INTO Agency_Master (name, address, city, state, country, zipcode, website, contactno, username, emailid, skypeid, mobileno, password) VALUES (@name, @address, @city, @state, @country, @zipcode, @website, @contactno, @username, @emailid, @skypeid, @mobileno, @password);";
                    string query = "INSERT INTO Campaign_Master (cname, title, details, landing_page, payout, kpi, audience, start_date, end_date, budget, agency_master_agency_id) VALUES (@name, @title,@details,@lp,@p,@k,@a,@sd,@ed,@b,@aid);";
                    //@name, @title,@details,@lp,@p,@k,@a,@sd,@ed,@b,@cn,@cd,@c
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    //@name, @address, @city, @state, @country, @zipcode, @website, @contactno, @username, @emailid, @skypeid, @mobileno, @password

                    cmd.Parameters.Add(new MySqlParameter("@name",e.cname));
                    cmd.Parameters.Add(new MySqlParameter("@title",e.title));
                    cmd.Parameters.Add(new MySqlParameter("@details",e.details));
                    cmd.Parameters.Add(new MySqlParameter("@lp",e.landing_page));
                    cmd.Parameters.Add(new MySqlParameter("@p",e.payout));
                    cmd.Parameters.Add(new MySqlParameter("@k",e.kpi));
                    cmd.Parameters.Add(new MySqlParameter("@a",e.audience));
                    cmd.Parameters.Add(new MySqlParameter("@sd",e.start_date));
                    cmd.Parameters.Add(new MySqlParameter("@ed",e.end_date));
                    cmd.Parameters.Add(new MySqlParameter("@b",e.budget));
                    cmd.Parameters.Add(new MySqlParameter("@aid", aid));
                    cmd.ExecuteNonQuery();

                    if (con.State == ConnectionState.Open)
                        con.Close();
                    str = "Campaign Creation Successful!";
                    Console.WriteLine(str);
                    return str;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Console.WriteLine("Insertion Error:" + msg);
                str = "Failed Campagin Creation Try Again";
                Console.WriteLine(str);
            }
            return str;
        }

        public List<Campaign> GetAllCampaigns(int aid)
        {
            List<Campaign> CampaignList = new List<Campaign>();
            try
            {
                using (MySqlConnection sqlconnection = new MySqlConnection(conString))
                {
                    if (sqlconnection.State == System.Data.ConnectionState.Closed)
                        sqlconnection.Open();
                    string query = "SELECT cname, title, details, landing_page, payout, kpi, audience, start_date, end_date, budget from Campaign_Master where agency_master_agency_id=@fkaid ;";
                    MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnection);
                    sqlcommand.Parameters.Add(new MySqlParameter("@fkaid",aid));
                    IDataReader sqldatareader = sqlcommand.ExecuteReader();
                    if (sqldatareader != null)
                    {
                        while (sqldatareader.Read())
                        {
                            Console.WriteLine("Field Count:10:::::" + sqldatareader.FieldCount);

                            //Smart Properties
                            Campaign e = new Campaign();
                            {
                                e.cname = (sqldatareader["cname"].ToString());
                                Console.WriteLine("ID:"+e.cname);
                                e.title = sqldatareader["title"].ToString();
                                e.details = (sqldatareader["details"].ToString());
                                e.landing_page = (sqldatareader["landing_page"].ToString());
                                e.payout = (sqldatareader["payout"].ToString());
                                e.kpi = (sqldatareader["kpi"].ToString());
                                e.audience = (sqldatareader["audience"].ToString());
                                e.start_date = (sqldatareader["start_date"].ToString());
                                e.end_date = (sqldatareader["end_date"].ToString());
                                e.budget = (sqldatareader["budget"].ToString());
                            };
                            //Console.WriteLine("Hi"+e);
                            CampaignList.Add(e);
                        }
                        sqldatareader.Close();
                    }
                    else
                    {
                        Console.WriteLine("Empty DataReader");
                    }
                    if (sqlconnection.State == System.Data.ConnectionState.Open)
                    { sqlconnection.Close(); }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Console.WriteLine(msg);
                Console.WriteLine("Exception Alert");
            }
            return CampaignList;
        }

        public Campaign GetCampaignById(int cid)
        {
            Campaign e = null;
            try
            {
                using (MySqlConnection sqlconnection = new MySqlConnection(conString))
                {
                    if (sqlconnection.State == System.Data.ConnectionState.Closed)
                        sqlconnection.Open();
                    string query = "SELECT cname, title, details, landing_page, payout, kpi, audience, start_date, end_date, budget from Campaign_Master where campaign_id=@fkaid ;";
                    MySqlCommand sqlcommand = new MySqlCommand(query, sqlconnection);
                    sqlcommand.Parameters.Add(new MySqlParameter("@fkaid", cid));
                    IDataReader sqldatareader = sqlcommand.ExecuteReader();
                    if (sqldatareader != null)
                    {
                        while (sqldatareader.Read())
                        {
                            Console.WriteLine("Field Count:10:::::" + sqldatareader.FieldCount);

                            //Smart Properties
                            e = new Campaign();
                            {
                                e.cname = (sqldatareader["cname"].ToString());
                                Console.WriteLine("ID:" + e.cname);
                                e.title = sqldatareader["title"].ToString();
                                e.details = (sqldatareader["details"].ToString());
                                e.landing_page = (sqldatareader["landing_page"].ToString());
                                e.payout = (sqldatareader["payout"].ToString());
                                e.kpi = (sqldatareader["kpi"].ToString());
                                e.audience = (sqldatareader["audience"].ToString());
                                e.start_date = (sqldatareader["start_date"].ToString());
                                e.end_date = (sqldatareader["end_date"].ToString());
                                e.budget = (sqldatareader["budget"].ToString());
                            };
                            //Console.WriteLine("Hi"+e);
                        }
                        sqldatareader.Close();
                    }
                    else
                    {
                        Console.WriteLine("Empty DataReader");
                    }
                    if (sqlconnection.State == System.Data.ConnectionState.Open)
                    { sqlconnection.Close(); }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Console.WriteLine(msg);
                Console.WriteLine("Exception Alert");
            }
            return e;
        }

        public string UpdateCampaign(Campaign e, int cid)
        {
            string status = "Nothing";

            try
            {
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        string query = "Update Campaign_Master set cname=@cn, title=@t, details=@d, landing_page=@lp, payout=@p, kpi=@k, audience=@a, start_date=@sd, end_date=@ed, budget=@b where campaign_id=@cid ";
                        MySqlCommand cmd = new MySqlCommand(query, con);
//cname=@cn, title=@t, details=@d, landing_page=@lp, payout=@p, kpi=@k, audience=@a, start_date=@sd, end_date=@ed, budget=@b where campaign_id=@cid
                        cmd.Parameters.Add(new MySqlParameter("@cn", e.cname));
                        cmd.Parameters.Add(new MySqlParameter("@t", e.title));
                        cmd.Parameters.Add(new MySqlParameter("@d", e.details));
                        cmd.Parameters.Add(new MySqlParameter("@lp", e.landing_page));
                        cmd.Parameters.Add(new MySqlParameter("@p", e.payout));
                        cmd.Parameters.Add(new MySqlParameter("@k", e.kpi));
                        cmd.Parameters.Add(new MySqlParameter("@a", e.audience));
                        cmd.Parameters.Add(new MySqlParameter("@sd", e.start_date));
                        cmd.Parameters.Add(new MySqlParameter("@ed", e.end_date));
                        cmd.Parameters.Add(new MySqlParameter("@b", e.budget));
                        cmd.Parameters.Add(new MySqlParameter("@cid", cid));
                        cmd.ExecuteNonQuery();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        status = e.ToString();
                    }
                    else
                    {
                        Console.WriteLine("Connection Closed hai!");
                        return status;
                    }

                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Console.WriteLine(msg);
            }
            return status;
        }
    }
}
