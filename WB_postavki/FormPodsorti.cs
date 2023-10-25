using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WB_postavki
{
    public partial class FormPodsorti : Form
    {
        public FormPodsorti()
        {
            InitializeComponent();
        }

        private void FormPodsorti_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FormPodsorti_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }
    }
}
