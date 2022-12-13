using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AlgoritmosOrdenado;
using System.Linq;

namespace SortingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BubbleSort_Test()
        {
            // Arrange
            Random random = new Random();
            ArraySort arrSort = new ArraySort(10000, random);
            int[] temp = new int[arrSort.array.Length];
            Array.Copy(arrSort.array, temp, arrSort.array.Length);

            // Act
            arrSort.BubbleSort(temp);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(temp, arrSort.arrayIncreasing));

            //Assert.IsTrue(true);
            //throw new Exception("Has fallado el test");
        }

        [TestMethod]
        public void QuickSort_Test()
        {
            // Arrange
            Random random = new Random();
            ArraySort arrSort = new ArraySort(10000, random);
            int[] temp = new int[arrSort.array.Length];
            Array.Copy(arrSort.array, temp, arrSort.array.Length);

            // Act
            arrSort.QuickSort(temp);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(temp, arrSort.arrayIncreasing));
        }

        [TestMethod]
        public void InsertionSort_Test()
        {
            // Arrange
            Random random = new Random();
            ArraySort arrSort = new ArraySort(10000, random);
            int[] temp = new int[arrSort.array.Length];
            Array.Copy(arrSort.array, temp, arrSort.array.Length);

            // Act
            arrSort.InsertionSort(temp);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(temp, arrSort.arrayIncreasing));
        }

        [TestMethod]
        public void SelectionSort_Test()
        {
            // Arrange
            Random random = new Random();
            ArraySort arrSort = new ArraySort(10000, random);
            int[] temp = new int[arrSort.array.Length];
            Array.Copy(arrSort.array, temp, arrSort.array.Length);

            // Act
            arrSort.SelectionSort(temp);

            // Assert
            Assert.IsTrue(Enumerable.SequenceEqual(temp, arrSort.arrayIncreasing));
        }
    }
}
