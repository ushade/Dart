using System;
using System.Data;
using System.IO;
using ExcelDataReader;
using System.Linq;

namespace ATF
{
    public class ReadExcelTest
    {
        public void ReadExcel()
        {
            String filePath = @"C:\\UshaDevaraj\\C#Project\\ATF\\ATF\\DataFile\\Book1.xlsx";
            //FileStream stream = File.Open(@"C:\\UshaDevaraj\\C#Project\\ATF\\ATF\\DataFile\\Book1.xlsx", FileMode.Open, FileAccess.Read);
            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader;
            //1. Reading Excel file
            if (Path.GetExtension(filePath).ToUpper() == ".XLS")
            {
                //1.1 Reading from a binary Excel file ('97-2003 format; *.xls)
                excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else
            {
                //1.2 Reading from a OpenXml Excel file (2007 format; *.xlsx)
                excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }
            //3. DataSet - Create column names from first row
                var res = new ExcelDataSetConfiguration(){
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            };
            //4. DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result = excelReader.AsDataSet();
            //5. Data Reader methods
            while (excelReader.Read())
            {
                DataTable dt = result.Tables[0];
                //excelReader.GetInt32(0);
            }

           // 6.Free resources(IExcelDataReader is IDisposable)
            excelReader.Close();

       
            //Console.WriteLine(DataSet.Tables[0].Rows.Count);
            //Console.WriteLine(DataSet.Tables[0].Columns.Count);
            //var cellStr = "AB2"; // var cellStr = "A1";
            //var match = System.Text.RegularExpressions.Regex.Match(cellStr, @"(?<col>[A-Z]+)(?<row>\d+)");
            //var colStr = match.Groups["col"].ToString();
            //var col = colStr.Select((t, i) => (colStr[i] - 64) * Math.Pow(26, colStr.Length - i - 1)).Sum();
            //var row = int.Parse(match.Groups["row"].ToString());
            //for (var i = row; i < DataTable.Rows.Count; i++)
            //{
            //    for (var j = col; j < DataTable.Columns.Count; j++)
            //    {
            //        var data = DataTable.Rows[i][j];
            //    }
            //}







        }
       





    }
}
