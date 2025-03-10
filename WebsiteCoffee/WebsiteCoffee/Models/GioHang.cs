﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteCoffee.Models
{
    public class GioHang
    {
        WebsiteCoffeeEntities1 db = new WebsiteCoffeeEntities1();
        public int iMasp { get; set; }
        public string sTensp { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        public GioHang(int Masp)
        {
            iMasp = Masp;
            SanPham sp = db.SanPham.Single(n => n.MaSanPham == iMasp);
            sTensp = sp.TenSanPham;
            sAnhBia = sp.HinhAnh;
            dDonGia = double.Parse(sp.Gia.ToString());
            iSoLuong = 1;
        }
    }
}