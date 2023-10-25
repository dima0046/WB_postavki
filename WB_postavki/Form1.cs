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

        //������� �������� Excel
        private void btnopen_Click(object sender, EventArgs e)
        {
            loadFIleIntoDataSet();
        }

        private void buttonSavePodsorti_Click(object sender, EventArgs e)
        {
            SaveExcel();
        }

        #region �������� Excel �����. ������� 1. ��� ��
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
                // �������� ���� � ���������� �����
                sourceFilePath = openFileDialog.FileName;
                destinationFilePath = openFileDialog.FileName;

                // ������� ������� FileInfo ��� ��������� � �������� ������
                FileInfo sourceFileInfo = new FileInfo(sourceFilePath);
                FileInfo destinationFileInfo = new FileInfo(destinationFilePath);


                string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + sourceFileInfo + ";Extended Properties='Excel 12.0 XML;HDR=YES'";
                // ������������� �������� �������������� ��� ��������������
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                // ���������� using ��� ��������������� ����������� ������� ExcelPackage
                using (ExcelPackage sourcePackage = new ExcelPackage(sourceFileInfo))
                {
                    // �������� ������ ���� �� Excel-�����
                    ExcelWorksheet worksheet = sourcePackage.Workbook.Worksheets[0];

                    //������� ������ ������ (��������)
                    worksheet.DeleteRow(1);
                    worksheet.DeleteRow(1);

                    // ��������� ���� ������ �� ����� Excel
                    var totalData = worksheet.Cells["A1:Q" + worksheet.Dimension.End.Row].Value;
                    List<object[]> dataRows = new List<object[]>();

                    // �������� �� ���� ������� � ���������� ������ � ������
                    for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                    {
                        object[] rowData = new object[5]; // ����������, ��� ����� 5 - ���������� ������ ��������
                        rowData[0] = worksheet.Cells[row, 1].Value; // �����
                        rowData[1] = worksheet.Cells[row, 6].Value; // ������� ��������
                        rowData[2] = worksheet.Cells[row, 7].Value; // ������� WB
                        rowData[3] = worksheet.Cells[row, 8].Value; // ������
                        rowData[4] = worksheet.Cells[row, 17].Value; // ������� �������
                        dataRows.Add(rowData);
                    }

                    // ����������� ������ �� ������� "������� WB"
                    var result = dataRows.GroupBy(row => row[2]?.ToString().Trim().ToUpper())
                                         .Select(g => new
                                         {
                                             ArticulWB = g.Key,
                                             Rows = g.ToList()
                                         });

                    // �������� DataTable ��� ����������� � DataGridView
                    System.Data.DataTable dt = new System.Data.DataTable();

                    // ���������� �������� � DataTable
                    dt.Columns.Add("�����", typeof(string));
                    dt.Columns.Add("������� ��������", typeof(string));
                    dt.Columns.Add("������� WB", typeof(string));
                    dt.Columns.Add("������", typeof(string));
                    dt.Columns.Add("������� �������", typeof(int));


                    // �������� �� ����������� ����������� � ������������ ��������
                    foreach (var group in result)
                    {
                        int sum = 0;
                        foreach (var row in group.Rows)
                        {
                            sum += int.TryParse(row[4]?.ToString(), out int quantity) ? quantity : 0;
                        }
                        // ���������� ������ � ������������ � DataTable
                        dt.Rows.Add(group.Rows[0][0], group.Rows[0][1], group.ArticulWB, group.Rows[0][3], sum);
                    }

                    // �������� BindingSource
                    BindingSource bindingSourcePodsorti = new BindingSource();

                    // �������� DataTable � BindingSource
                    bindingSourcePodsorti.DataSource = dt;

                    // �������� BindingSource � DataGridView
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
                // �������� ���� � ���������� �����
                sourceFilePath = openFileDialog.FileName;
                destinationFilePath = openFileDialog.FileName;

                // ������� ������� FileInfo ��� ��������� � �������� ������
                FileInfo sourceFileInfo = new FileInfo(sourceFilePath);
                FileInfo destinationFileInfo = new FileInfo(destinationFilePath);

                //��������� Excel
                string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={sourceFilePath};Extended Properties='Excel 12.0;HDR=Yes;IMEX=1'";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string sqlQuery = "SELECT [�����], [������� ��������], [������� WB], [������], [������� �������, ��#] FROM [Sheet1$A2:Q]";

                    using (OleDbCommand command = new OleDbCommand(sqlQuery, connection))
                    {
                        // ������� ������� ������ OleDbDataAdapter ��� ���������� DataTable � ��������� ������ DataGridView
                        using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command))
                        {
                            System.Data.DataTable dt = new System.Data.DataTable();
                            dataAdapter.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }

                        // �������������� ������ � ������� groupData, � ����� ����������� �� �������� ArtWB � ���������� ���������� �������� TotalCount
                        var grData = dataGridView1.Rows.Cast<DataGridViewRow>()
                            .Where(row => !row.IsNewRow)
                            .Select(row => new groupData
                            {
                                Brand = row.Cells["�����"].Value.ToString(),
                                ArtSeller = row.Cells["������� ��������"].Value.ToString(),
                                ArtWB = long.Parse(row.Cells["������� WB"].Value.ToString()),
                                Barcode = long.Parse(row.Cells["������"].Value.ToString()),
                                TotalCount = int.Parse(row.Cells["������� �������, ��#"].Value.ToString())

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

                        // �������� ����� DataTable � ���������� �� ������� �� ��������������� ������
                        //System.Data.DataTable grT = new System.Data.DataTable();
                        grT.Columns.Add("�����");
                        grT.Columns.Add("������� ��������");
                        grT.Columns.Add("������� WB");
                        grT.Columns.Add("������");
                        grT.Columns.Add("������� �������, ��.");
                        grT.Columns.Add("����� ����������");


                        // ���������� ����� ������� ������� �� ��������������� ������
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
            System.Data.DataTable dataTable = grT; // �������� ���� DataTable �����
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // ������� ������ OpenFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = saveFileDialog.FileName;
                FileInfo file = new FileInfo(filepath); // �������� �� ���� ���� � ��� �����



                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add("����� ����");

                    // ��������� ������������ ��������
                    // ��������� ������������ ��������
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        ws.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                    }

                    // ���������� ������ �� DataTable � ������ Excel
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
