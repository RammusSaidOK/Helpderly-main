using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FSD_Helpderly.Models;
using FSD_Helpderly.DAL;

namespace FSD_Helpderly.Controllers
{
    public class RegisterController : Controller
    {
        private FirestoreDAL VolunteerContext = new FirestoreDAL();
        // GET: Register/Index
        public IActionResult Index()
        {
            return View();
        }

        // POST: Register/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Register register)
        {
            if (ModelState.IsValid)
            {
                //Add volunteer record to database
                register.VolunteerID = VolunteerContext.AddVolunteer(register);
                TempData["Message"] = "Your Account have been successfully created!";
                return RedirectToAction("Index");
            }
            else
            {
                //Input validation fails, return to the register view to display error message
                return View(register);
            }
        }
    }
}
