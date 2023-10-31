using System;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Net;
using System.Text.RegularExpressions;
using System.Drawing;
using System.ComponentModel;
using System.Data.OleDb;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml.Drawing;
using System.IO.Packaging;
using HtmlAgilityPack;

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
                        //System.Data.DataTable grT = new System.Data.DataTable()
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

                        // Создание столбца изображений в DataGridView
                        DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
                        imgColumn.Name = "ImageColumn";
                        imgColumn.HeaderText = "Изображения";
                        // Вставляем столбец на первую позицию
                        dataGridView1.Columns.Insert(0, imgColumn);
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
                string existingFilePath = saveFileDialog.FileName;

                // Проверка существования файла
                if (File.Exists(existingFilePath))
                {
                    // Удаление файла
                    File.Delete(existingFilePath);
                }

                FileInfo file = new FileInfo(filepath);

                int sheetNumber = 1;
                string sheetName = "Новый лист";



                using (ExcelPackage package = new ExcelPackage(file))
                {
                    while (package.Workbook.Worksheets.Any(ws => ws.Name == sheetName))
                    {
                        sheetNumber++;
                        sheetName = "Новый лист " + sheetNumber;
                    }

                    // Теперь sheetName содержит уникальное имя для листа
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add(sheetName);

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
                        // Проверяем наличие нового количества и его корректность
                        var newValue = grT.Rows[i]["Новое количество"];
                        if (newValue != DBNull.Value && !string.IsNullOrEmpty(newValue.ToString()) &&
                            Convert.ToInt32(newValue) != 0)
                        {
                            // Инкрементируем excelRow только если строка добавляется
                            excelRow++;

                            // Сбрасываем счетчик столбцов
                            columnCount = 1;

                            // Итерация по столбцам
                            for (int j = 0; j < grT.Columns.Count; j++)
                            {
                                // Проверяем наименование столбца и исключаем столбцы с изображениями
                                if (grT.Columns[j].ColumnName != "Текущий остаток, шт." &&
                                    grT.Columns[j].ColumnName != "Новое количество")
                                {
                                    // Получаем ячейку с изображением
                                    DataGridViewImageCell cellpic =
                                        dataGridView1.Rows[i].Cells[0] as DataGridViewImageCell;
                                    // Получаем изображение из ячейки
                                    if (cellpic.Value != null && cellpic.Value is System.Drawing.Image)
                                    {
                                        System.Drawing.Image img = (System.Drawing.Image)cellpic.Value;

                                        // Добавляем изображение в Excel
                                        if (img != null)
                                        {
                                            // Создаем файл изображения для временного хранения
                                            string fileName = "image" + i.ToString() + ".png";

                                            try
                                            {
                                                // Сохраняем изображение как файл
                                                img.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                                            }
                                            catch (Exception ex)
                                            {
                                                // Обработка исключения сохранения изображения
                                                Console.WriteLine("Ошибка при сохранении изображения: " + ex.Message);
                                            }

                                            // Создаем объект FileInfo для работы с файлом
                                            FileInfo fileInfo = new FileInfo(fileName);

                                            // Проверяем, существует ли изображение с таким именем в коллекции и удаляем, если оно уже есть
                                            if (ws.Drawings["pic" + i.ToString()] != null)
                                            {
                                                ws.Drawings.Remove("pic" + i.ToString());
                                            }

                                            // Добавляем изображение в Excel
                                            ExcelPicture picture =
                                                ws.Drawings.AddPicture("pic" + i.ToString(), fileInfo);
                                            // Устанавливаем позицию изображения в Excel
                                            picture.SetPosition(excelRow, 0, 0, 0);
                                            // Устанавливаем размер изображения в Excel
                                            picture.SetSize(100, 100);

                                            // Освобождаем ресурсы изображения
                                            img.Dispose();

                                            // Удаляем временный файл после использования
                                            try
                                            {
                                                fileInfo.Delete();
                                            }
                                            catch (Exception ex)
                                            {
                                                // Обработка исключения при удалении файла
                                                Console.WriteLine("Ошибка при удалении файла: " + ex.Message);
                                            }
                                        }
                                    }
                                }


                                // Добавляем остальные данные в Excel
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

                    // Сохраняем изменения в пакете Excel
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

        private void buttonImageAdd_Click(object sender, EventArgs e)
        {
            // Проверка, есть ли выбранная ячейка
            if (dataGridView1.CurrentCell != null)
            {
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);
                AddImageFromURL(args);
            }
        }


        private void AddImageFromURL(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell is DataGridViewImageCell) // Проверяем, что ячейка является DataGridViewImageCell
                {
                    FormImageAdd formImageAdd = new FormImageAdd();
                    formImageAdd.Owner = this;
                    if (formImageAdd.ShowDialog() == DialogResult.OK)
                    {
                        string ImageURL = formImageAdd.GetValue();
                        // Загрузите изображение по URL и установите его как содержимое ячейки
                        try
                        {
                            WebClient wc = new WebClient();
                            byte[] bytes = wc.DownloadData(ImageURL);
                            Image img = Image.FromStream(new System.IO.MemoryStream(bytes));

                            // Установите значение ячейки как объект DataGridViewImageCell
                            ((DataGridViewImageCell)cell).Value = img;
                        }
                        catch (Exception ex)
                        {
                            // Обработка ошибок
                            MessageBox.Show($"Ошибка при загрузке изображения с URL: {ImageURL}. Подробности: {ex.Message}");
                            return;
                        }
                    }
                }
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверка, есть ли выбранная ячейка
            if (dataGridView1.CurrentCell != null && e.ColumnIndex == 0)
            {
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex);
                AddImageFromURL(args);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var url = "https://www.wildberries.ru/catalog/78921851/detail.aspx";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var divNode = doc.DocumentNode.SelectSingleNode("/html/body/div[1]/main/div[2]/div/div[3]/div/div[3]/div[1]/div/div[2]/div/div[1]/div/div");
            if (divNode != null)
            {
                var divContent = divNode.InnerHtml;
                MessageBox.Show(divContent, "Содержимое div", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Не удалось найти элемент div на странице.");
            }
        }
    }
}
