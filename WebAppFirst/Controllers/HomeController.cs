using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;  // lisätty itse
using System.Data.Entity.Infrastructure;  // lisätty itse
using WebAppFirst.Models;


namespace WebAppFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Yhtiön perustietojen kuvailua.";
            ViewBag.Herja = "Ole huolellinen, niin ei tule virhettä";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Yhteystietojamme";

            return View();
        }

        public ActionResult Map()
        {
            ViewBag.Message = "Saapumisohje";

            return View();
        }
    }
}