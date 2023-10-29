using System;
using System.IO;
using OfficeOpenXml;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Drawing;
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace WB_postavki
{
    public partial class FormMain : Form
    {
        FormPodsorti podsorti;
        FormKorobi korobi;
        private System.Drawing.Point _mouseOffset;
        private bool _isMouseDown = false;
        bool sidebarExpand = true;
        public System.Data.DataTable grT = new System.Data.DataTable();

        public FormMain()
        {
            InitializeComponent();
            mdiProp();
            buttonPodsorti.PerformClick();
        }

        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = Color.FromArgb(232, 234, 237);
        }

        //Открыть документ Excel
        private void btnopen_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonSavePodsorti_Click(object sender, EventArgs e)
        {
            
        }

       
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void SidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 5;
                if (sidebar.Width <= 40)
                {
                    sidebarExpand = false;
                    SidebarTransition.Stop();
                }

                panelPodsorti.Width = sidebar.Width;
                panelSkladi.Width = sidebar.Width;
                panelKoroba.Width = sidebar.Width;

            }
            else
            {
                sidebar.Width += 5;
                if (sidebar.Width >= 185)
                {
                    sidebarExpand = true;
                    SidebarTransition.Stop();
                }

                panelPodsorti.Width = sidebar.Width;
                panelSkladi.Width = sidebar.Width;
                panelKoroba.Width = sidebar.Width;
            }
        }

        private void btmHam_Click(object sender, EventArgs e)
        {
            SidebarTransition.Start();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void buttonPodsorti_Click(object sender, EventArgs e)
        {
            if (podsorti == null)
            {
                podsorti = new FormPodsorti();
                podsorti.FormClosed += FormPodsorti_FormClosed;
                podsorti.MdiParent = this;
                podsorti.Dock = DockStyle.Fill;
                podsorti.Show();
            }
            else
            {
                podsorti.Activate();
            }
        }

        private void FormPodsorti_FormClosed(object sender, FormClosedEventArgs e)
        {
            podsorti = null;
        }

        private void FormKorobi_FormClosed(object sender, FormClosedEventArgs e)
        {
            korobi = null;
        }

        private void poisonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panelMenu_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseOffset = new System.Drawing.Point(-e.X, -e.Y);
            _isMouseDown = true;
        }

        private void panelMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown)
            {
                System.Drawing.Point mousePos = Control.MousePosition;
                mousePos.Offset(_mouseOffset.X, _mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void panelMenu_MouseUp(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
        }

        private void buttonKoroba_Click(object sender, EventArgs e)
        {
            if (korobi == null)
            {
                korobi = new FormKorobi();
                korobi.FormClosed += FormKorobi_FormClosed;
                korobi.MdiParent = this;
                korobi.Dock = DockStyle.Fill;
                korobi.Show();
            }
            else
            {
                korobi.Activate();
            }
        }
    }
    



}
