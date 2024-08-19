using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteCoffee.Models;
namespace WebsiteCoffee.Controllers
{
    public class DanhSachSpController : Controller
    {
        // GET: DanhSachSp
        public ActionResult CaPhe(string search="")
        {
            WebsiteCoffeeEntities1 db = new WebsiteCoffeeEntities1();
            List<SanPham> sp = db.SanPham.Where(row => row.TenSanPham.Contains(search)).ToList();
            return View(sp);
        }
        public ActionResult Tra(string search = "")
        {
            WebsiteCoffeeEntities1 db = new WebsiteCoffeeEntities1();
            List<SanPham> sp = db.SanPham.Where(row => row.TenSanPham.Contains(search)).ToList();
            return View(sp);
        }
        public ActionResult Nuocep(string search = "")
        {
            WebsiteCoffeeEntities1 db = new WebsiteCoffeeEntities1();
            List<SanPham> sp = db.SanPham.Where(row => row.TenSanPham.Contains(search)).ToList();
            return View(sp);
        }
        public ActionResult Daxay(string search = "")
        {
            WebsiteCoffeeEntities1 db = new WebsiteCoffeeEntities1();
            List<SanPham> sp = db.SanPham.Where(row => row.TenSanPham.Contains(search)).ToList();
            return View(sp);
        }
        public ActionResult Sinhto(string search = "")
        {
            WebsiteCoffeeEntities1 db = new WebsiteCoffeeEntities1();
            List<SanPham> sp = db.SanPham.Where(row => row.TenSanPham.Contains(search)).ToList();
            return View(sp);
        }
    }
}