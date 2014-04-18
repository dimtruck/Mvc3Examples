using Mvc3Examples.Helpers.Attributes;
using Mvc3Examples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Mvc3Examples.Controllers
{
    public class SecurityController : Controller
    {
        //
        // GET: /Security/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Security/SecretStuff

        [Authorize]
        public ActionResult SecretStuff()
        {
            return View();
        }

        //
        // GET: /Security/SuperSecretStuff

        [Authorize(Roles="admin")]
        public ActionResult SuperSecretStuff()
        {
            return View();
        }

        //
        // GET: /Security/SuperDuperSecretStuff

        [Authorize(Users = "tommy")]
        public ActionResult SuperDuperSecretStuff()
        {
            return View();
        }

        //
        // GET: /Security/CustomStuff

        [CustomAuthorized]
        public ActionResult CustomStuff()
        {
            return View();
        }

        [HttpGet]
        public ViewResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(AccountModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //silly way to set roles and users and store it in ticket.  not the safest way to do this :)
                string data = new JavaScriptSerializer().Serialize(model);
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, model.Name, DateTime.Now, DateTime.Now.AddMinutes(20), true, data);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                Response.SetCookie(cookie);
                return Redirect(returnUrl);
            }
            //unauthenticated!
            //add an error
            ModelState.AddModelError("", "The information provided is incorrect.");
            return View(model);
        }

        //
        // GET: /Security/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Security/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Security/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Security/Edit/5

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

        //
        // GET: /Security/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Security/Delete/5

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
