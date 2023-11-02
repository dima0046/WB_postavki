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
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.Net.Sockets;
using System.Net.NetworkInformation;

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
            var geckoDriverProcesses = Process.GetProcessesByName("geckodriver");
            foreach (var process in geckoDriverProcesses)
            {
                process.Kill();
            }

            var options = new FirefoxOptions();
            int port = FreePortFinder.GetFreePort();
            options.AddArgument($"--marionette-port={port}");

            var driverService = FirefoxDriverService.CreateDefaultService();
            driverService.Port = port; // Указываем порт
            driverService.Host = "127.0.0.1"; // Локальный хост

            IWebDriver driver = new FirefoxDriver(driverService, options, TimeSpan.FromSeconds(30)); // Указываем явное ожидание в 30 секунд

            options.AddArgument("--headless"); // Запуск браузера в фоновом режиме (необязательно)

            using (driver)
            {
                driver.Navigate().GoToUrl("https://www.wildberries.ru/catalog/78921851/detail.aspx?targetUrl=EX");

                IWebElement imageElement = driver.FindElement(By.XPath("/html"));
                string imageUrl = imageElement.GetAttribute("src");

                Console.WriteLine("Путь до изображения: " + imageUrl);
            }
        }

        public class FreePortFinder
        {
            public static int GetFreePort()
            {
                var listener = new TcpListener(IPAddress.Loopback, 0);
                listener.Start();
                int port = ((IPEndPoint)listener.LocalEndpoint).Port;
                listener.Stop();
                return port;
            }
        }
    }
}
