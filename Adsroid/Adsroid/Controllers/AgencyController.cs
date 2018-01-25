using Adsroid.Models;
using Adsroid.Models.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adsroid.Controllers
{
    public class AgencyController : Controller
    {
        // GET: Agency
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AgencyRegistration()
        {
            return View();
        }

        // GET: Agency/Create
        [HttpPost]
        public ActionResult AgencyRegistration(Agency a)
        {
            bool status = false;
            string Message = "";
            if (ModelState.IsValid)
            {
                Connected_DALAgency dalObj = new Connected_DALAgency();
                string s = dalObj.CreateAgency(a);
                Message = "Agency Registration Successfull " + a.name;
                status = true;
                ModelState.Clear();
            }
            else
            {
                Message = "Invalid Request";
            }
            ViewBag.Message = Message;
            ViewBag.Status = status;
            return View();
        }

        // GET: Agency/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Agency/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agency/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Agency/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
