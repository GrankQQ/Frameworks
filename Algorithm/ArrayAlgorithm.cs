using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public class ArrayAlgorithm
    {
        public List<string> GetAllResult(int[] arr, int result)
        {
            List<string> resultList = new List<string>();
            List<string> originalList = new List<string>() { arr[0].ToString() };
            for(int i = 1; i < arr.Length; i++)
            {
                originalList = ConnectString(originalList, arr[i]);
            }
            foreach(string s in originalList)
            {
                if(GetResult(s) == 100)
                {
                    resultList.Add(s);
                }
            }
            return resultList;
        }

        public int GetResult(string s)
        {
            int result = 0;
            string[] dArray = s.Split('+');
            foreach(string f in dArray)
            {
                int sum = 0;
                string[] fArray = f.Split('-');
                if (fArray.Length > 0)
                {
                    sum = Convert.ToInt32(fArray[0]);
                    for(int i = 1; i < fArray.Length; i++)
                    {
                        sum -= Convert.ToInt32(fArray[i]);
                    }
                }
                result += sum;                
            }

            return result;
        }

        public List<string> ConnectString(List<string> list, int result)
        {
            List<string> resultList = new List<string>();
            foreach (string s in list)
            {
                resultList.Add(s + "+" + result);
                resultList.Add(s + "-" + result);
                resultList.Add(s + "" + result);
            }
            return resultList;
        }

        public int Sum(int a, int b, StringBuilder sb)
        {
            sb.Append($" + {b}");
            return a + b;
        }

        public int Subtract(int a, int b, StringBuilder sb)
        {
            sb.Append($" - {b}");
            return a - b;
        }

        public int ConnectSum(int a, int b, StringBuilder sb)
        {
            sb.Append($"{b}");
            return Convert.ToInt32(a * 10 * Math.Pow(10, (b / 10)) + b);
        }

        public int[] InsertSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int value = arr[i];
                int j = i - 1;
                for (; j > 0; j--)
                {
                    if (value < arr[j])
                    {
                        arr[j + 1] = arr[j];
                    }
                    else
                    {
                        break;
                    }
                }
                arr[j] = value;
            }

            return arr;
        }

        public int[] SelectSort(int[] arr)
        {            
            for (int i = 0; i < arr.Length; i++)
            {
                int value = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if(value > arr[j])
                    {
                        arr[i] = arr[j];
                        value = arr[j];
                    }
                }
            }

            return arr;
        }

        public int[] MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
            return arr;
        }


        public void MergeSort(int[] arr, int start, int end)
        {
            if (start >= end)
                return;

            int middle = (start + end) / 2;
            MergeSort(arr, start, middle);
            MergeSort(arr, middle + 1, end);

            MergeSort(arr, start, middle, end);
        }

        private void MergeSort(int[] arr, int start, int middle, int end)
        {
            int[] temp = new int[end - start];
            int i = start;
            int j = middle + 1;
            int count = 0;
            while (i < middle || j < end)
            {
                if (arr[i] < arr[j])
                {
                    temp[count] = arr[i];
                    i++;
                }
                else
                {
                    temp[count] = arr[j];
                    j++;
                }
                count++;
            }

            count = 0;
            for(int k = start; k < end; k++)
            {
                arr[k] = temp[count];
                count++;
            }
        }
    }
}
