using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Grank.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Drug> list = GetDrugs("E:\\sqs\\钱钱\\大额.txt");
            //list.AddRange(GetDrugs("E:\\sqs\\钱钱\\小额.txt"));

            Console.WriteLine(Compare(null, null));
            Console.WriteLine(Compare(null, 2));
            Console.WriteLine(Compare(1, 2));
            Console.WriteLine(Compare(1, 1));

            Console.ReadLine();

            Console.WriteLine("Hello World!");
        }

        private static bool Compare(int? a, int? b)
        {
            return a == b;
        }

        private static List<Drug> GetDrugs(string filePath)
        {
            
            List<Drug> list = new List<Drug>();

            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                string line = "";

                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (line.Contains("单价"))
                        {
                            string removeCharecters = line.Replace("元", "").Replace("盒", "");
                            string name = removeCharecters.Trim().Substring(0, line.IndexOf("单价："));
                            string otherInformation = removeCharecters.Trim().Substring(line.IndexOf("单价：") + "单价：".Length);
                            string price = otherInformation.Trim().Substring(0, otherInformation.IndexOf("*"));
                            string unit = otherInformation.IndexOf(" ") == -1 ? otherInformation.Trim().Substring(otherInformation.IndexOf("*")) : otherInformation.Trim().Substring(otherInformation.IndexOf("*") + otherInformation.IndexOf(" "));

                            if (!list.Any(c => c.Name == name))
                            {
                                Drug d = new Drug();
                                d.Name = name;
                                d.Price = Convert.ToDecimal(price);
                                d.Unit = Convert.ToInt32(unit);
                                list.Add(d);
                            }
                        }

                        string[] strs = line.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                        if (strs != null && strs.Length > 4)
                        {
                            if (strs[1].Contains("单价："))
                            {
                                if (!list.Any(c => c.Name == strs[0]))
                                {
                                    Drug d = new Drug();
                                    string sPrices = strs[1].Replace("单价：", "").Replace("元", "").Replace("盒", "").Trim();
                                    d.Name = strs[0];
                                    d.Price = Convert.ToDecimal(sPrices);
                                    d.Unit = Convert.ToInt32(strs[3].Replace("盒", "").Trim());
                                    list.Add(d);
                                }                                
                            }
                        }
                    }
                }
            }
            return list;
        }
    }

    public class Drug
    {
        /// <summary>
        /// 药品
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 个数
        /// </summary>
        public int Unit { get; set; }
    }
}
