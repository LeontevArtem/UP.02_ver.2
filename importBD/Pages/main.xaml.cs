using DBModule.Classes;
using OfficeOpenXml;
using System;
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
        Func<Page, int> BackClick;
        Page ParrentPage;
        public main(Page parrentPage, Func<Page, int> BackClick)
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            BackButton.MouseDown += delegate { BackClick(parrentPage); };
            this.BackClick = BackClick;
            this.ParrentPage = parrentPage;
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
                        switch (worksheet.Name)
                        {
                            case "Users":
                                import(tableNames, "INSERT INTO Users ([Login],[Password],[Role],[Email],[Name],[Surname],[Patronymic],[Phone],[Adress])" +
                                    "VALUES");
                                break;
                            case "Equipment_types":
                                import(tableNames, "INSERT INTO Equipment_types ([Name])" +
                                    "VALUES");
                                break;
                            case "Models":
                                import(tableNames, "INSERT INTO Models ([Name],[Type])" +
                                    "VALUES");
                                break;
                            case "Directions":
                                import(tableNames, "INSERT INTO Directions ([Name])" +
                                    "VALUES");
                                break;
                            case "Inventory":
                                import(tableNames, "INSERT INTO Inventory ([Date_start],[Date_end],[EquipmentID],[Comment],[UserID])" +
                                    "VALUES");
                                break;
                            case "Consumables":
                                import(tableNames, "INSERT INTO Consumables ([Name],[Description],[ReceiptDate],[Image],[Quanity],[ResponsibleUser],[TempResponsibleUser])" +
                                    "VALUES");
                                break;
                            case "Developers":
                                import(tableNames, "INSERT INTO Developers ([Name])" +
                                    "VALUES");
                                break;
                            case "Programs":
                                import(tableNames, "INSERT INTO Programs ([Name],[Developer],[Version])" +
                                    "VALUES");
                                break;
                            case "Equipment":
                                import(tableNames, "INSERT INTO Equipment ([Name],[Image],[Room],[User],[Temp_user],[Cost] ,[Direction],[Model],[Type])" +
                                    "VALUES");
                                break;
                            case "Rooms":
                                import(tableNames, "INSERT INTO Rooms ([Name],[Short_name],[Temp_user],[User])" +
                                    "VALUES");
                                break;
                            default:
                                MessageBox.Show("Данных для импорта не обнаружено");
                                break;
                        }  
                        //string result = string.Join("\n", tableNames);
                        //MessageBox.Show($"Данные по строкам:\n{result}");
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
