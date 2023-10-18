using System;
using System.IO;
using OfficeOpenXml;
using System.Linq;
using static OfficeOpenXml.ExcelErrorValue;
using System.Data;

namespace WB_postavki
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnopen_Click(object sender, EventArgs e)
        {
            loadfile();
        }


        //�������� Excel �����
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
                    DataTable dt = new DataTable();

                    // ���������� �������� � DataTable
                    dt.Columns.Add("�����", typeof(string));
                    dt.Columns.Add("������� ��������", typeof(string));
                    dt.Columns.Add("������� WB", typeof(string));
                    dt.Columns.Add("������", typeof(string));
                    dt.Columns.Add("������� �������", typeof(int));


                    DataSet1.Tables["Table1"].Rows.Add(row.ItemArray);

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



                    #region 3333
                    /*
                    // �������� ��� �������� �� ��������� ��������� �����
                    var totalData = worksheet.Cells["A1:Q" + worksheet.Dimension.End.Row].Value;
                    List<object[]> dataRows = new List<object[]>();

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

                    var distinctRows = dataRows.Distinct(new DataRowComparer()).ToList();

                    var result = distinctRows.GroupBy(row => row[2]?.ToString().Trim().ToUpper())
                                             .Select(g => new
                                             {
                                                 ArticulWB = g.Key,
                                                 TotalQuantity = g.Sum(row => int.TryParse(row[4]?.ToString(), out int quantity) ? quantity : 0),
                                                 Rows = g.ToList()
                                             });

                    DataTable dt = new DataTable();

                    dt.Columns.Add("�����", typeof(string));
                    dt.Columns.Add("������� ��������", typeof(string));
                    dt.Columns.Add("������� WB", typeof(string));
                    dt.Columns.Add("������", typeof(string));
                    dt.Columns.Add("������� �������", typeof(int));

                    foreach (var group in result)
                    {
                        foreach (var row in group.Rows)
                        {
                            dt.Rows.Add(row);
                        }
                    }
                    dataGridView1.DataSource = dt;
                    */

                    #endregion



                    #region 2_�������
                    /*
                    var result = dataRows.GroupBy(row => row[2]?.ToString().Trim().ToUpper())
                                         .Select(g => new
                                         {
                                             ArticulWB = g.Key,
                                             TotalQuantity = g.Sum(row => int.TryParse(row[4]?.ToString(), out int quantity) ? quantity : 0),
                                             Rows = g.ToList()
                                         });


                    DataTable dt = new DataTable();

                    dt.Columns.Add("�����", typeof(string));
                    dt.Columns.Add("������� ��������", typeof(string));
                    dt.Columns.Add("������� WB", typeof(string));
                    dt.Columns.Add("������", typeof(string));
                    dt.Columns.Add("������� �������", typeof(int));

                    foreach (var group in result)
                    {
                        foreach (var row in group.Rows)
                        {
                            dt.Rows.Add(row);
                        }
                    }

                    dataGridView1.DataSource = dt;
                    */
                    #endregion

                    #region 1_�������
                    /*
                    for (int row = 1; row <= worksheet.Dimension.End.Row; row++)
                    {
                        object[] rowData = new object[17]; // ����������, ��� ����� 17 - ���������� ��������
                        for (int col = 1; col <= 17; col++)
                        {
                            if (worksheet.Cells[row, col].Value != null)
                            {
                                rowData[col - 1] = worksheet.Cells[row, col].Value;
                            }
                            else
                            {
                                rowData[col - 1] = ""; // ��� ������ �������� �� ������ ������
                            }
                        }
                        dataRows.Add(rowData);
                    }

                    var result = dataRows.GroupBy(row => row[5]?.ToString())
                                         .Select(g => new { Brand = g.Key, TotalQuantity = g.Sum(row => int.TryParse(row[2]?.ToString(), out int quantity) ? quantity : 0) });

                    

                    DataTable dt = new DataTable();

                    // ��������� �������
                    dt.Columns.Add("Brand", typeof(string));
                    dt.Columns.Add("TotalQuantity", typeof(int));

                    // ��������� ������ �� ���������� � �������
                    foreach (var item in result)
                    {
                        dt.Rows.Add(item.Brand, item.TotalQuantity);
                    }
                    */
                    #endregion

                    // ������� �������


                    // ���������� ������ � DataGridView

                }
            }
        }

        public class DataRowComparer : IEqualityComparer<object[]>
        {
            private static readonly StringComparer _comparer = StringComparer.OrdinalIgnoreCase;

            public bool Equals(object[] x, object[] y)
            {
                if (x == null || y == null || x.Length != y.Length)
                    return false;

                for (int i = 0; i < x.Length; i++)
                {
                    var xString = x[i]?.ToString().Trim();
                    var yString = y[i]?.ToString().Trim();
                    if (!_comparer.Equals(xString, yString))
                        return false;
                }
                return true;
            }

            public int GetHashCode(object[] obj)
            {
                unchecked
                {
                    int hash = 17;
                    foreach (var item in obj)
                    {
                        hash = hash * 23 + (_comparer.GetHashCode(item?.ToString().Trim() ?? string.Empty));
                    }
                    return hash;
                }
            }
        }

        private void bindingSourcePodsorti_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
