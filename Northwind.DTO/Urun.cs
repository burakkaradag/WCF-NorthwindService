using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DTO
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAd { get; set; }
        public decimal BirimFiyat { get; set; }
        public bool SurumKodu { get; set; }
        public int Supplierıd { get; set; }
    }
}
