using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqLibrary;
using System.Transactions;
using System.Data.SqlClient;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InsertTest()
        {
            UserData c = new UserData();
            c.Insert();
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Test()
        {
            TransactionOptions options = new TransactionOptions();
            options.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            options.Timeout = TransactionManager.DefaultTimeout;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, options))
            {                
                scope.Complete();
                using(SqlConnection conn = new SqlConnection("Data Source=192.168.60.49;Initial Catalog=benlaiSales;Persist Security Info=True;User ID=sa;Password=cc.123"))
                {
                    conn.Open();
                    string cmd = "SELECT TOP 1 * FROM DO_Master";
                    SqlCommand sc = new SqlCommand(cmd);
                    SqlDataReader reader = sc.ExecuteReader();
                    conn.Close();
                }
            }
        }
    }
}
