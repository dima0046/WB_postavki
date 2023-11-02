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
            TextBoxURL.Focus();
            this.KeyDown += new KeyEventHandler(FormImageAdd_KeyDown);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OK();
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
            if (e.KeyCode == Keys.Enter)
            {
                OK();
            }
        }

        private void FormImageAdd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void TextBoxURL_TextChanged(object sender, EventArgs e)
        {
            this.KeyDown += new KeyEventHandler(FormImageAdd_KeyDown);
        }


        private void OK()
        {
            string inputText = TextBoxURL.Text;
            this.DialogResult = DialogResult.OK;
            if (!Uri.TryCreate(inputText, UriKind.Absolute, out Uri uriResult) ||
                (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                MessageBox.Show("Ошибка ввода. Пожалуйста, введите правильную ссылку.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                this.Close();
            }
        }
    }
}
