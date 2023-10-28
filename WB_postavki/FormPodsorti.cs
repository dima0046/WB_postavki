using System;
using System.Windows.Forms;
using OfficeOpenXml;
using System.ComponentModel;
using System.Data.OleDb;

namespace WB_postavki
{
    public partial class FormPodsorti : Form
    {
        public System.Data.DataTable grT = new System.Data.DataTable();

        public FormPodsorti()
        {
            InitializeComponent();

            // Или, если вы хотите использовать LicenseContext для EPPlus:
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        }

        private void FormPodsorti_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FormPodsorti_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            loadFIleIntoDataSet();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveExcel();
        }

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
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Создаем объект OpenFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = saveFileDialog.FileName;
                FileInfo file = new FileInfo(filepath);

                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add("Новый лист");
                    int excelRow = 1;
                    int columnCount = 1;

                    // Добавляем наименования столбцов
                    for (int i = 0; i < grT.Columns.Count; i++)
                    {
                        if (grT.Columns[i].ColumnName != "Текущий остаток, шт.") // Проверяем наименование столбца
                        {
                            var cell = ws.Cells[excelRow, columnCount];
                            columnCount++;
                            cell.Value = grT.Columns[i].ColumnName;
                            var cellStyle = cell.Style;
                            cellStyle.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            cellStyle.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
                            cellStyle.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            cellStyle.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            cellStyle.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            cellStyle.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        }
                    }

                    excelRow = 1;

                    // Записываем данные из DataTable в ячейки Excel
                    for (int i = 0; i < grT.Rows.Count; i++)
                    {
                        var newValue = grT.Rows[i]["Новое количество"];
                        if (newValue != DBNull.Value && !string.IsNullOrEmpty(newValue.ToString()) && Convert.ToInt32(newValue) != 0)
                        {
                            excelRow++; // Инкрементируем excelRow только если строка добавляется
                            columnCount = 1;
                            for (int j = 0; j < grT.Columns.Count; j++)
                            {
                                if (grT.Columns[j].ColumnName != "Текущий остаток, шт." && grT.Columns[j].ColumnName != "Новое количество") // Проверяем наименование столбца
                                {
                                    var cell = ws.Cells[excelRow, columnCount];
                                    cell.Value = grT.Rows[i][j];
                                    var cellStyle = cell.Style;
                                    cellStyle.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    cellStyle.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    cellStyle.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    cellStyle.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                                    columnCount++;
                                }
                            }
                            // Устанавливаем стиль границ для последней колонки
                            var lastCell = ws.Cells[excelRow, columnCount];
                            lastCell.Value = grT.Rows[i][grT.Columns.Count - 1];
                            var lastCellStyle = lastCell.Style;
                            lastCellStyle.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            lastCellStyle.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            lastCellStyle.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            lastCellStyle.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                            lastCellStyle.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                            lastCellStyle.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGreen);
                        }
                    }
                    package.Save();
                }
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
}
