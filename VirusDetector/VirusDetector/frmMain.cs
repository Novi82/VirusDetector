using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusDetector
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void navAbout_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MessageBox.Show("novi");
        }

        private void navExit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void navClaResult_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpClassReult;
        }

        private void navClaSetting_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpClasSetting;
        }

        private void navCluSetting_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpClusSetting;
        }

        private void navClusResult_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpClusReult;
        }

        private void navDecSetting_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpDeSetting;
        }

        private void navDecResult_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpDeResult;
        }

        private void navScan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            xtcContent.SelectedTabPage = xtpScan;
        }

    }
}
