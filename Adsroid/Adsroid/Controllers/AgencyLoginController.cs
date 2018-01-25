using Adsroid.Models;
using Adsroid.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Adsroid.Controllers
{
    public class AgencyLoginController : Controller
    {
        Connected_DALAgency dalObj = new Connected_DALAgency();
        // GET: AgencyLogin
        //Login 
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Agency a)
        {
            //bool gotAgencyId = false;
            string message = "";
            int r = dalObj.AgencyLogin(a);
            string uname = dalObj.AgencyUser(r);
            ViewBag.Message1 = r.ToString();
            //if(r>0)
            //{
            //    gotAgencyId = true;
            //    if (ModelState.IsValid)
            //    {
            if (r>0)
                {
                    message = "Login Success";
                    //Session["agency_id"] = r.ToString();
                    Session["username"] = uname;
                    Session["agencyid"] = r;
                    return RedirectToAction("Dashboard");
                }
                else
                {
                message = "Invalid Login Credentials, try again!";
                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
                //ViewBag.MessageError = errors;
            }

            //}
            //else
            //{
            //    message = "| Found no Agency Id |";
            //}
            //if (!ModelState.IsValid)
            //{
            //    var m = string.Join(" | ", ModelState.Values
            //        .SelectMany(v => v.Errors)
            //        .Select(e => e.ErrorMessage));
            //    ViewBag.MessageError = m;
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
            //}

            //else
            //{
            //    message = "all credentials needed!";
            //    var errors = ModelState.Select(x => x.Value.Errors)
            //                           .Where(y => y.Count > 0)
            //                           .ToList();
            //    ViewBag.MessageError = errors;
            //}
            ViewBag.Message = message;
            return View();
        }

        public ActionResult Dashboard()
        {
           // string dashcheck="Success Dash";
            if (Session["username"]!= null)
            {
                //ViewBag.Message = dashcheck;
                ViewBag.AgencyId = Session["agencyid"].ToString();
                return View();
            }

            else
            {

                //ViewBag.Message = "Dashboard Session Check Failed";
                return RedirectToAction("Login", "AgencyLogin");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "AgencyLogin");
        }
    }
}  