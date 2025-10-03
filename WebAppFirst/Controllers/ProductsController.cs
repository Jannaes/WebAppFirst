using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppFirst.Models;

namespace WebAppFirst.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            NorthwindOriginalEntities1 db = new NorthwindOriginalEntities1();  //luodaan tietokanta-olio
            List<Products> model = db.Products.ToList();
            db.Dispose();  //poistetaan/vapautetaan olio, jottei se vie muistia
            return View(model);
        }

        public ActionResult Index2()
        {
            NorthwindOriginalEntities1 db = new NorthwindOriginalEntities1();  //luodaan tietokanta-olio
            List<Products> model = db.Products.ToList();
            db.Dispose();  //poistetaan/vapautetaan olio, jottei se vie muistia
            return View(model);
        }
    }
}