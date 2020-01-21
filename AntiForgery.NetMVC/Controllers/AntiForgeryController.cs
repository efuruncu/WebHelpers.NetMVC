using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AntiForgery.NetMVC.Models;

namespace AntiForgery.NetMVC.Controllers
{
    public class AntiForgeryController : Controller
    {
        // GET: AntiForgery
        public ActionResult Test()
        {
            return View(Veritabani.Veriler);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Test(int id)
        {
            Veritabani.Veriler.RemoveAt(id);
            return RedirectToAction("Test");
        }

        public ActionResult FakeTest()
        {
            return View();
        }
    }
}