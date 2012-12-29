using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ARCMSDesktop
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout Success");
            Login a = new Login();
            //a.MdiParent = this;
            a.Show();
            this.Hide();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newCampaignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCampaign a = new NewCampaign();
            //a.MdiParent = this;
            a.Show();
        }

        public void login(string Admin1)
        {
            logoutToolStripMenuItem.Visible = true;
            exitToolStripMenuItem.Visible = true;
            if (Admin1.Equals("1"))
            {
                campaignToolStripMenuItem.Visible = true;
                newCampaignToolStripMenuItem.Visible = true;
                pointOfInterestToolStripMenuItem.Visible = true;
                addNewPOIToolStripMenuItem.Visible = true;
                manageUserToolStripMenuItem.Visible = true;
                manageSessionsToolStripMenuItem.Visible = true;
                addUserToolStripMenuItem.Visible = true;
                
            }
            else if (Admin1.Equals("0"))
            {
                campaignToolStripMenuItem.Visible = true;
                newCampaignToolStripMenuItem.Visible = true;
                pointOfInterestToolStripMenuItem.Visible = true;
                addNewPOIToolStripMenuItem.Visible = true;
                manageUserToolStripMenuItem.Visible = false;
                manageSessionsToolStripMenuItem.Visible = false;
                addUserToolStripMenuItem.Visible = false;
                
            }
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users a = new Users();
            //a.MdiParent = this;
            a.Show();
        }

        private void manageSessionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageUserSessions a = new ManageUserSessions();
            //a.MdiParent = this;
            a.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void addNewPOIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewPOI a = new AddNewPOI();
            a.Show();
        }

        private void MainMenu_Leave(object sender, EventArgs e)
        {
            
        }



       
    }
}
