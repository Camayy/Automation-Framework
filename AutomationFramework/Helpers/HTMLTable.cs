using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Helpers
{
    /// <summary>
    /// Finds elements inside a html table and stores in TableData class
    /// </summary>
    public class HTMLTable
    {
        private static List<TableData> _tableData;
        public static void ReadTable(IWebElement table)
        {
            _tableData = new List<TableData>();

            var columns = table.FindElements(By.TagName("th"));
            var rows = table.FindElements(By.TagName("tr"));
            int i = 0;
            int x = 0;
            foreach(var row in rows)
            {
                var currentCol = row.FindElements(By.TagName("td"));
                if (currentCol.Count >= 1)
                {
                    foreach (var col in columns)
                    {
                        _tableData.Add(new TableData
                        {
                            RowNum = x,
                            ColName = columns[i].Text,
                            ColValue = col.Text,
                            ColElementValue = GetElementFromTable(col)

                        });
                    }
                    i++;
                }
                x++;
            }

        }

        /// <summary>
        /// retrieves the specific value from position in table
        /// </summary>
        /// <param name="columnValue"></param>
        /// <returns></returns>
        private static ColumnElement GetElementFromTable(IWebElement columnValue)
        {
            ColumnElement colElement = null;

            if (columnValue.FindElements(By.TagName("a")).Count > 0)
            {
                colElement = new ColumnElement
                {
                    Elements = columnValue.FindElements(By.TagName("a")),
                    ElementType = "hyperlink"
                };
            }
            if (columnValue.FindElements(By.TagName("input")).Count > 0)
            {
                colElement = new ColumnElement
                {
                    Elements = columnValue.FindElements(By.TagName("input")),
                    ElementType = "input"
                };
            }
            return colElement;
        }

        private static IEnumerable GetDynamicRowNumber(string colName, string colValue)
        {
            foreach(var table in _tableData)
            {
                if (table.ColName == colName && table.ColValue == colValue)
                    yield return table.RowNum;
            }
        }

        /// <summary>
        /// performs a action on a dynamically found cell
        /// </summary>
        /// <param name="colIndex"></param>
        /// <param name="colValue"></param>
        /// <param name="colName"></param>
        /// <param name="control"></param>
        public static void ClickTableElement(string colIndex, string colValue, string colName, string control = null)
        {
            foreach(int rowNum in GetDynamicRowNumber(colName, colValue))
            {
                var cell = (from e in _tableData
                            where e.ColName == colIndex && e.RowNum == rowNum
                            select e.ColElementValue).SingleOrDefault();

                //
                if (control != null && cell !=null )
                {
                    if (cell.ElementType == "input")
                    {
                        var actionedControl = (from e in cell.Elements
                                               where e.GetAttribute("value") == control
                                               select e).SingleOrDefault();

                        actionedControl.Click();
                    }
                    else if (cell.ElementType == "hyperlink")
                    {
                        var actionedControl = (from e in cell.Elements
                                               where e.Text == control
                                               select e).SingleOrDefault();

                        actionedControl.Click();
                    }
                }
                else
                {
                    cell.Elements.First().Click();
                }
                
            }
        }
    }

    /// <summary>
    /// Class containing HTML Table data variables to be assigned
    /// </summary>
    internal class TableData 
    {
        public int RowNum { get; set; }
        public string ColName { get; set; }
        public string ColValue { get; set; }
        public ColumnElement ColElementValue { get; set; }
    }

    /// <summary>
    /// Class containing the elements of a column to be assigned
    /// </summary>
    internal class ColumnElement
    {
        public IEnumerable<IWebElement> Elements { get; set; }
        public string ElementType { get; set; }
    }

}
