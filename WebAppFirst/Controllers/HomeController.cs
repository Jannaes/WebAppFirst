using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;  // lisätty itse
using System.Data.Entity.Infrastructure;  // lisätty itse
using WebAppFirst.Models;
using System.Web.UI.WebControls;


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


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Logins LoginModel)
        {
            
            //Haetaan käyttäjän/Loginin tiedot annetuilla tunnustiedoilla tietokannasta LINQ-kyselyllä
            var LoggedUser = db.Logins.SingleOrDefault(x => x.UserName == LoginModel.UserName && x.PassWord == LoginModel.PassWord);

            if (LoggedUser != null)
            {
                ViewBag.LoginMessage = "Successfull login";
                Session["LoggedStatus"] = "IN";
                ViewBag.LoginError = 0; //Ei virhettä
                Session["UserName"] = LoggedUser.UserName;
                return RedirectToAction("Index", "Home"); //Tässä määritellään mihin onnistunut kirjautuminen johtaa --> Home/Index
            }
            else
            {
                ViewBag.LoginMessage = "Login unsuccessfull";
                Session["LoggedStatus"] = "OUT";
                ViewBag.LoginError = 1; //Pakotetaan modaali login-ruutu uudelleen, koska kirjautumisyritys epäonnistunut
                LoginModel.LoginErrorMessage = "Tuntematon käyttäjätunnus tai salasana.";
                return View("Index", LoginModel);
                //return View("Login", LoginModel);
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            ViewBag.LoggedStatus = "Out";
            return RedirectToAction("Index", "Home"); //Uloskirjautumisen jälkeen pääsivulle
        }
    }
}