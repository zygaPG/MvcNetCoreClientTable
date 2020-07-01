using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAplication1.Models
{

    
    




    public class Klient
    {
        public int      id { get; set; }
        public string   name{ get; set; }
        public string   surname { get; set; }
        public int      birthYear { get; set; }
    }

    

}