﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteCoffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            this.ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }
    
        public int MaSanPham { get; set; }
        [Display(Name = "Tên sản phẩm (*)")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string TenSanPham { get; set; }
        [Display(Name = "Giá (*)")]
        [Required(ErrorMessage = "Giá khẩu không được để trống")]
        public decimal Gia { get; set; }
        [Display(Name = "Mã loại sản phẩm (*)")]
        [Required(ErrorMessage = "Mã loại sản phẩm không được để trống")]
        public Nullable<int> MaLoaiSP { get; set; }
        [Display(Name = "Mô tả (*)")]
        [Required(ErrorMessage = "Mô tả không được để trống")]
        public string MoTa { get; set; }
        [Display(Name = "Đường dẫn hình ảnh (*)")]
        [Required(ErrorMessage = "Đường dẫn hình ảnh không được để trống")]
        public string HinhAnh { get; set; }
        [Display(Name = "Mã nhà cung cấp (*)")]
        [Required(ErrorMessage = "Mã nhà cung cấp không được để trống")]
        public Nullable<int> MaNhaCungCap { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }
    }
}
