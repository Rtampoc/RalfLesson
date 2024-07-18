using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class PersonController : Controller
    {
        Person mod = new Person();
        // GET: Person
        public ActionResult Index()
        {
            return View(mod.List());
        }
    }
}