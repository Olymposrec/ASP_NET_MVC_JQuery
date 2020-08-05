using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_JQuery.Controllers
{
    public class HomeController : Controller
    {
        private List<string> liste = new List<string>() { "Melih", "Olymposre", "Akkose" };
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult VerileriGetir(string veri="")
        {
            if(string.IsNullOrEmpty(veri)==false)
            {
                liste.Add(veri);
            }
            System.Threading.Thread.Sleep(3000);
            return PartialView("_DataItemPartial",liste);
        }
        //public PartialViewResult VerileriGetir(string veri)
        //{
        //    liste.Add(veri);
        //    System.Threading.Thread.Sleep(3000);
        //    return PartialView("_DataItemPartial", liste);
        //}
        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Index3()
        {
            return View();
            
        }
        public ActionResult Index4()
        {
            return View();

        }
        public JsonResult VerileriGetir2(string veri = "")
        {
            if (string.IsNullOrEmpty(veri) == false)
            {
                liste.Add(veri);
            }
            System.Threading.Thread.Sleep(2000);
            return Json(liste,JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index5()
        {
            return View();
        }
        [HttpPost]
        public JsonResult FileUpload(HttpPostedFileBase file)
        {

            if(file!=null)
            {
                if (Directory.Exists(Server.MapPath("~/files")) == false)
                    Directory.CreateDirectory(Server.MapPath("~/files"));

                file.SaveAs(Path.Combine(Server.MapPath("~/files"), file.FileName));
                return Json(new { hasError = false, message = "Dosya Yüklendi.." });
            }

            return Json(new { hasError = true, message = "Dosya Yüklenemedi.." });
        }







    }

}