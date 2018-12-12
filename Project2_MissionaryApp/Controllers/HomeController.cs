using Project2_MissionaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project2_MissionaryApp.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        // GET: Home
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("Home/About")]
        public ActionResult About()
        {
            return View();
        }

        [Route("Home/Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Contact");
            }
            else
            {
                return View();
            }
        }
    }
}