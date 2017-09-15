using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Task_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Сортированный массив: ");
            int[] sort = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            print(sort);
            Console.WriteLine();

            Console.Write("Обратный массив: ");
            int[] nesort = {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
            print(nesort);
            Console.WriteLine();

            Console.Write("Рандомный массив: ");
            int[] rand = { 2, 5, 6, 1, 9, 10, 3, 8, 4, 7 };
            print(rand);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Быстрая сортировка упорядеченного массива: ");
            Quick(sort);
            Console.WriteLine();
            Console.WriteLine("Быстрая сортировка обратного массива: ");
            Quick(nesort);
            Console.WriteLine();
            Console.WriteLine("Быстрая сортировка рандомного массива: ");
            Quick(rand);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Сортировка с помощью двоичного дерева в упорядоченном массиве: ");
            MyArray myArray = new MyArray(sort);
            myArray.TreeSort();
            print(myArray.Data);
            Console.WriteLine("\nКоличество сравнений: " + srTree);
            Console.WriteLine();
            srTree = 0;

            Console.WriteLine("Сортировка с помощью двоичного дерева в обратном массиве: ");
            myArray = new MyArray(nesort);
            myArray.TreeSort();
            print(myArray.Data);
            Console.WriteLine("\nКоличество сравнений: " + srTree);
            Console.WriteLine();
            srTree = 0;

            Console.WriteLine("Сортировка с помощью двоичного дерева в рандомном массиве: ");
            myArray = new MyArray(rand);
            myArray.TreeSort();
            print(myArray.Data);
            Console.WriteLine("\nКоличество сравнений: " + srTree);
            Console.WriteLine();

            Console.ReadKey();
        }

        public static int srQuick = 0;
        public static int prQuick = 0;

        public static int srTree = 0;
        public static int prTree = 0;


        public static int partition(int[] array, int start, int end)
        {
            int temp;
            int marker = start;
            for (int i = start; i <= end; i++)
            {
                srQuick++;
                if (array[i] < array[end])
                {
                    prQuick++;
                    temp = array[marker]; 
                    array[marker] = array[i];
                    array[i] = temp;
                    marker += 1;
                }
            }
            prQuick++;
            temp = array[marker];
            array[marker] = array[end];
            array[end] = temp;
            return marker;
        }

        public static void quicksort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = partition(array, start, end);
            quicksort(array, start, pivot - 1);
            quicksort(array, pivot + 1, end);
        }

        public static void Quick(int[] arr)
        {
            srQuick = 0;
            prQuick = 0;
            int[] arrTemp = arr;

            quicksort(arr, 0, 9);
            print(arr);

            Console.WriteLine();
            Console.WriteLine("Количество сравнений: " + srQuick);
            Console.WriteLine("Количество пересылок: " + prQuick);
        }

        public static void print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(" " + arr[i]);
            }
        }
    }

    class MyArray
    {
        public int[] Data { get; set; }

        public MyArray(int[] data)
        {
            Data = data;
        }

        public void TreeSort()
        {
            Tree root = new Tree();
            for (int i = 0; i < Data.Length; i++)
            {
                root.AddToTree(Data[i]);
            }

            Data = root.GetSorted();
        }

        class Tree
        {
            class TreeItem
            {
                public readonly int Value;
                public TreeItem Left;
                public TreeItem Right;

                public TreeItem(int value, TreeItem left = null, TreeItem right = null)
                {
                    Value = value;
                    Left = left;
                    Right = right;
                }
            }
            private TreeItem root;

            private readonly List<int> result = new List<int>();

            public Tree()
            {
                root = null;
            }

            private static void AddToTreeRec(int value, ref TreeItem localRoot)
            {
                if (localRoot == null)
                {
                    localRoot = new TreeItem(value);
                    return;
                }
                Program.srTree++;
                if (localRoot.Value > value)
                {
                    AddToTreeRec(value, ref localRoot.Right);
                }
                else
                {
                    AddToTreeRec(value, ref localRoot.Left);
                }
            }

            public void AddToTree(int value)
            {
                AddToTreeRec(value, ref root);
            }


            private void GetSortedNumRec(TreeItem node)
            {
                if (node != null)
                {
                    GetSortedNumRec(node.Right);
                    result.Add(node.Value);
                    GetSortedNumRec(node.Left);
                }
            }

            public int[] GetSorted()
            {
                GetSortedNumRec(root);
                return result.ToArray();
            }
        }
    }
}

