using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace QualLivroLer.Controllers
{
    [EnableCors(origins: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Why Books header?";

            return View();
        }
    }
}
