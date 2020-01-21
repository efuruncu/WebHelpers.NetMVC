using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AntiForgery.NetMVC.Controllers
{
    public class WebMailController : Controller
    {
        //https://support.google.com/accounts/answer/6010255?hl=tr adresinden Authentication Required hatasını düzeltebiliriz.

        // GET: WebMail
        public ActionResult Index()
        {
            bool sonuc = false;

            //atacağımız server adresi ,gmail ise bu
            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 587;
            WebMail.UserName = "eliffuruncu93@gmail.com";
            WebMail.Password = "311e39y008544";

            WebMail.EnableSsl = true;

            string file = Server.MapPath("~/images/cat.jpg");

            try
            {
                WebMail.Send(
                    to: "yunusekinci64@gmail.com", subject: "WebMail Test",
                    body: "Bu bir web mail denemesidir.<br><b>Litfen dikkate almayınız..</b>",
                    replyTo: "dont-reply@gmail.com", isBodyHtml: true,
                    filesToAttach: new[] { file });

                sonuc = true;

            }catch(Exception e)
            {
                ViewBag.Hata = e.Message;
            }
            ViewBag.Sonuc = sonuc;

            return View();
        }
    }
}