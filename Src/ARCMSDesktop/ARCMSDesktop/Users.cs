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

namespace ARCMSDesktop
{
    public partial class Users : Form
    {
        Connect con = new Connect();
        DataSet ds;
        SqlDataAdapter Da;
        int ind, temp;

        public Users()
        {
            InitializeComponent();
        }

        void updateTable()
        {
            ds = new DataSet();
            Da = new SqlDataAdapter("select * from MsUser where admin = '0'  ", con.conn);
            Da.Fill(ds, "Users");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Users";
            dataGridView1.Columns[1].Width = 175;

        }

        void enableFalseText()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;

        }
        void enableTrueText()
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox1.Enabled = true;
        }
        void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        void semula()
        {
            if (ind == dataGridView1.RowCount)
            {
                ind = 0;
            }
            textBox1.Text = dataGridView1.Rows[ind].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[ind].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[ind].Cells[2].Value.ToString();

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
        }

        void getRec()
        {
            textBox1.Text = dataGridView1.Rows[ind].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[ind].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[ind].Cells[2].Value.ToString();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            button4.Visible = false;
            updateTable();
            semula();
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ind = dataGridView1.CurrentCell.RowIndex;
            if (ind == -1)
            {
                ind = 0;
            }
            getRec();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp = 1;
     
            button3.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            button4.Visible = true;
            clear();
            enableTrueText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            temp = 2;
            button3.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            button4.Visible = true;
            enableTrueText();
            textBox1.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult oks = MessageBox.Show("Apakah Username \"" + textBox1.Text + "\" \n ingin di delete?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oks == DialogResult.Yes)
            {
                ds = new DataSet();
                Da = new SqlDataAdapter("Delete from MsUser where Username='" + textBox1.Text + "'", con.conn);
                //Da.Fill(ds, "Users");
                updateTable();
                semula();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 )
            {
                MessageBox.Show("Harus Isi Semua TextBox");
            }
            else if (temp == 1)
            {
                MessageBox.Show("masuk insert");
                ds = new DataSet();

                Da = new SqlDataAdapter("insert into MsUser values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','0','0')", con.conn);
                Da.Fill(ds, "Users");
                //con.conn.Open();
                //SqlCommand QueryInsert = new SqlCommand(
                //        "INSERT into MsUser values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','0','0')", con.conn);
                //QueryInsert.ExecuteNonQuery();
                //con.conn.Close();

                updateTable();
                semula();
            }

            else if (temp == 2)
            {
                ds = new DataSet();
                Da = new SqlDataAdapter("Update MsUser set Password='" + textBox2.Text + "',Name='" + textBox3.Text + "',Flag_Login= 0, Admin = 0 where username ='" + textBox1.Text +"'", con.conn);
                Da.Fill(ds, "Users");

                updateTable();
                semula();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ind = dataGridView1.CurrentCell.RowIndex;
            getRec();
        }

        private void dataGridView1_Move(object sender, EventArgs e)
        {
            ind = dataGridView1.CurrentCell.RowIndex;
            getRec();
        }


    }
}
