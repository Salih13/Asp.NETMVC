using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog_Son.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime YayimTarihi { get; set; }
    }
}