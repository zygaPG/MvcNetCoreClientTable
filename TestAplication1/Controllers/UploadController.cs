using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAplication1.Models;


namespace TestAplication1.Controllers
{
    

    public class UploadController : Controller
    {
        public static List<Klient> ContextItemData;


        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile , bool save)
        {
            if (save)
            {
                if (ContextItemData != null)
                {
                    using (var db = new DatabaseContext())
                    {
                        foreach (TestAplication1.Models.Klient item in ContextItemData)
                        {
                            var kliencik = new Klient { name = item.name, surname = item.surname, birthYear = item.birthYear };
                            db.klienci.Add(kliencik);

                        }
                        db.SaveChanges();

                        var klients = db.klienci
                        .OrderBy(b => b.id)
                        .ToList();
                        ViewBag.klienci = klients;
                    }

                   


                    
                }
                return View("~/Views/Test/Index.cshtml");
            }
            else
            {


                List<Klient> klients = new List<Klient>();
                string filePach = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    filePach = path + Path.GetFileName(postedFile.FileName);
                    string exstension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePach);

                    string csvData = System.IO.File.ReadAllText(filePach);

                    foreach (string row in csvData.Split('\n'))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            klients.Add(new Klient
                            {
                                id = Convert.ToInt32(row.Split(',')[0]),
                                name = row.Split(',')[1],
                                surname = row.Split(',')[2],
                                birthYear = Convert.ToInt32(row.Split(',')[3]),

                            });

                        }

                    }
                }
                ViewBag.klienciSCV = klients;
                
                ContextItemData = klients;
                return View();
            }
        }



        /*
        [HttpPost]
        public ActionResult Index(bool save)
        {
            if(save)
            if (ContextItemData != null)
            {
                using (var db = new DatabaseContext())
                {
                    foreach (TestAplication1.Models.Klient item in ViewBag.ContextItemData)
                    {
                        var kliencik = new Klient { name = item.name, surname = item.surname, birthYear = item.birthYear };
                        db.klienci.Add(kliencik);
                        
                    }
                    db.SaveChanges();

                }
            }
            return View("~/Views/Test/Index.cshtml");
        }
        */
    }
}