using DBModule.Classes;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using MessageBox = System.Windows.Forms.MessageBox;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace importBD.Pages
{
    /// <summary>
    /// Логика взаимодействия для main.xaml
    /// </summary>
    public partial class main : Page
    {
        public main()
        {
            InitializeComponent(); 
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }
        public void importClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (ExcelPackage excelPackage = new ExcelPackage(new System.IO.FileInfo(filePath)))
                {
                    foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                    {
                        List<string> tableNames = new List<string>();
                        int numberOfRows = worksheet.Dimension.Rows;
                        int numberOfColumns = worksheet.Dimension.Columns;
                        for (int row = 1; row <= numberOfRows; row++)
                        {
                            var rowData = new List<string>();
                            for (int col = 1; col <= numberOfColumns; col++)
                            {
                                var cellValue = worksheet.Cells[row, col].Value?.ToString();
                                rowData.Add(cellValue);
                            }
                            tableNames.Add($"{string.Join("|", rowData)}");
                        }
                        switch (tableNames[0])
                        {
                            case "Login|Password|Role|Email|Name|Surname|Patronymic|Phone|Adress":
                                import(tableNames, "INSERT INTO Users ([Login],[Password],[Role],[Email],[Name],[Surname],[Patronymic],[Phone],[Adress])" +
                                    "VALUES");
                                break;
                            case "Rooms":
                                MessageBox.Show("sheet2");
                                break;
                        }  
                        string result = string.Join("\n", tableNames);
                        MessageBox.Show($"Данные по строкам:\n{result}");
                    }
                }

                MessageBox.Show("Файл успешно выбран и обработан!");
            }
        }
        public void import(List<string> list, string request)
        {
            foreach (string tableName in list)
            {
                if (tableName == list[0]) { }
                else 
                {
                    string[] data = tableName.Split('|');
                    string values = string.Join(", ", data.Select(d => $"'{d}'"));
                    MsSQL.Select(request + $"({values})", DBModule.Pages.Settings.ConnectionString);
                }
            }
        }
    }

}
