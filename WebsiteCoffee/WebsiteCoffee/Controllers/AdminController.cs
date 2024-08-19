using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteCoffee.Models;
using System.Data.Entity;
namespace WebsiteCoffee.Controllers
{
    public class AdminController : Controller
    {
        WebsiteCoffeeEntities1 db = new WebsiteCoffeeEntities1();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(SanPham sp)
        {
            if(ModelState.IsValid)
            {
                db.SanPham.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }    
            else
            {
                return View("Index");
            }    
        }
        public ActionResult XoaSp(string search = "")
        {
            WebsiteCoffeeEntities1 db = new WebsiteCoffeeEntities1();
            List<SanPham> sp = db.SanPham.Where(row => row.TenSanPham.Contains(search)).ToList();
            return View(sp);        
        }

        public ActionResult Delete(int? id)
        {
            SanPham sp = db.SanPham.Where(row => row.MaSanPham == id).FirstOrDefault();
            db.SanPham.Remove(sp);
            db.SaveChanges();
            return View("XoaThanhCong");
        }
        public ActionResult SuaSp(string search = "")
        {
            WebsiteCoffeeEntities1 db = new WebsiteCoffeeEntities1();
            List<SanPham> sp = db.SanPham.Where(row => row.TenSanPham.Contains(search)).ToList();
            return View(sp);
        }
        public ActionResult IdSua(int? id)
        {
            SanPham sp = db.SanPham.Where(row => row.MaSanPham == id).FirstOrDefault();

            return View(sp);
        }
        [HttpPost]
        public ActionResult IdSua(SanPham sua)
        {
            // Tìm sản phẩm theo MaSanPham
            SanPham sp = db.SanPham.Where(row => row.MaSanPham == sua.MaSanPham).FirstOrDefault();

            // Cập nhật thông tin sản phẩm
            sp.TenSanPham = sua.TenSanPham;
            sp.Gia = sua.Gia;
            sp.MaLoaiSP = sua.MaLoaiSP;
            sp.MoTa = sua.MoTa;
            sp.HinhAnh = sua.HinhAnh;
            sp.MaNhaCungCap = sua.MaNhaCungCap;

            // Lưu thay đổi vào cơ sở dữ liệu
            db.SaveChanges();

            // Chuyển hướng về trang chủ hoặc danh sách sản phẩm
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Chitiet(int? id)
        {
            WebsiteCoffeeEntities1 db = new WebsiteCoffeeEntities1();
            SanPham sp = db.SanPham.Where(row => row.MaSanPham == id).FirstOrDefault();
            return View(sp);
        }
        public ActionResult XemDonHang()
        {
            // Lấy danh sách tất cả các đơn hàng
            var donHangList = db.DonHang
                .Include("ChiTietDonHang.SanPham") // Bao gồm thông tin chi tiết đơn hàng và sản phẩm
                .ToList();

            return View(donHangList);
        }
        [HttpPost]
        public ActionResult CapNhatTinhTrang(int id)
        {
            // Tìm đơn hàng theo id
            var donHang = db.DonHang.Find(id);
            if (donHang != null)
            {
                // Cập nhật tình trạng đơn hàng
                donHang.TinhTrang = 0;
                db.SaveChanges();
            }

            // Trở lại view XemDonHang sau khi cập nhật
            return RedirectToAction("XemDonHang");
        }

        // Phương thức để hiển thị chi tiết đơn hàng
        // Phương thức để hiển thị chi tiết đơn hàng
        public ActionResult ChiTietDonHang(int id)
        {
            // Lấy đơn hàng cùng với chi tiết đơn hàng và sản phẩm liên quan
            var donHang = db.DonHang
                .Include(dh => dh.ChiTietDonHang.Select(ct => ct.SanPham)) // Bao gồm chi tiết đơn hàng và sản phẩm
                .SingleOrDefault(dh => dh.MaDonHang == id);

            if (donHang == null)
            {
                return HttpNotFound(); // Trả về lỗi 404 nếu không tìm thấy đơn hàng
            }

            return View(donHang);
        }
        public ActionResult XemPhanHoi()
        {
            // Lấy danh sách phản hồi từ cơ sở dữ liệu
            var phanHoiList = db.PhanHoi.ToList();

            // Chuyển danh sách phản hồi đến view
            return View(phanHoiList);
        }


    }
}