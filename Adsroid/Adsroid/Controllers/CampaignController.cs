using System.Web.Mvc;
using System;
using Adsroid.Models.DataAccessLayer;
using Adsroid.Models;
using System.Collections.Generic;

namespace Adsroid.Controllers
{
    public class CampaignController : Controller
    {

        // GET: Campaign
        [HttpGet]
        public ActionResult GetAllCampaigns()
        {
            if (Session["username"] != null)
            {
                int aid = Convert.ToInt32(Session["agencyid"].ToString());
                if (ModelState.IsValid)
                {
                    DAL_Campaign dalObj = new DAL_Campaign();
                    //List<Campaign> mylist= dalObj.GetAllCampaigns();
                    return View(dalObj.GetAllCampaigns(aid));
                }
                else
                {
                    ViewBag.Message = "List GetAll Error";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "AgencyLogin");
            }
        }

        [HttpGet]
        public ActionResult CreateCampaign()
        {
            return View();
        }

        // GET: Campaign/Create
        [HttpPost]
        public ActionResult CreateCampaign(Campaign a)
        {
            int aid = Convert.ToInt32(Session["agencyid"].ToString());
            if (Session["username"] != null)
            {
                ViewBag.SessioName = Session["username"];
                Console.WriteLine(aid);
                string campstr = "";
                if (ModelState.IsValid)
                {
                    DAL_Campaign dalObj = new DAL_Campaign();
                    campstr = dalObj.CreateCampaign(a, aid);
                    ModelState.Clear();
                }
                else
                {
                    campstr = "Invalid Creation Request, Try Again";
                }
                ViewBag.Message = campstr;
                return View();
            }

            else
            {
               return RedirectToAction("Login", "AgencyLogin");
            }
          
        }

        // GET: Campaign
        [HttpGet]
        public ActionResult UpdateCampaigns()
        {
            if (Session["username"] != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        int aid = Convert.ToInt32(Session["agencyid"].ToString());
                        DAL_Campaign dalObj = new DAL_Campaign();

                        //List<Campaign> mylist= dalObj.GetAllCampaigns();
                        return View(dalObj.GetAllCampaigns(aid));

                    }
                    catch (Exception e)
                    {
                        ViewBag.LoginMessage = "Please Login to Start the session!";
                        ViewBag.Message = e.Message;
                        return RedirectToAction("Login", "AgencyLogin");
                        throw;
                    }
                }
                else
                {
                    ViewBag.Message = "List GetAll Error";
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "AgencyLogin");
            }
            }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            DAL_Campaign dalObj = new DAL_Campaign();
            return View(dalObj.GetCampaignById(id));
        }

        [HttpPost]
        public ActionResult UpdateCampaign(Campaign c)
        {
            DAL_Campaign dalObj = new DAL_Campaign();
            if (ModelState.IsValid)
            {
                string updatemessage = dalObj.UpdateCampaign(c, c.campaign_id);
                ViewBag.UpdateMessage = updatemessage;
                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Error Updating the data");
                return View();
            }
        }



    }
}
