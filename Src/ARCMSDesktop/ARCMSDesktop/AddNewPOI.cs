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
    public partial class AddNewPOI : Form
    {
        Connect con = new Connect();
        DataSet ds;
        SqlDataAdapter Da;
        int ind, temp;
       

        public AddNewPOI()
        {
            InitializeComponent();
        }

        void nobaru()
        {
            ds = new DataSet();
            Da = new SqlDataAdapter("select top 1 IDPOI  from MsPointOfInterest  order by IDPOI desc ", con.conn);
            Da.Fill(ds, "POI");
            var v = "";
            if (ds.Tables["POI"].Rows.Count > 0)
            {
                v = ds.Tables["POI"].Rows[0][0].ToString();
            }
            int no = int.Parse(v.Substring(2)) + 1;
            string noBaru = string.Format("P{0:0000}", no);
            textBox4.Text = noBaru;
        }

        void updateTable()
        {
            ds = new DataSet();
            Da = new SqlDataAdapter("select * from MsPointOfInterest   ", con.conn);
            Da.Fill(ds, "POI");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "POI";
            dataGridView1.Columns[1].Width = 175;

            button1.Visible = false;
            enableFalseText();
        }

        void enableFalseText()
        {

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox1.Enabled = false;
            

        }
        void enableTrueText()
        {

            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = false;
            textBox1.Enabled = true;
            button1.Visible = true;

        }
        void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            
        }

        void semula()
        {
            if (ind == dataGridView1.RowCount)
            {
                ind = 0;
            }
            textBox4.Text = dataGridView1.Rows[ind].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[ind].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[ind].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[ind].Cells[3].Value.ToString();
            

            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
        }

        void getRec()
        {
            textBox4.Text = dataGridView1.Rows[ind].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[ind].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[ind].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[ind].Cells[3].Value.ToString();            
        }

        private void AddNewPOI_Load(object sender, EventArgs e)
        {
            try
            {
                con.conn.Open();
                updateTable();
                semula();               
            }
            finally
            {
                if (con.conn != null)
                {
                    con.conn.Close();
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ind = dataGridView1.CurrentCell.RowIndex;
            if (ind == -1)
            {
                ind = 0;
            }
            semula();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult oks = MessageBox.Show("Apakah Location IDPOI  \"" + textBox4.Text + "\" \n ingin di delete?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oks == DialogResult.Yes)
            {
                ds = new DataSet();
                Da = new SqlDataAdapter("Delete from MsPointOfInterest where IDPOI='" + textBox4.Text + "'", con.conn);
                Da.Fill(ds, "POI");
                updateTable();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 )
            {
                MessageBox.Show("Harus Isi Semua TextBox");
            }
            else if (temp == 1)
            {
                ds = new DataSet();
                Da = new SqlDataAdapter("insert into MsPointOfInterest values ('" + textBox4.Text + "','" + textBox3.Text + "','" + textBox1.Text + "'," + textBox2.Text + ")", con.conn);
                Da.Fill(ds, "POI");

                updateTable();
                semula();
            }

            else if (temp == 2)
            {
                ds = new DataSet();
                Da = new SqlDataAdapter("Update MsPointOfInterest set IDPOI='" + textBox4.Text + "',NamaTempat='" + textBox3.Text + "',PointX='" + textBox1.Text + "',PointY='"
                         + textBox2.Text + "' where IDPOI = '"+textBox4.Text+"'", con.conn);
                Da.Fill(ds, "POI");

                updateTable();
                semula();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            temp = 1;
            clear();
            nobaru();
            button3.Visible = false;
            button2.Visible = false;
            button5.Visible = false;
            enableTrueText();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            temp = 2;
            button3.Visible = false;
            button2.Visible = false;
            button5.Visible = false;
            enableTrueText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            Da = new SqlDataAdapter("Select * From MSPointOfInterest where NamaTempat like '%" + textBox5.Text + "%' ", con.conn);
            Da.Fill(ds, "POI");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "POI";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ind = dataGridView1.CurrentCell.RowIndex;
            getRec();
        }
           
    }
}
