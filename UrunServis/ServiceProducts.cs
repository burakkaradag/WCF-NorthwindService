using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Northwind.DTO;
using Northwind.ENT;

namespace UrunServis
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ServiceProducts : IServiceProducts
    {
        NorthwindEntities db = new NorthwindEntities();

        public void DeleteProduct(int id)
        {
            Products p = db.Products.Find(id);
            p.Discontinued = true;
            db.SaveChanges();
        }



        public Urun GetOneProduct(int id)
        {
            Products p = db.Products.Find(id);
            Urun u = new Urun();
            u.UrunID = p.ProductID;
            u.UrunAd = p.ProductName;
            u.BirimFiyat = (decimal)p.UnitPrice;
            return u;
        }

        public Urun[] GetProducts(int supplierid, string role)
        {
            if (role == "KAM")
            {
                Urun[] ulist = db.Set<Products>().Select(x => new Urun
                {
                    UrunID = x.ProductID,
                    UrunAd = x.ProductName,
                    BirimFiyat = (decimal)x.UnitPrice,
                    SurumKodu = x.Discontinued

                }).Where(x => x.SurumKodu == false).ToArray();
                return ulist;
            }
            else if (true)
            {
                Urun[] ulist = db.Set<Products>().Select(x => new Urun
                {
                    UrunID = x.ProductID,
                    UrunAd = x.ProductName,
                    BirimFiyat = (decimal)x.UnitPrice,
                    SurumKodu = x.Discontinued,
                    Supplierıd=(int)x.SupplierID

                }).Where(x => x.SurumKodu == false && x.Supplierıd==supplierid).ToArray();
                return ulist;
            }
           


        }

        public UserDTO Login(string id, string pasword)
        {
            User user = db.User.Find(id);
            UserDTO userdto = new UserDTO();
            if (user != null)
            {
                if (user.Password == pasword)
                {
                    userdto.userıd = user.UserId;
                    userdto.role = user.Role;
                    userdto.supplierıd = (int)user.SupplierId;

                    return userdto;
                }
                else return null;
            }
            else
            {
                return null;
            }
        }

        public void UpdatePrice(int id, decimal fiyat)
        {
            Products p = db.Products.Find(id);
            p.UnitPrice = fiyat;
            db.SaveChanges();
        }
    }
}
