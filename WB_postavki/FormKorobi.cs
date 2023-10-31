using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WB_postavki
{
    public partial class FormKorobi : Form
    {
        public FormKorobi()
        {
            InitializeComponent();
        }

        private void FormKorobi_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*var url = "https://www.wildberries.ru/catalog/78921851/detail.aspx";

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("Failed to retrieve the page.");
            }*/
        }
    }
}
