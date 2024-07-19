using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers {
    public class HomeController : Controller {
        Person mod = new Person();
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        [HttpGet]
        public ActionResult MyProfile() {
            
            return View(mod.List());
        }


        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person m) {
            mod.Insert(m);
            return RedirectToAction("MyProfile");
        }

        public ActionResult Edit(int ID) {
            var item = mod.Find(ID);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Person m) {
            mod.Update(m);
            return RedirectToAction("MyProfile");
        }
        public ActionResult Delete(int ID)
        {
            var item = mod.Find(ID);
            return View(item);
        }

        [HttpPost]
        public ActionResult Delete(Person m, int ID)
        {
            mod.DeleteViewData(m);
            mod.DeleteData(ID);
            return RedirectToAction("MyProfile");
        }

        public PartialViewResult data(string Search)
        {
            var item = mod.List(Search);
            return PartialView(item);
        }

    }
   


}