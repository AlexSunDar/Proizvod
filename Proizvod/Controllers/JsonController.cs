using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Proizvod.Model;
using Proizvod.Persistance;

namespace Proizvod.Controllers
{
    public class JsonController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postavljeniDokument)
        {
            List<ProizvodModel> proizvodi = new List<ProizvodModel>();

            if (postavljeniDokument != null && postavljeniDokument.FileName.EndsWith(".json"))
            {
                string direktorijum = Server.MapPath("~/Uploads/");
                string punaPutanja = direktorijum + postavljeniDokument.FileName;
                if (!Directory.Exists(direktorijum))
                {
                    Directory.CreateDirectory(direktorijum);
                }
                postavljeniDokument.SaveAs(punaPutanja);
                ViewBag.Message = "JSON uspesno ucitan";

                using (StreamReader streamReader = new StreamReader(punaPutanja))
                {
                    string json = streamReader.ReadToEnd();
                    proizvodi = JsonConvert.DeserializeObject<List<ProizvodModel>>(json);   
                }    
            }
            else
            {
                ViewBag.Message = "JSON nije ucitan";
            }
            return View(proizvodi);
        }
    }
}
