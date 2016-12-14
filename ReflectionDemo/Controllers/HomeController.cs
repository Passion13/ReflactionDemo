using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReflectionDemo.Models;

namespace ReflectionDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
         
            return View(new Reference());
        }
        [HttpPost]
        public ActionResult Index(Reference reference)
        {
            return View(reference);

        }
     

    }
}
