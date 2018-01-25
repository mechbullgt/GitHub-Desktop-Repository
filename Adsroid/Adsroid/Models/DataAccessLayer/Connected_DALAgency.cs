using System;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Adsroid.Models.DataAccessLayer
{
    public class Connected_DALAgency
    {
        //Static connection string
        private static string conString = string.Empty;

        //Default Constructor
        static Connected_DALAgency()
        {
            //conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\CDAC\Cdac Aug17 1157\Major Project\ACMS\Adsroid\Adsroid\Adsroid\App_Data\AdsroidDb.mdf;Integrated Security=True";
            //conString = @"server=localhost;user id=root;database=adsroid";
            conString = @"server=localhost;user id=root;database=adsroid;sslmode=None";
        }

        public string AgencyUser(int a)
        {
            string uname;
            try
            {
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "select username from Agency_Master where agency_id=@aid";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@aid", a));
                    uname = (cmd.ExecuteScalar()).ToString();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    return uname;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Console.WriteLine("Error:" + msg);
            }
            return uname = "No match";
        }
       //public string AgencyId(int a)
       // {
       //     string uname;
       //     try
       //     {
       //         using (SqlConnection con = new SqlConnection(conString))
       //         {
       //             if (con.State == ConnectionState.Closed)
       //                 con.Open();
       //             string query = "select username from Agency_Master where agency_id=@aid";
       //             SqlCommand cmd = new SqlCommand(query, con);
       //             cmd.Parameters.Add(new SqlParameter("@aid", a));
       //             uname = (cmd.ExecuteScalar()).ToString();
       //             if (con.State == ConnectionState.Open)
       //                 con.Close();
       //             return uname;
       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         string msg = ex.Message;
       //         Console.WriteLine("Error:" + msg);
       //     }
       //     return uname = "No match";
       // }

        //Agency Login
        public int AgencyLogin(Agency a)
        {
            int r=0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "select agency_id from Agency_Master where emailid=@eid and password=@pass";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@eid",a.emailid));
                    cmd.Parameters.Add(new MySqlParameter("@pass", a.password));
                    r=Convert.ToInt32(cmd.ExecuteScalar());
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    return r;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Console.WriteLine("Error:" + msg);
            }
            if(r==9999)
            {
                Console.WriteLine("No Match Found");
            }
            return r;
        }

        //Agency Registration
        public string CreateAgency(Agency e)
        {
            String str = "";

            try
            {
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO Agency_Master (name, address, city, state, country, zipcode, website, contactno, username, emailid, skypeid, mobileno, password) VALUES (@name, @address, @city, @state, @country, @zipcode, @website, @contactno, @username, @emailid, @skypeid, @mobileno, @password);";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    //@name, @address, @city, @state, @country, @zipcode, @website, @contactno, @username, @emailid, @skypeid, @mobileno, @password
                    cmd.Parameters.Add(new MySqlParameter("@name", e.name));
                    cmd.Parameters.Add(new MySqlParameter("@address", e.address));
                    cmd.Parameters.Add(new MySqlParameter("@city", e.city));
                    cmd.Parameters.Add(new MySqlParameter("@state", e.state));
                    cmd.Parameters.Add(new MySqlParameter("@country", e.country));
                    cmd.Parameters.Add(new MySqlParameter("@zipcode", e.zipcode));
                    cmd.Parameters.Add(new MySqlParameter("@website", e.website));
                    cmd.Parameters.Add(new MySqlParameter("@contactno", e.contactno));
                    cmd.Parameters.Add(new MySqlParameter("@username", e.username));
                    cmd.Parameters.Add(new MySqlParameter("@emailid", e.emailid));
                    cmd.Parameters.Add(new MySqlParameter("@skypeid", e.skypeid));
                    cmd.Parameters.Add(new MySqlParameter("@mobileno", e.mobileno));
                    cmd.Parameters.Add(new MySqlParameter("@password", e.password));

                    cmd.ExecuteNonQuery();

                    if (con.State == ConnectionState.Open)
                        con.Close();
                    str = "Agency Registration Successful!";
                    return str;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Console.WriteLine("Insertion Error:" + msg);
            }
            return str;
        }
    }
}