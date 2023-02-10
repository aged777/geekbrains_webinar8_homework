// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт 
// номер строки с наименьшей суммой элементов: 1 строка

// В ответе именно номер строки, не индекс (исходя из примера)

// 1.   Функция проверки, что задано число
// 2.   Функция создания двумерного массива, заполненного целыми числами
// 3.   Функция вывода в консоль двумерного массива типа int
// 4.   Функция нахождения номера строки с наименьшей суммой элементов
// 5.   Демонстрация работы с выводом в консоль

// 1.   Функция получения числа от пользователя с проверкой, что задано число
int getNumberFromUserWithCheck()
{
    int result = 0;
    bool ifNumber = false;

    while (!ifNumber)
    {
        System.Console.WriteLine("Введите число: ");
        int.TryParse(Console.ReadLine(), out result);
        ifNumber = true;
    }

    return result;
}

// 2.   Функция создания двумерного массива, заполненного целыми числами
int[,] GenerateIntTwoDimArray(int mRows, int nColumns)
{
    int[,] array = new int[mRows, nColumns];
    Random tmp = new Random();
    for (int i = 0; i < mRows; i++)
    {
        for (int j = 0; j < nColumns; j++)
        {
            array[i, j] = tmp.Next(1, 9);      // такой интервал - из примера
        }
    }
    return array;
}

// 3.   Функция вывода в консоль двумерного массива типа int
void PrintIntTwoDimArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        System.Console.Write("[ ");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write(array[i, j] + " ");
        }
        System.Console.WriteLine("]");
    }
}

// 4.   Функция нахождения номера строки с наименьшей суммой элементов
int FindNumberOfRowWithTheSmallestSumm(int[,] array)
{
    int result = 0;
    int minSum = 0;
    int sum = 0;
    // проходим по всем строкам k - индекс строки
    for (int k = 0; k < array.GetLength(0); k++) {
        // считаем сумму элементов строки
        for (int i = 0; i < array.GetLength(1); i++) {
                sum += array[k, i];
                if(k == 0 && i == array.GetLength(1) -1) minSum = sum;
        }
        if(minSum >= sum) result = k;
        sum = 0;
    }
    return result;
}

// 5.   Демонстрация работы с выводом в консоль
System.Console.WriteLine("Программа создаёт двумерный массив с размерами M x N, введёнными " +
                         "пользователем и заполняет его случайными целыми числами." +
                         " Затем будет выведен номер строки с наименьшей суммой элементов.");
System.Console.Write("Введите размер M:  ");
int mRows = getNumberFromUserWithCheck();
System.Console.Write("Введите размер N:  ");
int nColumns = getNumberFromUserWithCheck();
int[,] array = GenerateIntTwoDimArray(mRows, nColumns);
System.Console.WriteLine($"Создан массив: {mRows} строк, {nColumns} столбцов");
PrintIntTwoDimArray(array);
int numberOfRow = FindNumberOfRowWithTheSmallestSumm(array) + 1; // для отображения номера, а не индекса
System.Console.WriteLine($"Номер строки с наименьшей суммой элементов: {numberOfRow} строка");
FindNumberOfRowWithTheSmallestSumm(array);