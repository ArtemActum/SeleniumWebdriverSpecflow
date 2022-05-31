using ExcelDataReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWendriver.ExcelReader
{
    [TestClass]
    public class TestExcelData
    {
        [TestMethod]
        public void TestReadExcel()
        {   // 1 Example

            //FileStream stream = new FileStream(@"C:\downloads\Cucumber\Data.xlsx", FileMode.Open, FileAccess.Read);
            //IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            //DataTable table = reader.AsDataSet().Tables["Bugzilla"];
            //Console.WriteLine("Data : {0}", table.Rows[0][0]);
            //for (int i = 0; i < table.Rows.Count; i++)
            //{
            //    var col = table.Rows[i];
            //    for (int j = 0; j < col.ItemArray.Length; j++)
            //    {
            //        Console.Write("Data : {0}", col.ItemArray[j]);
            //    }
            //    Console.WriteLine();
            //}

            // 2 Example

            string xlPath = @"C:\downloads\Cucumber\Data.xlsx";
            Console.WriteLine(ExcelReaderHelper.GetCellData(xlPath, "Bugzilla", 0, 0));
            Console.WriteLine(ExcelReaderHelper.GetCellData(xlPath, "Bugzilla", 0, 1));
            Console.WriteLine(ExcelReaderHelper.GetCellData(xlPath, "Bugzilla", 0, 2));
           


        }
    }
}
