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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        SqlCommand comd;
        SqlDataReader read;


        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Connection condata = new Connection();
            condata.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals(""))
			{
				MessageBox.Show(" Xin Nhap ID!");
				textBox1.Focus();
			}
            else if (textBox2.Text.Equals(""))
            {
                MessageBox.Show("Xin Nhap Password!");
                textBox2.Focus();
            }
            else
            {
                try
                {
                    conn = Universaler.Communicate();                   
                    comd = new SqlCommand("Select PassWord,ID from CongChinh where rtrim(PassWord)='" + textBox2.Text.Trim() + "' and rtrim(Id)='" + textBox1.Text.Trim() + "'", conn);
                    conn.Open();
                    read = comd.ExecuteReader();
                    if (read.HasRows)
                    {                      
                        MessageBox.Show("Xin Chao " + textBox1.Text+"!");
                        Universaler.password = textBox1.Text;
                        MainFrom mf = new MainFrom();
                        mf.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Ban dang nhap sai roi " + textBox1.Text + " oi!");
                        textBox1.ResetText();
                        textBox2.ResetText();
                        textBox1.Focus();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show("Khong the ket noi voi co so du lieu!");
                    //MessageBox.Show("Co the ban da nhap sai thong tin co so du lieu moi roi!");
                    //MessageBox.Show("De sai lai Co So Du Lieu cu Ban thoat khoi chuong trinh va dang nhap lai nghe!");
                    ex.Message.ToString();
                }
            }
        }
    }
}