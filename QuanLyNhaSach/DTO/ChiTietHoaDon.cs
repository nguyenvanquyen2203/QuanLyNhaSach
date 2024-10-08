﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.DTO
{
    internal class ChiTietHoaDon
    {
        private string maHoaDon;
        private string maSach;
        private int soLuong;
        private int giaTien;
        private int thanhTien;
        public string MAHOADON { get {  return maHoaDon; } set {  maHoaDon = value; } }
        public string MASACH { get { return maSach; } set { maSach = value; } }
        public int SOLUONG { get { return soLuong; } set { soLuong = value;  } }
        public int GIATIEN { get { return giaTien; } set { giaTien = value; } }
        public int THANHTIEN { get { return thanhTien; } set {  thanhTien = value; } }
        public ChiTietHoaDon() { }
        public ChiTietHoaDon(string maHoaDon, string maSach, int soLuong, int giaTien, int thanhTien)
        {
            this.maHoaDon = maHoaDon;
            this.maSach = maSach;
            this.soLuong = soLuong;
            this.giaTien = giaTien;
            this.thanhTien = thanhTien;
        }

    }
}
