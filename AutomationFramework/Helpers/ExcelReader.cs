using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Helpers
{
    public class ExcelReader
    {
        private static List<DataCollection> _dataCollection = new List<DataCollection>();

        /// <summary>
        /// populates datacollection from excel data table
        /// </summary>
        /// <param name="fileName"></param>
        public static void PopulateCollection(string fileName)
        {
            DataTable table = ReadExcelFile(fileName);

            for(int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Console.WriteLine(table.Columns[col].ColumnName);
                    string temp = table.Rows[row - 1][col].ToString();
                    DataCollection dtTable = new DataCollection()
                    {
                        rowNum = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                }
            }
        }

        /// <summary>
        /// populates datatable containing excel data
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static DataTable ReadExcelFile(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var excelFile = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = excelFile.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTableCollection collection = result.Tables;

                    DataTable resultTable = collection["Sheet1"];

                    return resultTable;
                }
            }
        }

        /// <summary>
        /// Reads DataCollection list into a string
        /// </summary>
        /// <param name="rowNumber"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string result = (from colData in _dataCollection
                                 where colData.colName == columnName && colData.rowNum == rowNumber
                                 select colData.colValue).SingleOrDefault();

                return result.ToString();
            }
            catch(Exception e)
            {
                return e.ToString();
            }

        }
    }
    /// <summary>
    /// Class to store the values of the excel data
    /// </summary>
    public class DataCollection
    {
        public int rowNum { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }
    }
}
