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
    public partial class NhanVien : Form
    {
        SqlConnection conn;
        SqlCommand comd;
        SqlCommand comd1;
        int nv_id;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        SqlDataAdapter adap;
        SqlDataAdapter adap1;
        public NhanVien()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        
        public void update()
        {
            try
            {
                conn= Universaler.Communicate();
                comd1 = new SqlCommand("select Maso,HoTen,DiaChi,GioiTinh,HomePhone,DiDong,ChucDanh from nhancong", conn);
                adap = new SqlDataAdapter(comd1);
                ds.Clear();
                adap.Fill(ds, "data");
              dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "data";
                /////////////////////////////
                comd = new SqlCommand("select Maso,Hoten,NgayVoLam,NgayNghi,GhiChu from LylichNhanCong", conn);
                adap1 = new SqlDataAdapter(comd);
                ds1.Clear();
                adap1.Fill(ds1, "data");
                dataGridView2.DataSource = ds1;
                dataGridView2.DataMember = "data";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void clearlylich()
        {
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

            richTextBox1.Text = "";
        }
        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            hihe_text.Text = "";
            comboBox1.Text = "";
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            update();
        }               
       
        private void button1_Click_1(object sender, EventArgs e)
        {
            string tet1 = textBox1.Text;
            string gioitinh;
            gioitinh= comboBox1.SelectedItem.ToString();
            string tet2 = textBox2.Text;
            string tet3 = textBox3.Text;
            string tet4 = textBox4.Text;
            string tet5 = textBox5.Text;
       
            if (!Regex.IsMatch(tet1.Trim(), @"[a-zA-Z0-9 ]+$"))
            {
                MessageBox.Show("Xin nhap Ho Ten dung vao!");
            }
            else if (tet2 == "")
            {
                MessageBox.Show("Xin nhap Dia Chi dung vao!");
            }
            else if (gioitinh == "")
            {
                MessageBox.Show("Xin nhap Gioi Tinh dung vao!");
            }
            else if (!Regex.IsMatch(tet3.Trim(), @"[0-9]+$"))
            {
                MessageBox.Show("Xin nhap Homephone dung vao!");
            }
            else if (!Regex.IsMatch(tet4.Trim(), @"[0-9]+$"))
            {
                MessageBox.Show("Xin nhap Di Dong dung vao!");
            }
            else if (tet5 == "")
            {
                MessageBox.Show("Xin nhap Chuc Danh dung vao!");
            }
            
            else
            {
                try
                {
                    conn = Universaler.Communicate();
                    comd = new SqlCommand("insert into Nhancong values('" + tet1 + "','" + tet2 + "','" + gioitinh + "','" + tet3 + "','" + tet4 + "','" + tet5 + "')", conn);
                    conn.Open();
                    comd.ExecuteNonQuery();
                    conn.Close();
                    try
                    {
                        conn.Open();
                        comd1 = new SqlCommand("select max(Maso) from NhanCong", conn);

                        nv_id = Convert.ToInt32(comd1.ExecuteScalar());
                        conn.Close();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }                   
                    comd1 = new SqlCommand("insert into LyLichNhanCong values(" + nv_id + ",'"+tet1+"','','','')", conn);
                    conn.Open();
                    comd1.ExecuteNonQuery();
                    conn.Close();
                 
                    MessageBox.Show("Ban da luu du lieu thanh cong!");                 
                    update();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ban da luu du lieu khong thanh cong!");
                    Console.WriteLine(ex);
                    //MessageBox.Show(ex.ToString());
                }
                
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tet1 = textBox1.Text;
            
            string tet2 = textBox2.Text;
            string tet3 = textBox3.Text;
            string tet4 = textBox4.Text;
            string tet5 = textBox5.Text;
            string hih= hihe_text.Text;
            if (tet2 == "")
            {
                MessageBox.Show("Xin nhap Dia Chi dung vao!");
            }            
            else if (!Regex.IsMatch(tet3.Trim(), @"[0-9]+$"))
            {
                MessageBox.Show("Xin nhap Homephone dung vao!");
            }
            else if (!Regex.IsMatch(tet4.Trim(), @"[0-9]+$"))
            {
                MessageBox.Show("Xin nhap Di Dong dung vao!");
            }
            else if (tet5 == "")
            {
                MessageBox.Show("Xin nhap Chuc Danh dung vao!");
            }

            else
            {
                try
                {
                    conn = Universaler.Communicate();
                    comd = new SqlCommand("update NhanCong set DiaChi='" + tet2 + "',HomePhone='" + tet3 + "',DiDong='" + tet4 + "',ChucDanh='" + tet5 + "' where rtrim(Maso)=" + hih.Trim(), conn);
                    conn.Open();
                    comd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Ban Cap Nhat du lieu thanh cong!");
                    update();
                    clear();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ban Cap Nhat du lieu khong thanh cong!");
                    //MessageBox.Show(ex.ToString());
                    Console.WriteLine(ex);
                }
            }
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            string tet6 = textBox6.Text;
            string tet7 = textBox7.Text;
            string tet8 = textBox8.Text;
            string tet9 = textBox9.Text;
            string tet10 = richTextBox1.Text;

            if (!Regex.IsMatch(tet8.Trim(), @"([0-9][0-9]/[0-9][0-9]/(([0-9][0-9])|([0-9][0-9][0-9][0-9])))+$"))
            {
                MessageBox.Show("Xin nhap Ngay Vo Lam dung vao! 'dd/mm/yyyy'");
            }            
            else
            {
                try
                {
                    conn = Universaler.Communicate();
                    comd1 = new SqlCommand("update LyLichNhanCong set NgayVoLam='" + tet8 + "',NgayNghi='" + tet9 + "',GhiChu='" + tet10 + "' where rtrim(Maso)=" + tet7.Trim(), conn);
                    conn.Open();
                    comd1.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Ban da Cap Nhat lieu thanh cong!");
                   
                    update();
                    clearlylich();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ban da Cap Nhat lieu khong thanh cong!");
                    //MessageBox.Show(ex.ToString());
                    Console.WriteLine(ex);
                }
            }

            }
        
        private void button5_Click(object sender, EventArgs e)
        {
            clearlylich();
        }

        

       

        private void dataGridView2_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            textBox6.Text = Convert.ToString(dataGridView2.Rows[e.Cell.RowIndex].Cells[1].Value);
            textBox7.Text = Convert.ToString(dataGridView2.Rows[e.Cell.RowIndex].Cells[0].Value);
            textBox8.Text = Convert.ToString(dataGridView2.Rows[e.Cell.RowIndex].Cells[2].Value);
            textBox9.Text = Convert.ToString(dataGridView2.Rows[e.Cell.RowIndex].Cells[3].Value);
            richTextBox1.Text = Convert.ToString(dataGridView2.Rows[e.Cell.RowIndex].Cells[4].Value);
        }

      

        private void button7_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Ban Co That Su Muon Xoa Khong?", "Xoa Nhan Cong...", MessageBoxButtons.OKCancel).ToString() == "OK")
            {
                try
                {
                    conn = Universaler.Communicate();
                    comd1 = new SqlCommand(" delete NhanCong where rtrim(Maso)=" + hihe_text.Text.Trim(), conn);
                    conn.Open();
                    comd1.ExecuteNonQuery();
                    conn.Close();
                    comd = new SqlCommand(" delete LyLichNhanCong where rtrim(Maso)=" + hihe_text.Text.Trim(), conn);
                    conn.Open();
                    comd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Ban da Soa du lieu thanh cong!");
                   
                    update();
                    clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ban da Soa du lieu khong thanh cong!");
                    ex.Message.ToString();
                }
                
            }
        }

        private void dataGridView1_CellStateChanged_1(object sender, DataGridViewCellStateChangedEventArgs e)
        {

            hihe_text.Text = Convert.ToString(dataGridView1.Rows[e.Cell.RowIndex].Cells[0].Value);
            textBox1.Text = Convert.ToString(dataGridView1.Rows[e.Cell.RowIndex].Cells[1].Value);
            textBox2.Text = Convert.ToString(dataGridView1.Rows[e.Cell.RowIndex].Cells[2].Value);
            comboBox1.Text = Convert.ToString(dataGridView1.Rows[e.Cell.RowIndex].Cells[3].Value);
            textBox3.Text = Convert.ToString(dataGridView1.Rows[e.Cell.RowIndex].Cells[4].Value);
            textBox4.Text = Convert.ToString(dataGridView1.Rows[e.Cell.RowIndex].Cells[5].Value);
            textBox5.Text = Convert.ToString(dataGridView1.Rows[e.Cell.RowIndex].Cells[6].Value);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            clear();
        }
        

       
    }
}