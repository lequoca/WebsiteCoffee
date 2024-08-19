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
    public partial class PhanHoi
    {
        [Display(Name = "Mã phản hồi")]
        public int MaPhanHoi { get; set; }
        [Display(Name = "Mã tài khoản")]
        public Nullable<int> MaTaiKhoan { get; set; }
        [Display(Name = "Đánh giá (1-5 sao)")]
        [Required(ErrorMessage = "Đánh giá không được để trống")]
        public Nullable<int> DanhGia { get; set; }
        [Display(Name = "Nhận xét")]
        [Required(ErrorMessage = "Nhận xét không được để trống")]
        public string NhanXet { get; set; }
    
        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}