using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AT
{
    public partial class TienLuongNhanCong : Form
    {
        public TienLuongNhanCong()
        {
            InitializeComponent();
        }
        int flat_searchc = 0;
        int flat_searchn = 0;
        string hoten_str;
        int f = 0;
        
        //connection
        SqlConnection conn;
        SqlCommand comd;
        SqlCommand comd1;
        SqlDataAdapter adap;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        //
        public void update()
        {
            try
            {
                conn = Universaler.Communicate();
                comd1 = new SqlCommand("select *  from GioLamTongCong", conn);
                adap = new SqlDataAdapter(comd1);
                ds1.Clear();
                adap.Fill(ds1, "data");
                dataGridView2.DataSource = ds1;
                dataGridView2.DataMember = "data";
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
                comd1 = new SqlCommand("select * from GioLamTongCong where maso = " + Convert.ToInt16(num_Maso.Value), conn);
                adap = new SqlDataAdapter(comd1);
                ds1.Clear();
                adap.Fill(ds1, "data");
                dataGridView2.DataSource = ds1;
                dataGridView2.DataMember = "data";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
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

        public void tienluong()
        {
          
            int sogiongay = 0;
            int sophutngay = 0;
            int giocong = 0;
            string ntn = dt_luong.Text.Trim();
            int f = 0;
            //int i=ntn.IndexOf('/');
		   string strngay=ntn.Substring(0,2);
           string strthang = ntn.Substring(3,2);
           string strname = ntn.Substring(6,4);
            //
            string ntn2 = dt_luong2.Text.Trim();
            //int i=ntn.IndexOf('/');
		   string strngay2=ntn2.Substring(0,2);
           string strthang2 = ntn2.Substring(3,2);
           string strname2 = ntn2.Substring(6,4);
            //
           double tiennodouble = 0;
           double tientratruocdoub = 0;
           double tientrengiodoub = 0;
            //
           int flat = 0;
            //
            try
               {
                   tiennodouble = Convert.ToDouble(Tien_No.Text.ToString());
               }
               catch (Exception ex)
               {                 
                   flat = 2;
                   Console.WriteLine(ex.ToString());
               }
               try
               {
                   tientratruocdoub = Convert.ToDouble(Tratruoc.Text.ToString());
               }
               catch (Exception ex)
               {
                   
                   flat = 2;
                   Console.WriteLine(ex.ToString());
               }
               try
               {
                   tientrengiodoub = Convert.ToDouble(TientrenGio.Text.ToString());
               }
               catch (Exception ex)
               {
                   
                   flat = 2;
                   Console.WriteLine(ex.ToString());
               }
           
            //
               if (flat == 2)
               {
                   MessageBox.Show("Ban nen nhap Tien theo kieu so vao!");
               }else
           {
               if (MessageBox.Show("Ban muon tinh tu ngay " + strngay + " nay den ngay " + strngay2 + " phai khong?", "Tin nhan nghi van!", MessageBoxButtons.OKCancel).ToString() == "OK")
               {
                   try
                   {
                       conn = Universaler.Communicate();

                       comd1 = new SqlCommand("select sum(TongGioNgay) from GioLamThucTe where rtrim(DaPhatLuong) = 'Chua' and rtrim(Ngay) >= " + strngay + " and rtrim(Ngay) <= " + strngay2 + " and rtrim(Thang) = " + strthang + " and rtrim(Nam) = " + strname + " and  maso = " + Convert.ToInt16(num_Maso.Value), conn);
                       comd = new SqlCommand("select sum(TongPhutNgay) from GioLamThucTe where rtrim(DaPhatLuong) = 'Chua' and rtrim(Ngay) >= " + strngay + " and rtrim(Ngay) <= " + strngay2 + " and rtrim(Thang) = " + strthang + " and rtrim(Nam) = " + strname + " and  maso = " + Convert.ToInt16(num_Maso.Value), conn);
                       conn.Open();
                       sogiongay = Convert.ToInt16(comd1.ExecuteScalar());
                       sophutngay = Convert.ToInt16(comd.ExecuteScalar());
                       conn.Close();
                   }
                   catch (Exception ex)
                   {
                       f = 2;
                       MessageBox.Show("Hinh nhu Ban CHUA chon dung thoi gian!");
                       Console.WriteLine(ex);
                   }
                   if (f == 0)
                   {
                       if (sophutngay >= 60)
                       {
                           int so = 0;
                           so = sophutngay / 60;
                           sogiongay = sogiongay + so;
                           sophutngay = sophutngay - 60 * so;
                       }
                       if (sogiongay < 75)
                       {
                           if (sogiongay >= 54)
                           {
                               giocong = giocong + 36;
                           }
                           if (sogiongay >= 60)
                           {
                               giocong = giocong + 14;
                           }
                           if (sogiongay >= 65)
                           {
                               giocong = giocong + 10;
                           }
                           if (sogiongay >= 70)
                           {
                               giocong = giocong + 20;
                           }
                       }
                       else
                       {
                           if (sogiongay >= 75)
                           {
                               giocong = giocong + 20;
                           }
                           if (sogiongay >= 85)
                           {
                               giocong = giocong + 40;
                           }
                           if (sogiongay >= 95)
                           {
                               giocong = giocong + 50;
                           }
                           if (sogiongay >= 105)
                           {
                               giocong = giocong + 90;
                           }
                       }
                       int giothuclam = sogiongay;
                       sogiongay = sogiongay + giocong;
                       string conggiophut = sogiongay.ToString() + "." + sophutngay.ToString();
                       conggiophut.Trim();
                       
                       double typefloatgiophut = Convert.ToDouble(conggiophut);
                       double tienluong = typefloatgiophut * tientrengiodoub;
                       L_tienluong.Text = tienluong.ToString();
                       Tonggiotuan.Text = conggiophut;
                       int tongsongayluong = 0;
                           try
                           {
                               conn = Universaler.Communicate();
                               
                               comd = new SqlCommand("select count(maso) from GioLamThucTe where rtrim(DaPhatLuong) = 'Chua' and rtrim(Ngay) >= " + strngay + " and rtrim(Ngay) <= " + strngay2 + " and rtrim(Thang) = " + strthang + " and rtrim(Nam) = " + strname + " and  maso = " + Convert.ToInt16(num_Maso.Value), conn);
                               conn.Open();                               
                               tongsongayluong = Convert.ToInt16(comd.ExecuteScalar());
                               conn.Close();
                           }
                           catch (Exception ex)
                           {
                               tongsongayluong = 0;
                               MessageBox.Show("Hinh nhu Ban CHUA chon dung thoi gian!");
                               Console.WriteLine(ex);
                           }
                       //
                           int tuan = 0;
                           try
                           {
                               conn = Universaler.Communicate();
                               conn.Open();
                               comd1 = new SqlCommand("select max(TuanThu) from GioLamTongCong where maso = " + Convert.ToInt16(num_Maso.Value), conn);

                               tuan = Convert.ToInt16(comd1.ExecuteScalar());
                               conn.Close();

                           }
                           catch (Exception ex)
                           {
                               tuan = 0;
                               Console.WriteLine(ex);
                           }
                           tuan = tuan + 1;
                       //
                           if (MessageBox.Show("Co phai Tien Tren Gio cua NV nay la "+tientrengiodoub.ToString()+"?", "Tin nhan nghi van!", MessageBoxButtons.OKCancel).ToString() == "OK")
                           {
                               //
                               if (MessageBox.Show("Ban muon tra tien no khong?", "Tin nhan try van!", MessageBoxButtons.OKCancel).ToString() == "OK")
                               {

                                   if (tientratruocdoub > tienluong)
                                   {
                                       MessageBox.Show("Ban khong the tra so tien lon hon so tien ban hien co!");
                                   }
                                   else
                                   {
                                       tienluong = tienluong - tiennodouble;
                                       L_tienluong.Text = tienluong.ToString();
                                       

                                       try
                                       {
                                           conn = Universaler.Communicate();
                                           int k = Convert.ToInt16(num_Maso.Value);
                                           comd = new SqlCommand("set dateformat dmy insert into GioLamTongCong values(" + k + ",'" + comboBox_hoten.Text + "'," + tuan + ",'" + giothuclam.ToString() + "','" + giocong.ToString() + "','" + sogiongay.ToString() + "'," + tongsongayluong.ToString() + "," + tiennodouble.ToString() + "," + tientrengiodoub.ToString() + "," + tienluong.ToString() + ",0,'Chua','" + dateTimePicker1.Text.ToString() + "','" + ntn + "','" + ntn2 + "')", conn);

                                           conn.Open();
                                           comd.ExecuteNonQuery();
                                           conn.Close();
                                           MessageBox.Show("Ban da luu du lieu thanh cong!");

                                       }
                                       catch (Exception ex)
                                       {
                                           MessageBox.Show("Ban da luu du lieu Khong thanh cong!");
                                           //MessageBox.Show(ex.Message);
                                           Console.WriteLine(ex);
                                       }
                                   }
                               }
                               else
                               {
                                   try
                                   {
                                       conn = Universaler.Communicate();
                                       int k = Convert.ToInt16(num_Maso.Value);
                                       comd = new SqlCommand("set dateformat dmy insert into GioLamTongCong values(" + k + ",'" + comboBox_hoten.Text + "'," + tuan + ",'" + giothuclam.ToString() + "','" + giocong.ToString() + "','" + sogiongay.ToString() + "'," + tongsongayluong.ToString() + "," + tiennodouble.ToString() + "," + tientrengiodoub.ToString() + "," + tienluong.ToString() + ",0,'Chua','" + dateTimePicker1.Text.ToString() + "','" + ntn + "','" + ntn2 + "')", conn);

                                       conn.Open();
                                       comd.ExecuteNonQuery();
                                       conn.Close();
                                       MessageBox.Show("Ban da luu du lieu thanh cong!");

                                   }
                                   catch (Exception ex)
                                   {
                                       MessageBox.Show("Ban da luu du lieu Khong thanh cong!");
                                      // MessageBox.Show(ex.Message);
                                       Console.WriteLine(ex);
                                   }
                               }
                           }
                   }

               }
           }

        }
        private void TienLuongNhanCong_Load(object sender, EventArgs e)
        {
            update();
        }

        private void comboBox_hoten_Leave(object sender, EventArgs e)
        {
            flat_searchc = 1;
            flat_searchn = 0;
            hoten_str = comboBox_hoten.Text.Trim();
        }

        private void comboBox_hoten_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            selectserach();
        }

        private void num_Maso_ValueChanged(object sender, EventArgs e)
        {
            flat_searchc = 0;
            flat_searchn = 1;
            
        }

        private void but_timkiem_Click(object sender, EventArgs e)
        {            
            timkiem();
            updateNV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tienluong();
            updateNV();
        }

        
    }
}