using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class ReToStringTest
    {
        public static void main(string[] args)
        {
            List<int> list = new List<int>();
            list.Add(1000);
            list.Add(2000);
            Console.WriteLine(list.ToString2());
            Console.WriteLine(list.ToString("N0"));
            Console.ReadLine();            
        }

        public static void Compute(long result)
        {
            for(long i =0; i< 10000;i++)
            {
                for (long j = 0; j < 10000; j++)
                {
                    for (long k = 0; k < 10000; k++)
                    {
                        long a = i + j;
                        long b = j + k;
                        long c = i + k;
                        if (a != 0 && b != 0 && c != 0)
                        {
                            if (result * a * b * c == i * a * c + j * a * b + k * b * c)
                            {
                                Console.WriteLine($"i:{i}, j:{j}, k:{k}");
                            }
                        }
                    }
                }
            }
            Console.WriteLine("nothing");
        }


        public static void Run<T>(Action<T> func)
        {
            Console.WriteLine("func.Method.Name: " + func.Method.Name);
            Console.WriteLine("func.Method.Attributes: " + func.Method.Attributes);
            //Console.WriteLine(": " + func.Method.Name);
            //Console.WriteLine(": " + func.Method.Name);
            //Console.WriteLine(": " + func.Method.Name);
            //Console.WriteLine(": " + func.Method.Name);
            //Console.WriteLine(": " + func.Method.Name);
            //Console.WriteLine(": " + func.Method.Name);
            //Console.WriteLine(": " + func.Method.Name);
            //Console.WriteLine(": " + func.Method.Name);
            //Console.WriteLine(": " + func.Method.Name);
            //Console.WriteLine(": " + func.Method.Name);
            //Console.WriteLine(": " + func.Method.Name);
        }
    }

    

    public static class StringExtensions
    {
        public static string ToString2<T>(this List<T> l)
        {
            string retVal = string.Empty;
            foreach (T item in l)
                retVal += string.Format("{0}{1}", string.IsNullOrEmpty(retVal) ?
                                                            "" : ", ",
                                         item);
            return string.IsNullOrEmpty(retVal) ? "{}" : "{ " + retVal + " }";
        }

        public static string ToString<T>(this List<T> l, string fmt)
        {
            string retVal = string.Empty;
            foreach (T item in l)
            {
                IFormattable ifmt = item as IFormattable;
                if (ifmt != null)
                    retVal += string.Format("{0}{1}",
                                            string.IsNullOrEmpty(retVal) ?
                                               "" : ", ", ifmt.ToString(fmt, null));
                else
                    retVal += ToString2(l);
            }
            return string.IsNullOrEmpty(retVal) ? "{}" : "{ " + retVal + " }";
        }
    }
}
