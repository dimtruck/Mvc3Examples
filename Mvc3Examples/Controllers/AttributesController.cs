using Mvc3Examples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Mvc3Examples.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class AttributesController : Controller
    {
        private StudentViewModel GetStudentViewModel()
        {
            return new StudentViewModel()
            {
                Address = "1 anytown",
                Name = "me",
                ZipCode = "12345",
                Age = 40,
                School = "Travis",
                Grade = "A"
            };
        }

        //
        // GET: /Attributes/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Attributes/Required
        [HttpGet]
        public ViewResult Required()
        {
            /**
             * We will use StudentViewModel for an example.  
             * This model has a "name" attribute, which is required.
             * When we build a form to add a student view, we will be required to 
             * pass in a proper name or else the server response will fail
             * 
             * The passed in model can be used to prepopulate the form
             */
            StudentViewModel model = GetStudentViewModel();
            model.Name = null;            

            return View(model);
        }

        //
        // POST: /Attributes/Required
        [HttpPost]
        public ActionResult Required(StudentViewModel model)
        {
            return View(model);
        }

        //
        // GET: /Attributes/StringLength
        [HttpGet]
        public ViewResult StringLength()
        {
            /**
             * We will use StudentViewModel for an example.  
             * This model has an "address" attribute, which has a min length of 5 and max length of 10.
             * When we build a form to add a student view, we will be required to 
             * pass in a proper address or else the server response will fail
             */
            var model = GetStudentViewModel();
            model.Address = null;
            return View(model);
        }

        //
        // POST: /Attributes/StringLength
        [HttpPost]
        public ActionResult StringLength(StudentViewModel model)
        {
            return View(model);
        }

        //
        // GET: /Attributes/Regex
        [HttpGet]
        public ViewResult Regex()
        {
            /**
             * We will use StudentViewModel for an example.  
             * This model has an "zipcode" attribute, which has a regular expression of allowing 5 digits only.
             * When we build a form to add a student view, we will be required to 
             * pass in a proper zip code or else the server response will fail
             */
            StudentViewModel model = GetStudentViewModel();
            model.ZipCode = null;
            return View(model);
        }

        //
        // POST: /Attributes/Regex
        [HttpPost]
        public ActionResult Regex(StudentViewModel model)
        {
            return View(model);
        }

        //
        // GET: /Attributes/Range
        [HttpGet]
        public ViewResult Range()
        {
            /**
             * We will use StudentViewModel for an example.  
             * This model has an "age" attribute, which allows a range between 18 and 120
             * When we build a form to add a student view, we will be required to 
             * pass in a proper age or else the server response will fail
             */
            StudentViewModel model = GetStudentViewModel();
            model.Age = 0;
            return View(model);
        }

        //
        // POST: /Attributes/Range
        [HttpPost]
        public ActionResult Range(StudentViewModel model)
        {
            return View(model);
        }

        //
        // GET: /Attributes/Remote
        [HttpGet]
        public ViewResult Remote()
        {
            /**
             * We will use StudentViewModel for an example.  
             * This model has an "school" attribute, which must match a list of school listed in the ValidateSchools method
             * When we build a form to add a student view, we will be required to 
             * pass in a proper school or else the server response will fail
             */
            StudentViewModel model = GetStudentViewModel();
            model.School = null;
            return View(model);
        }

        //
        // POST: /Attributes/Remote
        [HttpPost]
        public ActionResult Remote(StudentViewModel model)
        {
            return View(model);
        }

        //
        // GET: /Attributes/Custom
        [HttpGet]
        public ViewResult Custom()
        {
            /**
             * We will use StudentViewModel for an example.  
             * This model has an "grade" attribute, which must match a list of grades listed in the GradeRange annotation
             * When we build a form to add a student view, we will be required to 
             * pass in a proper grade or else the server response will fail
             */
            StudentViewModel model = GetStudentViewModel();
            model.Grade = null;
            return View(model);
        }

        //
        // POST: /Attributes/Custom
        [HttpPost]
        public ActionResult Custom(StudentViewModel model)
        {
            return View(model);
        }

        //
        // GET: /Attributes/ValidateSchool/schoolName

        public ActionResult ValidateSchool(String schoolName)
        {
            /**
             * This method gets called every time a validation gets triggered from the client.  It will return either a true (school exists in a list) or false (school does
             * not exist in a list)
             */
            IEnumerable<String> schoolList = new List<String>()
            {
                "Travis","Westlake","Round Rock","Austin"
            };

            
            return Json(schoolList.Contains(schoolName), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Attributes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Attributes/Create

        [HttpPost]
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
        // GET: /Attributes/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Attributes/Edit/5

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
        // GET: /Attributes/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Attributes/Delete/5

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
