using System;
using System.Diagnostics;

namespace AlgoritmosOrdenado
{
    public class ArraySort
    {
        public int[] array;
        public int[] arrayIncreasing;
        public int[] arrayDecreasing;

        public ArraySort(int elements, Random random)
        {
            array = new int[elements];
            arrayIncreasing = new int[elements];
            arrayDecreasing = new int[elements];
            for (int i = 0; i < elements; i++)
            {
                array[i] = random.Next();
            }
            Array.Copy(array, arrayIncreasing, elements); //Se puede hacer también con un for
            Array.Sort(arrayIncreasing);

            Array.Copy(arrayIncreasing, arrayDecreasing, elements); //Copiar los elementos de la arrayIncresing a la arrayDecreasing
            Array.Reverse(arrayDecreasing); //Dar la vuelta a los elementos de la array
        }

        public void Benchmark(Action<int[]> function)
        {
            //function(array);
            Console.WriteLine(""); //Dejar una linea vacia entre cada funcion para que se ve mejor en la consola

            int[] temp = new int[array.Length];
            Array.Copy(array, temp, array.Length);
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine(function.Method.Name); //Imprimir el nombre de la funcion que está usando

            stopwatch.Start();
            function(temp);
            stopwatch.Stop();
            Console.WriteLine("Random: " + stopwatch.ElapsedMilliseconds + "(ms) " + stopwatch.ElapsedTicks + "(ticks)");
            stopwatch.Reset();

            stopwatch.Start();
            function(temp);
            stopwatch.Stop();
            Console.WriteLine("Increasing: " + stopwatch.ElapsedMilliseconds + "(ms) " + stopwatch.ElapsedTicks + "(ticks)");
            stopwatch.Reset();

            Array.Reverse(temp);
            stopwatch.Start();
            function(temp);
            stopwatch.Stop();
            Console.WriteLine("Decreasing: " + stopwatch.ElapsedMilliseconds + "(ms) " + stopwatch.ElapsedTicks + "(ticks)");
        }

        public void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if(arr[j] > arr[j +1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp; 
                    }
                }
            }
        }
        public void BubbleSortEariyExit(int[] arr)
        {
            bool isOrdered = true;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                isOrdered = true;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        isOrdered = false;
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
                if (isOrdered) return;
            }
        }

        public void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }
        public void QuickSort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int pivot =  QuickSortIndex(arr, left, right);
                QuickSort(arr, left, pivot);
                QuickSort(arr, pivot + 1, right);
            }
        }
        public int QuickSortIndex(int[] arr, int left, int right)
        {
            int pivot = arr[(left + right) / 2];

            while (true)
            {
                while(arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if(right <= left)
                {
                    return right;
                }
                else
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    right--;
                    left++;
                }
            }
        }

        public void InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if(arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public void SelectionSort(int[] arr)
        {
            int minIndex;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many numbers do you want?");
            int elements = int.Parse(Console.ReadLine());
            Console.WriteLine("What seed do you want to use?");
            int seed = int.Parse(Console.ReadLine());
            Random random = new Random(seed);
            ArraySort arraySort = new ArraySort(elements, random);
            arraySort.Benchmark(arraySort.BubbleSort);
            arraySort.Benchmark(arraySort.BubbleSortEariyExit);
            arraySort.Benchmark(arraySort.QuickSort);
            arraySort.Benchmark(arraySort.InsertionSort);
            arraySort.Benchmark(arraySort.SelectionSort);

            //Console.Clear();
        }
    }
}
