﻿using QuanLyNhaSach.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyNhaSach.GUI
{
    public partial class FrmDangNhap : Form
    {
        public FrmDangNhap()
        {
            InitializeComponent();
        }
        BLLTaiKhoan BLLTaiKhoan = new BLLTaiKhoan();
        int count = 1;

        private void bDangNhap_Click(object sender, EventArgs e)
        {

            string username = txbTenDangNhap.Text;
            string password = txbMatKhau.Text;

            if (Login(username, password))
            {
                //FrmOverView f = new FrmOverView(txbTenDangNhap.Text);
                FrmOverView f = new FrmOverView(username);
                this.Hide(); 
                f.ShowDialog();
                this.Show();
            }
            else
            {
                count++;
                if (count <= 3)
                    MessageBox.Show("SAI TÊN ĐĂNG NHẬP HOẶC MẬT KHẨU!", "THÔNG BÁO");
                else
                {
                    DialogResult d;
                    d = MessageBox.Show("BẠN ĐÃ NHẬP SAI 3 LẦN LIÊN TIẾP. THOÁT CHƯƠNG TRÌNH ?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (d == DialogResult.Yes)
                    {
                        Application.ExitThread();
                    }  
                    count = 1;
                }
            }
        }

        bool Login(string username, string password)
        {
            if (BLLTaiKhoan.CheckUser(username, password)) return true;
            return false;
            //return AccountDAO.Instance.Login(username, password);
        }

        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Khi thoát chương trình sẽ được thông báo để quyết định có chắc chắn muốn thoát khỏi chương trình hay không
            if (MessageBox.Show("BẠN THẬT SỰ MUỐN THOÁT CHƯƠNG TRÌNH?","THÔNG BÁO", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }    
        }

        private void bThoat_Click(object sender, EventArgs e)
        {
            //Khi ấn nút thoát thì sẽ thoát khỏi chương trình
            Application.Exit();
        }

        private void imgShowHide_Click(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb != null)
            {
                if (txbMatKhau.PasswordChar == '*')
                {
                    pb.Image = Properties.Resources.Hide_Password_256;
                    txbMatKhau.PasswordChar = '\0';
                }
                else
                {
                    pb.Image = Properties.Resources.Show_Password_256;
                    txbMatKhau.PasswordChar = '*';
                }
            }
        }
    }
}
