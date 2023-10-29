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
    public partial class FormImageAdd : Form
    {
        public FormImageAdd()
        {
            InitializeComponent();
            //this.KeyDown += new KeyEventHandler(FormImageAdd_KeyDown);
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(FormImageAdd_PreviewKeyDown);
            TextBoxURL.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public string GetValue()
        {
            return TextBoxURL.Text;
        }

        private void FormImageAdd_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void FormImageAdd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true; // Помечаем клавишу как ввод клавиши, чтобы предотвратить звуковой сигнал Windows
                DialogResult = DialogResult.OK;
            }
        }
    }
}
