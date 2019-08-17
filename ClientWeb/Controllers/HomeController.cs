using ClientWeb.Models;
using ClientWeb.ServiceProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWeb.Controllers
{
    [UserAuthentication]
    public class HomeController : Controller
    {
       
        ServiceProduct.ServiceProductsClient servis = new ServiceProduct.ServiceProductsClient();
        ProductModel model = new ProductModel();
        
        public ActionResult Index()
        {
            int supplierıd = (int) Session["SupplierId"];
            string role = Session["Role"].ToString();
            model.ulist = servis.GetProducts(supplierıd,role).ToList();

            return View(model);
        }

        public ActionResult Detay()
        {
         

            return View(model);
        }
    }
}