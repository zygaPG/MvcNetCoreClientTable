using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestAplication1.Models;



namespace TestAplication1.Controllers
{
    public class TestController : Controller
    {
        

        // GET: Test
        public ActionResult Index()  // pobieranie danych z tabeli za pomocą entity
        {
            
            using (var db = new DatabaseContext())
            {
                /*
                var kliencik = new Klient { name = "maciek", surname="proszedzialaj", birthYear = 2000};
                db.klienci.Add(kliencik);
                db.SaveChanges();
                */
                var klients = db.klienci
                   .OrderBy(b => b.id)
                   .ToList();
                

                ViewBag.klienci = klients;

/*
 
                ViewBag.dane = klients;
                string tabliczka = "";

                for (int x = 0; x < 5; x++)
                {
                    tabliczka += "<tr> <td>" + ViewBag.dane[x].name + "</td>	<td>" + ViewBag.dane[x].surname + "</td> <td>" + ViewBag.dane[x].birthYear + "</td> </tr>";
                }
                ViewBag.tabela = tabliczka;
*/
            }
           
            return View();
        }

        [HttpPost]
        public ActionResult Index(Klient klientSubmit, /* bool delete, bool edit, */ int action)
        {
            using (var db = new DatabaseContext())
            {
                switch (action)
                {
                    case 0:         //--------------ADDDD-Client-----------
                        var kliencik = new Klient { name = klientSubmit.name, surname = klientSubmit.surname, birthYear = klientSubmit.birthYear };
                        db.klienci.Add(kliencik);
                        db.SaveChanges();

                        var klients = db.klienci
                          .OrderBy(b => b.id)
                          .ToList();
                        ViewBag.klienci = klients;

                        return View("~/Views/Test/Index.cshtml");

                        break;
                    case 1:         //---------------DELETe-Client-------------
                        var klientO = new Klient()
                        {
                            id = klientSubmit.id
                        };

                        db.Entry(klientO).State = EntityState.Deleted;
                        db.SaveChanges();

                        var klients2 = db.klienci
                          .OrderBy(b => b.id)
                          .ToList();
                        ViewBag.klienci = klients2;

                        return View("~/Views/Test/Index.cshtml");

                        break;
                    case 2:         //---------------Edit-Client--------------
                        var klientOO = new Klient()
                        {
                            id = klientSubmit.id
                        };
                        db.Set<Klient>().Attach(klientOO);
                        if (klientSubmit.name != "") { klientOO.name = klientSubmit.name; }
                        if (klientSubmit.surname != "") { klientOO.surname = klientSubmit.surname; }
                        if (klientSubmit.birthYear != 0) { klientOO.birthYear = klientSubmit.birthYear; }
                        db.SaveChanges();

                        var klients3 = db.klienci
                          .OrderBy(b => b.id)
                          .ToList();
                        ViewBag.klienci = klients3;

                        return View("~/Views/Test/Index.cshtml");

                        break;
                    case 3:                      //--------------Upload--View--------



                        return View("~/Views/Upload/Index.cshtml");

                        break;
                    default :                   //------------------Deflaut-------------
                        var klients4 = db.klienci
                            .OrderBy(b => b.id)
                            .ToList();
                        ViewBag.klienci = klients4;

                        return View("~/Views/Test/Index.cshtml");

                }



                /*
                if (!delete)
                {
                    var kliencik = new Klient { name = klientSubmit.name, surname = klientSubmit.surname, birthYear = klientSubmit.birthYear };
                    db.klienci.Add(kliencik);
                    db.SaveChanges();

                    

                }
                else // <----------------------DeleteOption------------------------>
                {
                    var klientO = new Klient()
                    {
                        id = klientSubmit.id
                    };
                    if (edit)
                    {
                        db.Set<Klient>().Attach(klientO);
                        if(klientSubmit.name != "") { klientO.name = klientSubmit.name; }
                        if (klientSubmit.surname != "") { klientO.surname = klientSubmit.surname; }
                        if (klientSubmit.birthYear != 0) { klientO.birthYear = klientSubmit.birthYear; }
                    }
                    else
                    {
                        db.Entry(klientO).State = EntityState.Deleted;
                    }

                    db.SaveChanges();
                }

                var klients = db.klienci
                          .OrderBy(b => b.id)
                          .ToList();
                ViewBag.klienci = klients;

                return View();
                */
            }
        }


        
    }
}