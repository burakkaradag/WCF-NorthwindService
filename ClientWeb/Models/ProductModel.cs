using ClientWeb.ServiceProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWeb.Models
{
    public class ProductModel
    {
        public List<Urun> ulist { get; set; }
        public Urun Urun { get; set; }
    }
}