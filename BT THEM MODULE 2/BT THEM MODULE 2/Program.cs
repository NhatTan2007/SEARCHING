using System;
using System.Text;

namespace BT_THEM_MODULE_2
{
    class Program
    {
        static bool isSorted = false;
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            bool checkInput = false;
            int yourChoice;
            int[] sampleArray = new int[0];
            while (true)
            {
                Menu();
                do
                {
                    Console.Write("Please enter your choice: ");
                    checkInput = int.TryParse(Console.ReadLine(), out yourChoice);
                } while (!checkInput || yourChoice <= 0 || yourChoice > 6);
                switch (yourChoice)
                {
                    case 1:
                        int size;
                        
                        do
                        {
                            Console.Write("Please enter size of new Array: ");
                            checkInput = int.TryParse(Console.ReadLine(), out size);
                        } while (!checkInput || size <= 0);
                        sampleArray = CreateArray(size);
                        break;
                    case 2:
                        if (IsSymmetryArray(sampleArray)) Console.WriteLine("Array is Symmetry");
                        else Console.WriteLine("Array is not Symmetry");
                        break;
                    case 3:
                        SelectionSort(sampleArray);
                        break;
                    case 4:
                        int numberToFind;
                        int indexNumberToFind;
                        if (isSorted)
                        {
                            do
                            {
                                Console.Write("Please enter number you want to find: ");
                                checkInput = int.TryParse(Console.ReadLine(), out numberToFind);
                            } while (!checkInput);
                            indexNumberToFind = FindKDQ(numberToFind, sampleArray);
                            if (indexNumberToFind != -1)
                            {
                                Console.WriteLine($"{numberToFind} is exists at index position {indexNumberToFind} of Array");
                            }
                            else Console.WriteLine($"{numberToFind} is not exists in Array");
                        }
                        else if (sampleArray.Length == 0) Console.WriteLine("Array is empty");
                        else Console.WriteLine("Please sorting array first");
                        break;
                    case 5:
                        if (sampleArray.Length > 0) Console.WriteLine($"Array: {DisplayArray(sampleArray)}");
                        else Console.WriteLine("Array is empty");
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("---------------------------");
            //Console.WriteLine("MARKS MANAGEMENT SYSTEM\n");
            Console.WriteLine("Please select an option\n");
            Console.WriteLine("1. Create a new array");
            Console.WriteLine("2. Check Symmetry Array?");
            Console.WriteLine("3. Sorting array");
            Console.WriteLine("4. Searching in array");
            Console.WriteLine("5. Display array");
            Console.WriteLine("6. Exit");
        }

        static string FormatName(string nameInput)
        {
            //Remove space;
            while (nameInput.IndexOf("  ") != -1)
            {
                nameInput = nameInput.Replace("  ", " ");
            }
            //make Upercase first char each word.
            nameInput = nameInput.ToLower();
            string[] nameSplitArray = nameInput.Split(" ");
            for (int i = 0; i < nameSplitArray.Length; i++)
            {
                char[] stringSplitToChar = nameSplitArray[i].ToCharArray();
                stringSplitToChar[0] = Char.ToUpper(stringSplitToChar[0]);
                nameSplitArray[i] = new string(stringSplitToChar);
            }
            nameInput = String.Join(" ", nameSplitArray);
            return nameInput;
        }

        static int[] CreateArray(int size)
        {
            Random randomNumber = new Random();
            int[] randomNumberArray = new int[size];
            for (int i = 0; i < randomNumberArray.Length; i++)
            {
                randomNumberArray[i] = randomNumber.Next(30, 61);
            }
            return randomNumberArray;
        }

        static bool IsSymmetryArray(int[] arrayInput)
        {
            if (arrayInput.Length > 0)
            {
                for (int i = 0, j = arrayInput.Length - 1; i < arrayInput.Length; i++, j--)
                {
                    if (arrayInput[i] != arrayInput[j]) return false;
                }
                return true;
            }
            else throw new Exception("Array is empty");
        }

        static int[] SelectionSort(int[] arrayInput)
        {
            if (arrayInput.Length > 0)
            {
                for (int i = 0; i < arrayInput.Length; i++)
                {
                    int minNumber = arrayInput[i];
                    int minIndex = i;
                    for (int j = i; j < arrayInput.Length; j++)
                    {
                        if (arrayInput[j] < minNumber)
                        {
                            minNumber = arrayInput[j];
                            minIndex = j;
                        }
                    }
                    if (minIndex != i)
                    {
                        int temp = arrayInput[i];
                        arrayInput[i] = arrayInput[minIndex];
                        arrayInput[minIndex] = temp;
                    }
                }
                isSorted = true;
                return arrayInput;
            }
            else throw new Exception("Array is empty");
        }

        //static int AverageNumberOfArray(int[] arrayInput)
        //{
        //    int sumArray = 0;
        //    for (int i = 0; i < arrayInput.Length; i++)
        //    {
        //        sumArray += arrayInput[i];
        //    }
        //    return sumArray / arrayInput.Length;
        //}

        static int FindKDQ(int numberToSearch, int[] arrayInput)
        {
            int startIndex = 0;
            int endIndex = arrayInput.Length - 1;
            int keyIndex = (startIndex + endIndex) / 2;
            while (arrayInput[keyIndex] != numberToSearch && startIndex <= endIndex )
            {
                if (arrayInput[keyIndex] < numberToSearch) startIndex = keyIndex + 1;
                else endIndex = keyIndex - 1;
                keyIndex = (startIndex + endIndex) / 2;
            }
            if (arrayInput[keyIndex] == numberToSearch) return keyIndex;
            return -1;
        }

        static int Find(int numberToSearch, int start, int end, int[] arrayInput)
        {
            int keyIndex = (start + end) / 2;
            if (start <= end)
            {
                if (arrayInput[keyIndex] == numberToSearch)
                {
                    return keyIndex;
                }
                if (arrayInput[keyIndex] > numberToSearch)
                {
                    return Find(numberToSearch, start, keyIndex - 1, arrayInput);
                }
                if (arrayInput[keyIndex] < numberToSearch)
                {
                    return Find(numberToSearch, keyIndex + 1, end, arrayInput);
                }
            }
            return -1;
        }

        static string DisplayArray(int[] inputArray)
        {
            string resultPrint = "";
            for (int i = 0; i < inputArray.Length; i++)
            {
                resultPrint += $"{inputArray[i]} ";
            }
            return resultPrint;
        }
    }
}
