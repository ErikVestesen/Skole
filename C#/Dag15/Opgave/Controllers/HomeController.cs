using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Opgave.Models;

namespace Opgave.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RsvpForm()
        {

            return View();
        }

        [HttpPost]
        public ActionResult RsvpForm(myClasses guestResponse)
        {
            return View("Svar", guestResponse);
        }
    }
}