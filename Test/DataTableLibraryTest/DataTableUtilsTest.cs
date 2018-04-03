using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using DataTableLibrary;
using System.IO;
using Framework.Files;
using System.Text;
using System.Collections.Generic;
using Utility;

namespace Test.DataTableLibraryTest
{
    [TestClass]
    public class DataTableUtilsTest
    {
        [TestMethod]
        public void SortTableTest()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Count", typeof(int));

            DataRow dr1 = dt.NewRow();
            dr1["ID"] = "12";
            dr1["Count"] = 2;
            dt.Rows.Add(dr1);

            DataRow dr2 = dt.NewRow();
            dr2["ID"] = "12";
            dr2["Count"] = 1;
            dt.Rows.Add(dr2);

            dt = DataTableUtils.SortTable(dt, "Count asc");
            Assert.AreEqual(dt.Rows[0]["Count"], 1);
        }

        [TestMethod]
        public void LoadSQLExcel()
        {
            string filePath = "E:\\DataBase.xlsx";
            string outFilePath = "E:\\abc.sql";

            ExcelToSQLUtility.CreateTableAccordingExcel(filePath, outFilePath);
            
        }
    }
}
