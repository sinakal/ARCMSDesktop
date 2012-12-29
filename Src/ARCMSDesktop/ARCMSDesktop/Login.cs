using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing.Printing;

namespace ARCMSDesktop
{
    public partial class Login : Form
    {
        public static string Username = "";
        public static string Password = "";
        Connect con = new Connect();
        DataSet ds;
        SqlDataAdapter Da;
        public static string Admin;

        public Login()
        {
            InitializeComponent();
        }

        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        void updateflag()
        {
            ds = new DataSet();
            Da = new SqlDataAdapter("Update Msuser set Flag_Login = 1" , con.conn);
            Da.Fill(ds, "Administrator");
        }



        private void button1_Click(object sender, EventArgs e)
        {
             if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 )
            {
                MessageBox.Show("isi semua field ");
            }
            else
            {
                try
                {
                    
                    ds = new DataSet();
                    Da = new SqlDataAdapter("Select * from MsUser where Username='" + textBox1.Text + "' and Password='"+textBox2.Text+"' ", con.conn);
                    Da.Fill(ds, "Administrator");

                    if (ds.Tables["Administrator"].Rows.Count == 0)
                    {
                        MessageBox.Show("Username dan Password Salah!!");
                    }
                    else
                    {
                        Username = ds.Tables["Administrator"].Rows[0][0].ToString();
                        Password = ds.Tables["Administrator"].Rows[0][1].ToString();
                        Admin = ds.Tables["Administrator"].Rows[0][4].ToString();

                        if (Admin.Equals("1"))
                        {
                            MessageBox.Show("Selamat Datang Administrator");
                        }
                        else
                        {
                            MessageBox.Show("Selamat Datang User");
                        }

                        MainMenu mm = new MainMenu();
                        
                        mm.login(Admin);
                        mm.Show();
                        this.Hide();
                    }
                }

                catch (Exception)
                {

                    MessageBox.Show("Username dan Password tidak ditemukan");
                    clear();
                }     
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                con.conn.Open();


            }
            finally
            {
                if (con.conn != null)
                {
                    con.conn.Close();
                }

            }
        }
   
    }
}

