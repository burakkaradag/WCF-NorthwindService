using ClientWeb.Models;
using ClientWeb.ServiceProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWeb.Controllers
{
    public class LoginController : Controller
    {
        LoginModel model = new LoginModel();
        ServiceProduct.ServiceProductsClient servis = new ServiceProduct.ServiceProductsClient();

        [HttpGet]
        public ActionResult Login()
        {
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel lm)
        {
           UserDTO suc= servis.Login(lm.Email, lm.Password);
            if (suc !=null)
            {
                Session["User"] = lm.Email;
                Session["SupplierId"] = suc.supplierıd;
                Session["Role"] = suc.role;
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

    }
}