using System;
using System.IO;
using OfficeOpenXml;
using Microsoft.Office.Interop.Excel;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Diagrams;

namespace WB_postavki
{
    public partial class FormMain : Form
    {
        FormDashboard dashboard;
        FormPodsorti podsorti;
        FormKorobi korobi;


        public System.Data.DataTable grT = new System.Data.DataTable();
        public FormMain()
        {
            InitializeComponent();
        }

        //Открыть документ Excel
        private void btnopen_Click(object sender, EventArgs e)
        {
            loadFIleIntoDataSet();
        }

        private void buttonSavePodsorti_Click(object sender, EventArgs e)
        {
            SaveExcel();
        }

        #region Загрузка Excel файла. Вариант 1. Без БД
        private void loadfile()
        {
            string sourceFilePath;
            string destinationFilePath;



            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Получаем путь к выбранному файлу
                sourceFilePath = openFileDialog.FileName;
                destinationFilePath = openFileDialog.FileName;

                // Создаем объекты FileInfo для исходного и целевого файлов
                FileInfo sourceFileInfo = new FileInfo(sourceFilePath);
                FileInfo destinationFileInfo = new FileInfo(destinationFilePath);


                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sourceFileInfo + ";Extended Properties='Excel 12.0 XML;HDR=YES'";
                // Устанавливаем контекст лицензирования как некоммерческий
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // Используем using для автоматического уничтожения объекта ExcelPackage
                using (ExcelPackage sourcePackage = new ExcelPackage(sourceFileInfo))
                {
                    // Получаем первый лист из Excel-книги
                    ExcelWorksheet worksheet = sourcePackage.Workbook.Worksheets[0];

                    //удаляем первую строку (название)
                    worksheet.DeleteRow(1);
                    worksheet.DeleteRow(1);

                    // Получение всех данных из листа Excel
                    var totalData = worksheet.Cells["A1:Q" + worksheet.Dimension.End.Row].Value;
                    List<object[]> dataRows = new List<object[]>();

                    // Итерация по всем строкам и добавление данных в список
                    for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                    {
                        object[] rowData = new object[5]; // Учитывайте, что здесь 5 - количество нужных столбцов
                        rowData[0] = worksheet.Cells[row, 1].Value; // Бренд
                        rowData[1] = worksheet.Cells[row, 6].Value; // Артикул продавца
                        rowData[2] = worksheet.Cells[row, 7].Value; // Артикул WB
                        rowData[3] = worksheet.Cells[row, 8].Value; // Баркод
                        rowData[4] = worksheet.Cells[row, 17].Value; // Текущий остаток
                        dataRows.Add(rowData);
                    }

                    // Группировка данных по столбцу "Артикул WB"
                    var result = dataRows.GroupBy(row => row[2]?.ToString().Trim().ToUpper())
                                         .Select(g => new
                                         {
                                             ArticulWB = g.Key,
                                             Rows = g.ToList()
                                         });

                    // Создание DataTable для отображения в DataGridView
                    System.Data.DataTable dt = new System.Data.DataTable();

                    // Добавление столбцов в DataTable
                    dt.Columns.Add("Бренд", typeof(string));
                    dt.Columns.Add("Артикул продавца", typeof(string));
                    dt.Columns.Add("Артикул WB", typeof(string));
                    dt.Columns.Add("Баркод", typeof(string));
                    dt.Columns.Add("Текущий остаток", typeof(int));


                    // Итерация по результатам группировки и суммирование остатков
                    foreach (var group in result)
                    {
                        int sum = 0;
                        foreach (var row in group.Rows)
                        {
                            sum += int.TryParse(row[4]?.ToString(), out int quantity) ? quantity : 0;
                        }
                        // Добавление строки с результатами в DataTable
                        dt.Rows.Add(group.Rows[0][0], group.Rows[0][1], group.ArticulWB, group.Rows[0][3], sum);
                    }

                    // Создание BindingSource
                    BindingSource bindingSourcePodsorti = new BindingSource();

                    // Привязка DataTable к BindingSource
                    bindingSourcePodsorti.DataSource = dt;

                    // Привязка BindingSource к DataGridView
                    dataGridView1.DataSource = bindingSourcePodsorti;

                }
            }
        }
        #endregion

        private void loadFIleIntoDataSet()
        {
            string sourceFilePath;
            string destinationFilePath;


            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Получаем путь к выбранному файлу
                sourceFilePath = openFileDialog.FileName;
                destinationFilePath = openFileDialog.FileName;

                // Создаем объекты FileInfo для исходного и целевого файлов
                FileInfo sourceFileInfo = new FileInfo(sourceFilePath);
                FileInfo destinationFileInfo = new FileInfo(destinationFilePath);

                //Загружаем Excel
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourceFilePath};Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT [Бренд], [Артикул продавца], [Артикул WB], [Баркод], [Текущий остаток, шт#] FROM [Sheet1$A2:Q]";

                    using (OleDbCommand command = new OleDbCommand(sqlQuery, connection))
                    {
                        // Создаем адаптер данных OleDbDataAdapter для заполнения DataTable и источника данных DataGridView
                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            dataAdapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }

                        // Преобразование данных в объекты groupData, а затем группировка по значению ArtWB и вычисление суммарного значения TotalCount
                        var grData = dataGridView1.Rows.Cast<DataGridViewRow>()
                            .Where(row => !row.IsNewRow)
                            .Select(row => new groupData
                            {
                                Brand = row.Cells["Бренд"].Value.ToString(),
                                ArtSeller = row.Cells["Артикул продавца"].Value.ToString(),
                                ArtWB = long.Parse(row.Cells["Артикул WB"].Value.ToString()),
                                Barcode = long.Parse(row.Cells["Баркод"].Value.ToString()),
                                TotalCount = int.Parse(row.Cells["Текущий остаток, шт#"].Value.ToString())

                            })
                            .GroupBy(data => data.ArtWB)
                            .Select(group => new groupData
                            {
                                Brand = group.First().Brand,
                                ArtSeller = group.First().ArtSeller,
                                ArtWB = group.Key,
                                Barcode = group.First().Barcode,
                                TotalCount = group.Sum(data => data.TotalCount)
                            })
                            .ToList();

                        // Создание новой DataTable и заполнение ее данными из сгруппированных данных
                        //System.Data.DataTable grT = new System.Data.DataTable();
                        grT.Columns.Add("Бренд");
                        grT.Columns.Add("Артикул продавца");
                        grT.Columns.Add("Артикул WB");
                        grT.Columns.Add("Баркод");
                        grT.Columns.Add("Текущий остаток, шт.");
                        grT.Columns.Add("Новое количество");


                        // Заполнение новой таблицы данными из сгруппированных данных
                        foreach (var group in grData)
                        {
                            grT.Rows.Add(group.Brand, group.ArtSeller, group.ArtWB, group.Barcode, group.TotalCount, "");

                        }
                        dataGridView1.DataSource = grT;
                    }
                }
            }

        }

        private void SaveExcel()
        {
            System.Data.DataTable dataTable = grT; // Получите свой DataTable здесь
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Создаем объект OpenFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = saveFileDialog.FileName;
                FileInfo file = new FileInfo(filepath); // Замените на свой путь и имя файла



                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add("Новый лист");

                    // Добавляем наименования столбцов
                    // Добавляем наименования столбцов
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        ws.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                    }

                    // Записываем данные из DataTable в ячейки Excel
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Columns.Count; j++)
                        {
                            ws.Cells[i + 1, j + 1].Value = dataTable.Rows[i][j];
                        }
                    }

                    package.Save();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        bool sidebarExpand = true;

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

        private void poisonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    public class groupData
    {
        public string Brand { get; set; }
        public string ArtSeller { get; set; }
        public long ArtWB { get; set; }
        public long Barcode { get; set; }
        public int TotalCount { get; set; }
        public int NewCount { get; set; }
    }



}
