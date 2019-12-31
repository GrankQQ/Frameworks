using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAlgorithm
{
    public class ArrayAlgorithm
    {
        public List<string> GetAllResult(int[] arr, int result)
        {
            List<string> resultList = new List<string>();
            List<string> originalList = new List<string>() { arr[0].ToString() };
            for (int i = 1; i < arr.Length; i++)
            {
                originalList = ConnectString(originalList, arr[i]);
            }
            foreach (string s in originalList)
            {
                if (GetResult(s) == 100)
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
            foreach (string f in dArray)
            {
                int sum = 0;
                string[] fArray = f.Split('-');
                if (fArray.Length > 0)
                {
                    sum = Convert.ToInt32(fArray[0]);
                    for (int i = 1; i < fArray.Length; i++)
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

        /// <summary>
        /// 插入排序 （1、排序，2、插入） 时间复杂度O(n的平方)，空间复杂度O(1)
        /// 数组 -> 已排序区间 | 未排序区间 
        ///                 |
        ///           循环未排序区间
        ///                 |
        ///         循环比较已排序区间
        ///                 |
        ///      找到更好比该元素小的数据
        ///                 |
        /// 将该元素插入到比该元素更小的位置之后
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] InsertSort(int[] arr)
        {
            for (int i = 1; i < arr.Length - 1; i++)
            {
                int value = arr[i];
                int j = i - 1;
                for (; j >= 0; j--)
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
                arr[j + 1] = value;
            }

            return arr;
        }

        /// <summary>
        /// 选择排序（1、查找未分组区间最小的元素，2、将该元素放到已排序区间末尾） 时间复杂度O(n的平方)，空间复杂度O(1)
        /// 数组 -> 已分组区间 | 未分组区间
        ///                    |
        ///              循环未分组区间
        ///                    |
        /// 将未分组区间中最小的元素放到已分组区间最末尾
        ///                    |
        ///                 循环结束
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] SelectSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int value = arr[i];
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (value > arr[j])
                    {
                        value = arr[j];
                        arr[j] = arr[i];
                        arr[i] = value;
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// 归并排序（1、分治，2、排序合并） 时间复杂度O(nlogn)，空间复杂度O(n)
        /// 数组 -> 分为两部分，第一部分按照递归方式，对数组分组，每次分组一半
        ///         第二部分，对分组的数组进行排序合并
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 合并数组
        /// 将两个数组按照顺序合并为一个
        /// 思路 -> 新建一个数组，大小为两个数组之和
        ///                     |
        ///  比较两个数组中的元素，依次按照大小赋值给新数组
        ///                     |
        ///         判断哪一个数组没有循环完成
        ///                     |
        ///  将没有循环到尾的数组的值赋值给新数组后面的元素
        ///                     |
        ///           将新数组的值替换掉原数组
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="middle"></param>
        /// <param name="end"></param>
        private void MergeSort(int[] arr, int start, int middle, int end)
        {
            //新建一个数组，大小为两个数组之和
            int[] temp = new int[end - start + 1];
            int i = start;
            int j = middle + 1;
            int count = 0;

            //比较两个数组中的元素，依次按照大小赋值给新数组
            while (i <= middle && j <= end)
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

            //判断哪一个数组没有循环完成，将没有循环到尾的数组的值赋值给新数组后面的元素
            if (i <= middle)
            {
                for (; i <= middle; i++)
                {
                    temp[count] = arr[i];
                    count++;
                }
            }

            if (j <= end)
            {
                for (; j <= end; j++)
                {
                    temp[count] = arr[j];
                    count++;
                }
            }

            //将新数组的值替换掉原数组
            count = 0;
            for (int k = start; k <= end; k++)
            {
                arr[k] = temp[count];
                count++;
            }
        }

        public int[] QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
            return arr;
        }

        public void QuickSort(int[] arr, int start, int end)
        {
            

        }

        public void QuickSort(int[] arr, int start, int middle, int end)
        {

        }
    }
}
