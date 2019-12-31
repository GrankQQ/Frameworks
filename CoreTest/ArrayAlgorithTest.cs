using CoreAlgorithm;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest
{
    public class ArrayAlgorithTest
    {
        ArrayAlgorithm algorithm = new ArrayAlgorithm();
        int[] arr = new int[] { 3, 6, 2, 78, 32, 77, 43, 7, 23, 64, 7 };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test()
        {
            int[] arr1 = algorithm.InsertSort(arr);
            arr = new int[] { 3, 6, 2, 78, 32, 77, 43, 7, 23, 64, 7 };
            int[] arr2 = algorithm.SelectSort(arr);
            arr = new int[] { 3, 6, 2, 78, 32, 77, 43, 7, 23, 64, 7 };
            int[] arr3 = algorithm.MergeSort(arr);
            Assert.Pass();
        }
    }
}
