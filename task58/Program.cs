// Задача 58: Задайте две матрицы. Напишите программу, 
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

// 1.   Функция проверки, что задано число
// 2.   Функция создания двумерного массива, заполненного целыми числами
// 3.   Функция вывода в консоль двумерного массива типа int
// 4.   Функция вычисления произведения матриц
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

// 4.   Функция вычисления произведения матриц
int[,] MultiplyArrays(int[,] array1, int[,] array2)
{
    int[,] result = new int[array1.GetLength(0), array2.GetLength(1)];
    if (array1.GetLength(1) != array2.GetLength(0))
    {
        System.Console.WriteLine("Число столбцов матрицы 1 должно быть равно числу строк матрицы 2");
        return null;
    }

    // проходим по всем строкам i - индекс строки
    for (int i = 0; i < array1.GetLength(0); i++)
    {
        // считаем сумму произведений элементов строки array1 на элементы столбца array2
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            for (int k = 0; k < array1.GetLength(1); k++)
            {
                result[i, j] += array1[i, k] * array2[k, j];
            }
        }
    }
    return result;
}

// 5.   Демонстрация работы с выводом в консоль
System.Console.WriteLine("Программа создаёт 2 двумерных матрицы с размерами M1 x N1 и M2 x N2, введёнными " +
                         "пользователем и заполняет их случайными целыми числами." +
                         " Затем будет выведено произведение этих матриц.");
System.Console.Write("Введите размер M1:  ");
int m1Rows = getNumberFromUserWithCheck();
System.Console.Write("Введите размер N1:  ");
int n1Columns = getNumberFromUserWithCheck();
int[,] array1 = GenerateIntTwoDimArray(m1Rows, n1Columns);
System.Console.Write("Введите размер M2:  ");
int m2Rows = getNumberFromUserWithCheck();
System.Console.Write("Введите размер N2:  ");
int n2Columns = getNumberFromUserWithCheck();
int[,] array2 = GenerateIntTwoDimArray(m2Rows, n2Columns);
System.Console.WriteLine($"Создана матрица 1: {m1Rows} строк, {n1Columns} столбцов");
PrintIntTwoDimArray(array1);
System.Console.WriteLine($"Создана матрица 2: {m2Rows} строк, {n2Columns} столбцов");
PrintIntTwoDimArray(array2);
int[,] multiplicationArray = MultiplyArrays(array1, array2); // для отображения номера, а не индекса
if (multiplicationArray != null) {
    System.Console.WriteLine($"Произведение матриц: ");
    PrintIntTwoDimArray(multiplicationArray);
}