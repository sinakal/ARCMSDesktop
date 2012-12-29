using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ARCMSDesktop
{
    public partial class ManageUserSessions : Form
    {
        Connect con = new Connect();
        DataSet ds;
        SqlDataAdapter Da;
        int ind;

        public ManageUserSessions()
        {
            InitializeComponent();
        }

        void updateTable()
        {
            ds = new DataSet();
            Da = new SqlDataAdapter("select * from MsUser where Flag_Login = 1", con.conn);
            Da.Fill(ds, "User");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "User";
            dataGridView1.Columns[1].Width = 175;
        }

        void semula()
        {
            if (ind == dataGridView1.RowCount)
            {
                ind = 0;
            }
            textBox1.Text = dataGridView1.Rows[ind].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[ind].Cells[1].Value.ToString();
            
        }

        void killsession()
        {
            ds = new DataSet();
            Da = new SqlDataAdapter("Update MsUser set Flag_Login=0 where Username= '" + textBox1.Text + "'", con.conn);
            Da.Fill(ds, "User");
           
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            killsession();
        }

        private void ManageUserSessions_Load(object sender, EventArgs e)
        {
            try
            {
                con.conn.Open();
                updateTable();

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
    }
}
