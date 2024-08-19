using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteCoffee.Models;

namespace WebsiteCoffee.Controllers
{
    public class HomeController : Controller
    {
        WebsiteCoffeeEntities1 db = new WebsiteCoffeeEntities1();
        // GET: Home
        public ActionResult Index(string search ="")
        {
            
            List<SanPham> sp = db.SanPham.Where(row => row.TenSanPham.Contains(search)).ToList();
            return View(sp);
        }
    }
}