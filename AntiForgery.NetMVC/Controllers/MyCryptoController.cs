using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AntiForgery.NetMVC.Controllers
{
    public class MyCryptoController : Controller
    {
        private string sifresiz = "Elif Furuncu";
        private string sifreli = "htHenv17a2TiZ29F38LJ+x/kOjfxtke/eU7ucHn9twc=";
        // GET: MyCrypto
        public ActionResult Index()
        {
            //Random anahtar değer verir
            string salt = Crypto.GenerateSalt();

            //Şifreleme
            string hash = Crypto.Hash(sifresiz,algorithm:"md5");
            string sh1 = Crypto.SHA1(sifresiz);
            string sh256 = Crypto.SHA256(sifresiz);

            //şifresiz bir metni şifreliyor
            string sonuc = Crypto.HashPassword(sifresiz);
            //şifreli bir metni şifresiz ile karşılaştırıp doğru mu olduğuna bakıyor.
            bool dogrumu = Crypto.VerifyHashedPassword(sifreli, sifresiz);

            return View();

            
        }
    }
}