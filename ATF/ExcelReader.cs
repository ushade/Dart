using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;

namespace ATF
{
    public sealed class ExcelReader
    {
            [DllImport("user32.dll")]
            private static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out IntPtr ProcessId);

            public static string[] ReadAllDataInColumn(string columnName, string sheetName, string DataFileName)
            {
                List<string> iList = new List<string>();
                Application appClass = new Application();
                IntPtr hwnd = new IntPtr(appClass.Hwnd);
                IntPtr processId;
                try
                {
                    Workbook workBook = appClass.Workbooks.Open(DataFileName, Type.Missing, Type.Missing, Type.Missing,
                                                                Type.Missing, Type.Missing, Type.Missing,
                                                                Type.Missing, Type.Missing, Type.Missing,
                                                                Type.Missing, Type.Missing, Type.Missing,
                                                                Type.Missing, Type.Missing);
                    Worksheet sheet = (Worksheet)workBook.Sheets[sheetName];
                System.Console.WriteLine("Sheet" + sheet);
                    Range excelRange = sheet.UsedRange;
                System.Console.WriteLine("Range" + excelRange);
                    object[,] valueArray = (object[,])excelRange.Value[XlRangeValueDataType.xlRangeValueDefault];
                System.Console.WriteLine("ValueArray" + valueArray);
                int usedCol = excelRange.Columns.Count;
                System.Console.WriteLine("UsedColumn" + usedCol);
                    int totalcell = excelRange.Count;
                System.Console.WriteLine("Totalcell" + totalcell);
                    int usedRow = totalcell / usedCol;
                System.Console.WriteLine("usedRow" + usedRow);
                    for (int i = 1; i <= usedCol; i++)
                    {
                        if (valueArray[1, i].ToString() == columnName)
                        {
                            for (int j = 2; j <= usedRow; j++)
                            {
                                if (valueArray[j, i] == null)
                                {
                                    iList.Add(null);
                                }
                                else
                                {
                                    iList.Add(valueArray[j, i].ToString());
                                }
                            }
                        }
                    }
                    workBook.Close();
                    appClass.Quit();
                    if (sheet != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                    }
                    if (excelRange != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelRange);
                    }

                    if (workBook != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                    }

                    IntPtr foo = GetWindowThreadProcessId(hwnd, out processId);
                    Process proc = Process.GetProcessById(processId.ToInt32());
                    proc.Kill(); // set breakpoint here and watch the Windows Task Manager kill this exact EXCEL.EXE
                    GC.Collect();
                }
                catch (Exception)
                {
                    IntPtr foo = GetWindowThreadProcessId(hwnd, out processId);
                    Process proc = Process.GetProcessById(processId.ToInt32());
                    proc.Kill();
                    GC.Collect();
                    iList.Add("Invalid Datafile or sheetName. Please Check");
                }

                return iList.ToArray();
            }
            public static string[] ReadAllRowDataBetweenColumns(string startColumnName, string endColumnName, string sheetName, string DataFileName)
            {
                int startC = -1;
                int endC = -1;
                List<string> iList = new List<string>();
                Application appClass = new Application();
                IntPtr hwnd = new IntPtr(appClass.Hwnd);
                IntPtr processId;
                try
                {
                    Workbook workBook = appClass.Workbooks.Open(DataFileName, Type.Missing, Type.Missing,
                                                                Type.Missing, Type.Missing, Type.Missing,
                                                                Type.Missing, Type.Missing, Type.Missing,
                                                                Type.Missing, Type.Missing, Type.Missing,
                                                                Type.Missing, Type.Missing, Type.Missing
                        );
                    int numSheets = workBook.Sheets.Count;
                System.Console.WriteLine("Sheet" + numSheets);
                Worksheet sheet = (Worksheet)workBook.Sheets[sheetName];
                System.Console.WriteLine("Sheet" + sheet);
                Range excelRange = sheet.UsedRange;
                System.Console.WriteLine("XLRange" + excelRange);
                object[,] valueArray = (object[,])excelRange.Value[XlRangeValueDataType.xlRangeValueDefault];
                System.Console.WriteLine("ValueArray" + valueArray);
                int usedCol = excelRange.Columns.Count;
                System.Console.WriteLine("UsedColumn" + usedCol);
                int totalcell = excelRange.Count;
                System.Console.WriteLine("Totalcell" + totalcell);
                int usedRow = totalcell / usedCol;
                System.Console.WriteLine("usedRow" + usedRow);
                for (int i = 1; i <= usedCol; i++) { if (valueArray[1, i].ToString() == startColumnName) { startC = i; } if (valueArray[1, i].ToString() == endColumnName) { endC = i; } }
                    if (startC == -1) { string errorInC1 = "Invalid Start ColumnName: " + startColumnName + ". Plesae check the case of header."; iList.Add(errorInC1); }
                    if (endC == -1) { string errorInC2 = "Invalid End ColumnName: " + endColumnName + ". Plesae check the case of header."; iList.Add(errorInC2); }
                    if (startC > -1 && endC > -1)
                    {
                        for (int i = 2; i <= usedRow; i++)
                        {
                            string rowElements = string.Empty;
                            string cellElement;
                            if (endC < startC)
                            {
                                for (int j = startC; j >= endC; j--)
                                {
                                    if (valueArray[i, j] == null)
                                    {
                                        cellElement = string.Empty;
                                    }
                                    else
                                    {
                                        cellElement = valueArray[i, j].ToString();
                                    }
                                    rowElements += cellElement + "~";
                                }
                            }
                            else //for reverse rows.
                            {
                                for (int j = startC; j <= endC; j++) { if (valueArray[i, j] == null) { cellElement = "NULL"; } else { cellElement = valueArray[i, j].ToString(); } rowElements += cellElement + "~"; }
                            }
                            iList.Add(rowElements.TrimEnd(new char[] { '~' }));
                        }
                    }
                    workBook.Close(); appClass.Quit(); if (sheet != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet); }
                    if (excelRange != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(excelRange); }
                    if (workBook != null) { System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook); }
                    IntPtr foo = GetWindowThreadProcessId(hwnd, out processId); Process proc = Process.GetProcessById(processId.ToInt32()); proc.Kill(); GC.Collect();
                }
                catch (Exception) { IntPtr foo = GetWindowThreadProcessId(hwnd, out processId); Process proc = Process.GetProcessById(processId.ToInt32()); proc.Kill(); GC.Collect(); iList.Add("Invalid Datafile or sheetName. Please Check"); }
                return iList.ToArray();
            }
            public static string[] ReadAllDataBetweenRows(int startRowNumber, int endRowNumber, string sheetName, string DataFileName)
            {
                if (endRowNumber > startRowNumber)
                {
                    List<string> iList = new List<string>();
                    Application appClass = new Application();
                    IntPtr hwnd = new IntPtr(appClass.Hwnd);
                    IntPtr processId;
                    try
                    {
                        Workbook workBook = appClass.Workbooks.Open(DataFileName, Type.Missing, Type.Missing,
                                                                    Type.Missing, Type.Missing, Type.Missing,
                                                                    Type.Missing, Type.Missing, Type.Missing,
                                                                    Type.Missing, Type.Missing, Type.Missing,
                                                                    Type.Missing, Type.Missing, Type.Missing
                            );
                        Worksheet sheet = (Worksheet)workBook.Sheets[sheetName];
                        Range excelRange = sheet.UsedRange;
                        object[,] valueArray = (object[,])excelRange.Value[XlRangeValueDataType.xlRangeValueDefault];
                        int usedCol = excelRange.Columns.Count;
                        int totalcell = excelRange.Count;
                        int usedRow = totalcell / usedCol;
                        if (startRowNumber > usedRow)
                        {
                            startRowNumber = usedRow;
                        }
                        for (int i = startRowNumber + 1; i <= endRowNumber + 1; i++)
                        {
                            string rowElements = string.Empty;
                            for (int j = 1; j <= usedCol; j++)
                            {
                                string cellElement;
                                if (valueArray[i, j] == null)
                                {
                                    cellElement = null;
                                }
                                else
                                {
                                    cellElement = valueArray[i, j].ToString();
                                }
                                rowElements += cellElement + "~";
                            }
                            iList.Add(rowElements.TrimEnd(new char[] { '~' }));
                        }
                        workBook.Close(null, null, null);
                        appClass.Quit();
                        if (sheet != null)
                        {
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                        }
                        if (excelRange != null)
                        {
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelRange);
                        }
                        if (workBook != null)
                        {
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                        }
                        IntPtr foo = GetWindowThreadProcessId(hwnd, out processId);
                        Process proc = Process.GetProcessById(processId.ToInt32());
                        proc.Kill(); // set breakpoint here and watch the Windows Task Manager kill this exact EXCEL.EXE
                        GC.Collect();
                    }
                    catch (Exception)
                    {
                        IntPtr foo = GetWindowThreadProcessId(hwnd, out processId);
                        Process proc = Process.GetProcessById(processId.ToInt32());
                        proc.Kill();
                        GC.Collect();
                        iList.Add("Invalid Datafile or sheetName. Please Check");
                    }

                    return iList.ToArray();
                }
                else
                {
                    string[] errorOutput = { "End Row Is Greater Than Start Row" };
                    return errorOutput;
                }
            }
            public static Dictionary<string, string>[] ReadAllDataWhereFirstRowIsHeader(string sheetName, string DataFileName)
            {
                List<string> iList = new List<string>();
                Application appClass = new Application();
                IntPtr hwnd = new IntPtr(appClass.Hwnd);
                IntPtr processId;
                Dictionary<string, string>[] rowsDictionary = null;
                try
                {
                    Workbook workBook = appClass.Workbooks.Open(DataFileName, Type.Missing, Type.Missing, Type.Missing,
                                                                Type.Missing, Type.Missing, Type.Missing,
                                                                Type.Missing, Type.Missing, Type.Missing,
                                                                Type.Missing, Type.Missing, Type.Missing,
                                                                Type.Missing, Type.Missing);
                    Worksheet sheet = (Worksheet)workBook.Sheets[sheetName];
                    Range excelRange = sheet.UsedRange;
                    object[,] valueArray = (object[,])excelRange.Value[XlRangeValueDataType.xlRangeValueDefault];
                    int usedCol = excelRange.Columns.Count;
                    int totalcell = excelRange.Count;
                    int usedRow = totalcell / usedCol;
                    rowsDictionary = new Dictionary<string, string>[usedRow - 1];
                    for (int i = 2; i <= usedRow; i++)
                    {
                        rowsDictionary[i - 2] = new Dictionary<string, string>();
                        for (int k = 1; k <= usedCol; k++)
                        {
                            if (valueArray[1, k] != null)
                                rowsDictionary[i - 2].Add(valueArray[1, k].ToString(), valueArray[i, k].ToString());
                        }
                    }
                    workBook.Close();
                    appClass.Quit();
                    if (sheet != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                    }
                    if (excelRange != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelRange);
                    }

                    if (workBook != null)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(workBook);
                    }

                    IntPtr foo = GetWindowThreadProcessId(hwnd, out processId);
                    Process proc = Process.GetProcessById(processId.ToInt32());
                    proc.Kill(); // set breakpoint here and watch the Windows Task Manager kill this exact EXCEL.EXE
                    GC.Collect();
                }
                catch (Exception)
                {
                    IntPtr foo = GetWindowThreadProcessId(hwnd, out processId);
                    Process proc = Process.GetProcessById(processId.ToInt32());
                    proc.Kill();
                    GC.Collect();
                    iList.Add("Invalid Datafile or sheetName. Please Check");
                }

                return rowsDictionary;
            }
        }

    }

