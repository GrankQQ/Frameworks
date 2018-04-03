using Algorithm;
using Framework.Files;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayAlgorithm arrThm = new ArrayAlgorithm();
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<string> resultList = arrThm.GetAllResult(arr, 100);
            foreach (string s in resultList)
            {
                Console.WriteLine(s);
            }
            //Console.ReadLine();

            List<A> aList = new List<A>();
            aList.Add(null);
            var a = aList.Where(c => c.Name == "23");
            Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            sb.Append("abc");
            Console.WriteLine(sb.ToString());
            sb.Clear();
            sb.Append("cde");
            Console.WriteLine(sb.ToString());
            Console.ReadLine();

            string s2 = "P0000063755";
            string barCode = "6922208421170,P0000063755";
            barCode = s2 + "," + barCode;
            string s1 = "6922208421170";
            bool isRemove = barCode.ToUpper().Split(',').Contains(s1.ToUpper());
            Console.WriteLine(isRemove);
            Console.ReadLine();

            DataTable dt = new DataTable();
            dt.Columns.Add("ABC");
            dt.Columns.Add("BCD");

            DataRow dr = dt.NewRow();
            dr["ABC"] = "123";
            dr["BCD"] = "456";
            dt.Rows.Add(dr);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(dt.AsEnumerable().Select(c => c.Table)));
            Console.ReadLine();

            Console.WriteLine(-5/2);
            Console.WriteLine(Math.Pow(5,5));
            Console.ReadLine();

            Type t = typeof(ReflectionTest);
            MemberInfo[] allMemberInfos = t.GetMembers();

            MemberInfo[] specialMemberInfos = t.GetMember("privateName");
            MemberInfo[] nonPublicInfos = t.GetMembers(BindingFlags.NonPublic | BindingFlags.CreateInstance | BindingFlags.GetField);

            MethodInfo methodInfo = t.GetMethod("setName");

            object obj = Activator.CreateInstance(t);
            object[] param = new object[] { "publicName", "privateName" };
            methodInfo.Invoke(obj, param);
        }

        
    }

    class A
    {
        public int Age;

        public string Name;
    }
}
