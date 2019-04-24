using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace AT
{
    public partial class Quan_Ly_Gio_Lam : Form
    {
        public Quan_Ly_Gio_Lam()
        {
            InitializeComponent();
        }
        int tonggiosang = 0;
        int tonggiochieu = 0;
        int tonggiotoi = 0;
        int tongphutsang = 0;
        int tongphutchieu = 0;
        int tongphuttoi = 0;
        int tonggiongay = 0;
        int tongphutngay = 0;
        int giodiche = 0;
        int phutdiche = 0;
        //
        int tong_g_cn=0;
        int tong_ph_cn = 0;
        //
        int tonggiogiailao = 0;
        int tongphutgiailao = 0;
        //
        int tonggiogiailao1 = 0;
        int tongphutgiailao1 = 0;
        //
        int flat = 0;
        int flat_searchc = 0;
        int flat_searchn = 0;
        int id = 0;
        int f = 0;
        int k = 0;
        int update_button = 0;
        string hoten_str;
        string stridtt;

        //connection
        SqlConnection conn;
        SqlCommand comd;
        SqlCommand comd1;
        SqlDataAdapter adap;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        public void clear()
        {
            giolchieu.Value = 0;
            Giolsang.Value = 0;
            gioltoi.Value = 0;
            gionghichieu.Value = 0;
            gionghisang.Value = 0;
            gionghitoi.Value = 0;

            phutlamtoi.Value = 0;
            phutlchieu.Value = 0;
            phutLsang.Value = 0;
            phutnghichieu.Value = 0;
            phutnghisang.Value = 0;
            phutnghitoi.Value = 0;
            num_chunhat_g_L.Value = 0;
            num_cn_g_nghi.Value = 0;
            num_cn_ph_L.Value = 0;
            num_cn_ph_nghi.Value = 0;
        }
        public void cleargiailao()
        {
            gionghigiaiLao.Value = 0;
            phutnghigiaiLao.Value = 0;
            Giolamlai.Value = 0;
           PhutLamlai.Value = 0;
        }

        public void tinh()
        {
             tonggiosang = 0;
             tonggiochieu = 0;
             tonggiotoi = 0;
             tongphutsang = 0;
             tongphutchieu = 0;
             tongphuttoi = 0;
             tonggiongay = 0;
             tongphutngay = 0;
             giodiche = 0;
             phutdiche = 0;
            //
             tong_g_cn = 0;
             tong_ph_cn = 0;
            //
            int giolsang1 = Convert.ToInt16(Giolsang.Value);
            int gioghisang1 = Convert.ToInt16(gionghisang.Value);
            //
            int giolchieu1 = Convert.ToInt16(giolchieu.Value);
            int gionghichieu1 = Convert.ToInt16(gionghichieu.Value);
            //
            int gioltoi1 = Convert.ToInt16(gioltoi.Value);
            int gionghitoi1 = Convert.ToInt16(gionghitoi.Value);
            //
            //
            int phutLsang1 = Convert.ToInt16(phutLsang.Value);
            int phutnghisang1 = Convert.ToInt16(phutnghisang.Value);
            //
            int phutlchieu1 = Convert.ToInt16(phutlchieu.Value);
            int phutnghichieu1 = Convert.ToInt16(phutnghichieu.Value);
            //
            int phutlamtoi1 = Convert.ToInt16(phutlamtoi.Value);
            int phutnghitoi1 = Convert.ToInt16(phutnghitoi.Value);
            //
            int cn_g_l = Convert.ToInt16(num_chunhat_g_L.Value);
            int cn_g_nghi = Convert.ToInt16(num_cn_g_nghi.Value);
            int cn_ph_L = Convert.ToInt16(num_cn_ph_L.Value);
            int cn_ph_nghi = Convert.ToInt16(num_cn_ph_nghi.Value);
            //
            string ntn = dateTimePicker1.Text.Trim();
            //int i=ntn.IndexOf('/');
		   string strngay=ntn.Substring(0,2);
           string strthang = ntn.Substring(3,2);
           string strname = ntn.Substring(6,4);
           flat = -1;
             try
             {
                 conn = Universaler.Communicate();
                 conn.Open();
                 comd1 = new SqlCommand("select NhanCong.maso from GioLamThucTe,NhanCong where rtrim(GioLamThucTe.Ngay)=" + strngay.Trim() + " and rtrim(GioLamThucTe.Thang)=" + strthang.Trim() + " and rtrim(GioLamThucTe.Nam)=" + strname.Trim() + " and  GioLamThucTe.maso = NhanCong.maso and  GioLamThucTe.maso = "+Convert.ToInt16(num_Maso.Value), conn);

                 flat = Convert.ToInt16(comd1.ExecuteScalar());
                 conn.Close();
                 
             }
             catch (Exception ex)
             {
                 flat = -1;
                 Console.WriteLine(ex);
             }                                   
            //           
            tonggiosang = gioghisang1 - giolsang1;
            //
            tonggiochieu = gionghichieu1 - giolchieu1;
            //
            tonggiotoi = gionghitoi1 - gioltoi1;
            //
            tong_g_cn = cn_g_nghi - cn_g_l;
            //
            if (cn_ph_nghi >= cn_ph_L)
            {
                tong_ph_cn = cn_ph_nghi - cn_ph_L;
            }
            else
            {
                tong_ph_cn = 60 + cn_ph_nghi - cn_ph_L;
                tong_g_cn = tong_g_cn - 1;
            }
            //

            if (phutnghisang1 >= phutLsang1)
            {
                tongphutsang = phutnghisang1 - phutLsang1;
            }
            else
            {
                tongphutsang = 60 + phutnghisang1 - phutLsang1;
                tonggiosang = tonggiosang - 1;
            }
            //
            if (phutnghichieu1 >= phutlchieu1)
            {
                tongphutchieu = phutnghichieu1 - phutlchieu1;
            }
            else
            {
                tongphutchieu = 60 + phutnghichieu1 - phutlchieu1;
                tonggiochieu = tonggiochieu - 1;
            }
            //
            if (phutnghitoi1 >= phutlamtoi1)
            {
                tongphuttoi = phutnghitoi1 - phutlamtoi1;
            }
            else
            {
                tongphuttoi = 60 + phutnghitoi1 - phutlamtoi1;
                tonggiotoi = tonggiotoi - 1;
            }
            //
            tonggiotoi = tonggiotoi * 3;
            tongphuttoi = tongphuttoi * 3;
            //
            tong_g_cn = tong_g_cn * 2;
            tong_ph_cn = tong_ph_cn * 2;
            //
            LTongGioSang.Text = tonggiosang.ToString();
            Ltonggiochieu.Text = tonggiochieu.ToString();
            Ltonggiotoi.Text = tonggiotoi.ToString();
            //
            LTongphutsang.Text = tongphutsang.ToString();
            LTongphutchieu.Text = tongphutchieu.ToString();
            Ltongphuttoi.Text = tongphuttoi.ToString();
            //
            L_cn_gio.Text = tong_g_cn.ToString();
            L_cn_phut.Text = tong_ph_cn.ToString();
            // tinh tong gio lam trong ngay
            tonggiongay = tonggiosang + tonggiochieu + tonggiotoi + tong_g_cn;
            tongphutngay = tongphutsang + tongphutchieu + tongphuttoi + tong_ph_cn;
            if (giolsang1 > 7 || phutLsang1 > 0)
            {
                giodiche = giolsang1 - 7;
                phutdiche = phutLsang1;

            }

            tonggiongay = tonggiongay - giodiche - tonggiogiailao1;
            
            //
            if (tongphutngay >= phutdiche)
            {
                tongphutngay = tongphutngay - phutdiche;
            }
            else
            {
                tongphutngay = 60 + tongphutngay - phutdiche;
                tonggiongay = tonggiosang - 1;
            }
            //
            if (tongphutngay >= tongphutgiailao1)
            {
                tongphutngay = tongphutngay - tongphutgiailao1;
            }
            else
            {
                tongphutngay = 60 + tongphutngay - tongphutgiailao1;
                tonggiongay = tonggiongay - 1;
            }
            //
            if (tongphutngay >= 60)
            {
                int so = 0;
                so = tongphutngay / 60;
                tonggiongay = tonggiongay + so;
                tongphutngay = tongphutngay - 60 * so;
            }
            //
            L_To_gio_L_ngay.Text = tonggiongay.ToString();
            L_to_ph_L_ngay.Text = tongphutngay.ToString();
            //// Ket noi va ghi du lieu vao may

            if (gioghisang1 < giolsang1)
            {
                MessageBox.Show("Xin nhap Gio Nghi Sang dung vao!");
            }
            else if (gionghichieu1 < giolchieu1)
            {
                MessageBox.Show("Xin nhap Gio Nghi Chieu dung vao!");
            }
            else if (gionghitoi1 < gioltoi1)
            {
                MessageBox.Show("Xin nhap Gio Nghi Toi dung vao!");
            }
            else if (cn_g_nghi < cn_g_l)
            {
                MessageBox.Show("Xin nhap Gio Nghi Chu Nhat dung vao!");
            }
            else  if (MessageBox.Show("Ban co Chon ngay nay " + ntn + " khong?", "Tin nhan Cap Nhat!", MessageBoxButtons.OKCancel).ToString() == "OK")
            {
                if (update_button == 1)
                {
                    try
                    {
                        conn = Universaler.Communicate();
                        int k = Convert.ToInt16(num_Maso.Value);
                        comd = new SqlCommand("update GioLamThucTe set GioLamSang='" + giolsang1 + "',PhutLamSang='" + phutLsang1 + "',GioNghiSang='" + gioghisang1 + "',PhutNghiSang='" + phutnghisang1 + "',GioLamChua='" + giolchieu1 + "',PhutLamChua='" + phutlchieu1 + "',GioNghiChua='" + gionghichieu1 + "',PhutNghiChua='" + phutnghichieu1 + "',GioLamToi='" + gioltoi1 + "',PhutLamToi='" + phutlamtoi1 + "',GioNghiToi='" + gionghitoi1 + "',PhutNghiToi='" + phutnghitoi1 + "',CNGioLam='" + cn_g_l + "',CNphutLam='" + cn_ph_L + "',CNGIoNghi='" + cn_g_nghi + "',CNphutNghi='" + cn_ph_nghi + "',TongGioGiaiLao='" + tonggiogiailao1 + "',TongPhuGiaiLao='" + tongphutgiailao1 + "',TongGioNgay='" + tonggiongay + "',TongPhutNgay='" + tongphutngay + "',Ngay=" + strngay + ",Thang=" + strthang + ",Nam=" + strname + " where rtrim(IDTT)=" + stridtt.Trim(), conn);

                        conn.Open();
                        comd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Ban da cap nhat du lieu thanh cong!");
                        updateNV();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ban da Cap Nhat du lieu Khong thanh cong!");
                        MessageBox.Show(ex.Message);
                        //Console.WriteLine(ex);
                    }

                }
                else if (flat > 0)
                {
                    MessageBox.Show("Nhan Vien nay da nhap thoi gian lam viet vao ngay nay roi!");
                }
                else
                {
                    try
                    {
                        conn = Universaler.Communicate();
                        int k = Convert.ToInt16(num_Maso.Value);
                        comd = new SqlCommand("insert into GioLamThucTe values(" + k + ",'" + comboBox_hoten.Text + "','" + giolsang1.ToString() + "','" + phutLsang1.ToString() + "','" + gioghisang1.ToString() + "','" + phutnghisang1 + "','" + giolchieu1.ToString() + "','" + phutlchieu1.ToString() + "','" + gionghichieu1.ToString() + "','" + phutnghichieu1.ToString() + "','" + gioltoi1.ToString() + "','" + phutlamtoi1.ToString() + "','" + gionghitoi1.ToString() + "','" + phutnghitoi1.ToString() + "','" + cn_g_l.ToString() + "','" + cn_ph_L.ToString() + "','" + cn_g_nghi.ToString() + "','" + cn_ph_nghi.ToString() + "','" + tonggiogiailao1.ToString() + "','" + tongphutgiailao1.ToString() + "','" + tonggiongay.ToString() + "','" + tongphutngay.ToString() + "','Chua'," + strngay + "," + strthang + "," + strname + ")", conn);

                        conn.Open();
                        comd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Ban da luu du lieu thanh cong!");
                        updateNV();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ban da luu du lieu Khong thanh cong!");
                        //MessageBox.Show(ex.Message);
                        Console.WriteLine(ex);
                    }
                }
            }
        }


        public void selectserach()
        {

            string str_Hoten = comboBox_hoten.Text.Trim().ToString();
            f = 0;
            try
            {
                conn = Universaler.Communicate();
                comd1 = new SqlCommand("select Maso from NhanCong where rtrim(HoTen)= '" + str_Hoten + "'", conn);
                conn.Open();
                f = Convert.ToInt16(comd1.ExecuteScalar());
                conn.Close();
                num_Maso.Value = f;
            }
            catch (Exception ex)
            {
              
                MessageBox.Show("Nhan Vien Nay khong co!");
                Console.WriteLine(ex);
            }
            

        }
            public void tinhgiogi_l()
        {
            tonggiogiailao = 0;
            tongphutgiailao = 0;
            if (Convert.ToInt16(gionghigiaiLao.Value) > Convert.ToInt16(Giolamlai.Value))
            {
                MessageBox.Show("Xin nhap Gio Lam Lai dung vao!");
            }
            else
            {
                int gio_g_L = Convert.ToInt16(gionghigiaiLao.Value);
                int gio_lam_l = Convert.ToInt16(Giolamlai.Value);
                int phut_gi_l = Convert.ToInt16(phutnghigiaiLao.Value);
                int phut_lam_l = Convert.ToInt16(PhutLamlai.Value);
                //
                tonggiogiailao = gio_lam_l - gio_g_L;

                //
                if (phut_lam_l >= phut_gi_l)
                {
                    tongphutgiailao = phut_lam_l - phut_gi_l;
                }
                else
                {
                    tongphutgiailao = 60 + phut_lam_l - phut_gi_l;
                    tonggiogiailao = tonggiogiailao - 1;
                }
                tongphutgiailao1 = tongphutgiailao1 + tongphutgiailao;
                tonggiogiailao1 = tonggiogiailao1 + tonggiogiailao;
                //
                if (tongphutgiailao1 >= 60)
                {
                    int so = 0;
                    so = tongphutgiailao1 / 60;
                    tonggiogiailao1 = tonggiogiailao1 + so;
                    tongphutgiailao1 = tongphutgiailao1 - 60 * so;
                }
                //
                L_gio_giailao.Text = tonggiogiailao1.ToString();
                L_phut_giailao.Text = tongphutgiailao1.ToString();
            }
        }
        public void update()
        {
            try
            {
                conn = Universaler.Communicate();
                comd1 = new SqlCommand("select IDTT,Maso,HoTen,GioLamSang,PhutLamSang,GioNghiSang,PhutNghiSang,GioLamChua,PhutLamChua,GioNghiChua,PhutNghiChua,GioLamToi,PhutLamToi,GioNghiToi,PhutNghiToi,CNGioLam,CNphutLam,CNGIoNghi,CNphutNghi,TongGioGiaiLao,TongPhuGiaiLao,TongGioNgay,TongPhutNgay,DaPhatLuong,Ngay,Thang,Nam from GioLamThucTe", conn);
                adap = new SqlDataAdapter(comd1);
                ds1.Clear();
                adap.Fill(ds1, "data");
                dataGridView1.DataSource = ds1;
                dataGridView1.DataMember = "data";               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void updateNV()
        {

            try
            {
                conn = Universaler.Communicate();
                comd1 = new SqlCommand("select * from GioLamThucTe where maso = "+Convert.ToInt16(num_Maso.Value), conn);
                adap = new SqlDataAdapter(comd1);
                ds1.Clear();
                adap.Fill(ds1, "data");
                dataGridView1.DataSource = ds1;
                dataGridView1.DataMember = "data";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void timkiem()
        {
            if (flat_searchn == 1)
            {

                try
                {
                    conn = Universaler.Communicate();
                    int k = Convert.ToInt16(num_Maso.Value);
                    comd1 = new SqlCommand("select maso from NhanCong where rtrim(maso)=" + k, conn);
                    comd = new SqlCommand("select HoTen from NhanCong where rtrim(maso)=" + k, conn);
                    conn.Open();
                    f = Convert.ToInt16(comd1.ExecuteScalar());
                    string strhoten = Convert.ToString(comd.ExecuteScalar());
                    conn.Close();
                    comboBox_hoten.Text = strhoten;
                }
                catch (Exception ex)
                {
                    f = 0;                    
                    Console.WriteLine(ex);
                }

                ////
                if (f == 0)
                {
                    MessageBox.Show("Ma so Nay khong co!");
                }


            }
            else if (flat_searchc == 1)
            {

                try
                {




                    conn = Universaler.Communicate();
                    ds.Clear();
                    comd1 = new SqlCommand("select HoTen from NhanCong where rtrim(HoTen) like '" + hoten_str + "%'", conn);
                    adap = new SqlDataAdapter(comd1);
                    adap.Fill(ds, "NhanCong");
                    comboBox_hoten.DataSource = ds.Tables["NhanCong"];
                    comboBox_hoten.DisplayMember = "HoTen";



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nhan Vien Nay khong co!");
                    //MessageBox.Show(ex.Message);
                    Console.WriteLine(ex);
                }
                selectserach();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //
            update_button = 0;
            tinh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
            tonggiogiailao1 = 0;
            tongphutgiailao1 = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tinhgiogi_l();
            cleargiailao();
        }
        
        private void Quan_Ly_Gio_Lam_Load(object sender, EventArgs e)
        {
            update();
        }       

        private void num_Maso_ValueChanged(object sender, EventArgs e)
        {
            flat_searchc = 0;
            flat_searchn = 1;
        }
             
        private void comboBox_hoten_Leave(object sender, EventArgs e)
        {
            flat_searchc = 1;
            flat_searchn = 0;
            hoten_str = comboBox_hoten.Text.Trim();
        }

        private void but_timkiem_Click(object sender, EventArgs e)
        {
            timkiem();
            updateNV();
        
        }

        private void comboBox_hoten_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectserach();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id;
            id = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            if (MessageBox.Show("Ban co muon xoa khong?", "Tin nhan xoa!", MessageBoxButtons.OKCancel).ToString() == "OK")
            {

                try
                {
                    conn = Universaler.Communicate();
                    comd1 = new SqlCommand(" delete GioLamThucTe where rtrim(IDTT)=" +id, conn);
                    conn.Open();
                    comd1.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Ban da Soa du lieu thanh cong!");

                    update();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Ban da Soa du lieu khong thanh cong!");
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {

            stridtt = Convert.ToString(dataGridView1.Rows[e.Cell.RowIndex].Cells[0].Value);
            num_Maso.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[1].Value);
           comboBox_hoten.Text = Convert.ToString(dataGridView1.Rows[e.Cell.RowIndex].Cells[2].Value);
           Giolsang.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[3].Value);
           phutLsang.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[4].Value);
           gionghisang.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[5].Value);
           phutnghisang.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[6].Value);
           giolchieu.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[7].Value);
           phutlchieu.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[8].Value);
           gionghichieu.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[9].Value);
           phutnghichieu.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[10].Value);
           gioltoi.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[11].Value);
           phutlamtoi.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[12].Value);
           gionghitoi.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[13].Value);
           phutnghitoi.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[14].Value);
           num_chunhat_g_L.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[15].Value);
            num_cn_ph_L.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[16].Value);
            num_cn_g_nghi.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[17].Value);
            num_cn_ph_nghi.Value = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[18].Value);
            tonggiogiailao1 = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[19].Value);
            tongphutgiailao1 = Convert.ToInt16(dataGridView1.Rows[e.Cell.RowIndex].Cells[20].Value);
            L_gio_giailao.Text = tonggiogiailao1.ToString();
            L_phut_giailao.Text = tongphutgiailao1.ToString();
            
        }

        private void but_xoa_sach_Click(object sender, EventArgs e)
        {
            update_button = 1;
            tinh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cleargiailao();           
        }
       
    }
}