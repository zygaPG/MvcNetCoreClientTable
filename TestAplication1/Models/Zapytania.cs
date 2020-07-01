using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAplication1.Models
{
    public class Zapytania
    {
        public void Pobieranie()
        {
            using (var db = new DatabaseContext())
            {
                var blogs = db.klienci
                    .OrderBy(b => b.id)
                    .ToList();
            }
        }

    }
       

    
}