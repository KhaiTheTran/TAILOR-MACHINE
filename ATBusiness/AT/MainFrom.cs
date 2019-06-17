using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AT
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        private void nhapKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to exit now?", "Exit Message!", MessageBoxButtons.OKCancel).ToString() == "OK")
            {
                Application.Exit();
            }          
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            label1.Text = "Xin Chao " + Universaler.password+" !";            
        }

        private void MainFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Ban Co That Su muong Thoat Khong?","Tin Nhan Xoa!",MessageBoxButtons.OKCancel).ToString()=="OK")
            {
            Application.Exit();
            }
        }

        private void tienLuongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TienLuongNhanCong tlnc = new TienLuongNhanCong();
            tlnc.MdiParent = this;
            tlnc.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Quan_Ly_Gio_Lam qlgl = new Quan_Ly_Gio_Lam();
            qlgl.MdiParent = this;
            qlgl.Show();
        }

        private void xuatKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKho qlk = new QuanLyKho();
            qlk.MdiParent = this;
            qlk.Show();
        }

        private void tongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoKinhDoanh bckd = new BaoCaoKinhDoanh();
            bckd.MdiParent = this;
            bckd.Show();
        }

        private void khachLauDaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.MdiParent = this;
            kh.Show();
        }

        private void nhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVien nv = new NhanVien();
            nv.MdiParent = this;
            nv.Show();
        }
        
    }
}