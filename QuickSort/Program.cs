using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        public static void QuickSort(int[] array, int lowBound, int highBound)
        {
            int first = lowBound;
            int last = highBound;
            int mid = array[(first + last) / 2];
            var pivot = array[highBound];
            for(int i = lowBound;i<highBound;i++)
            {
                if (array[i] < pivot)
                {
                    Swap(array, i, first);
                    first++;
                }
            }
            Swap(array, first, last);
            if (first > lowBound) QuickSort(array, lowBound, first-1);
            if (first < highBound) QuickSort(array, first+1, highBound);
        }

        public static void QuickSort(int[] array)
        {
            if (array.Length == 0) return;
            QuickSort(array, 0, array.Length - 1);
        }

        public static void Swap(int[] array, int i,int j)
        {
            int temp;
            temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        static void Main(string[] args)
        {
            TestSimpleMassive();
            TestSame100Elements();
            Test1000RandomElements();
            TestEmptyArray();
            TestHugeMassive();

            Console.ReadKey();
        }

        public static void TestSimpleMassive()
        {   //Сортировка массива из трёх элементов
            int[] simpleNumbers = new[] {3,2,1};

            QuickSort(simpleNumbers);

            if (simpleNumbers[2] >= simpleNumbers[1] && simpleNumbers[1] >= simpleNumbers[0])
                Console.WriteLine("Сортировка массива из 3х чисел работает корректно");
            else
                Console.WriteLine("! Сортировка массива из 3х чисел сработала не корректно при перестановке элементов одной из пар значений");
        }

        public static void TestSame100Elements()
        { //Тестирование сортировки массива из 100 одинаковых элементов
            int[] sameNumbers = new int[100];
            int unsorted = -1;

            for(int i =0;i<sameNumbers.Length;i++)
                sameNumbers[i] = 1;
            QuickSort(sameNumbers);

            for (int i = 0; i < sameNumbers.Length - 1; i++)
            {
                if (sameNumbers[i] > sameNumbers[i + 1])
                {
                    unsorted = i;
                    break;
                }
            }

            if (unsorted == -1)
                Console.WriteLine("Сортировка массива из 100 одинаковых значений работает корректно");
            else
                Console.WriteLine("! Сортировка массива из 100 одинаковых значений не сработала при перестановке элементов одной из пар значений: {0} > {1}", sameNumbers[unsorted],sameNumbers[unsorted+1]);
        }

        public static void Test1000RandomElements()
        { //Тестирование сортировки в массиве из 1000 случайных элементов
            var rnd = new Random();
            int size = 1000;
            int[] thousandNumbers = new int[size];
            int unsorted = -1;

            for (int i = 0; i < size; i++)
                thousandNumbers[i] = rnd.Next(0, 1000);
            QuickSort(thousandNumbers);

            for (int i = 0; i < 10; i++)
            {
                int position = rnd.Next(0, 999);
                if (thousandNumbers[position] > thousandNumbers[position + 1])
                {
                    unsorted = position;
                    break;
                }
            }

            if (unsorted == -1)
                Console.WriteLine("Сортировка массива из 1000 случайных значений работает корректно");
            else
                Console.WriteLine("! Сортировка массива из 1000 случайных значений не сработала при перестановке элементов одной из пар значений: {0} > {1}", thousandNumbers[unsorted], thousandNumbers[unsorted + 1]);
        }

        private static void TestEmptyArray()
        { //Тестирование сортировки в пустом массиве (содержащем 0 элементов)
            int[] emptyArray = new int[0];

            QuickSort(emptyArray);

            if (emptyArray.Length == 0)
                Console.WriteLine("Сортировка пустого массива работает корректно");
            else
                Console.WriteLine("!Сортировка пустого массива изменила пустой массив");
        }

        public static void TestHugeMassive()
        { //Тестирование сортировки в массиве из 100 000 000 случайных элементов
            var rnd = new Random();
            int size = 100000000;
            int[] thousandNumbers = new int[size];
            int unsorted = -1;

            for (int i = 0; i < size; i++)
                thousandNumbers[i] = rnd.Next(0, 100000000);
            QuickSort(thousandNumbers);

            for (int i = 0; i < 10; i++)
            {
                int position = rnd.Next(0, 100000000);
                if (thousandNumbers[position] > thousandNumbers[position + 1])
                {
                    unsorted = position;
                    break;
                }
            }

            if (unsorted == -1)
                Console.WriteLine("Сортировка массива из 100000000 случайных значений работает корректно");
            else
                Console.WriteLine("! Сортировка массива из 100000000 случайных значений не сработала при перестановке элементов одной из пар значений: {0} > {1}", thousandNumbers[unsorted], thousandNumbers[unsorted + 1]);
        }
    }
}
