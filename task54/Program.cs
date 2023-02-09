// Задача 54: Задайте двумерный массив. Напишите программу, 
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

// 1.   Функция проверки, что задано число
// 2.   Функция создания двумерного массива, заполненного целыми числами
// 3.   Функция вывода в консоль двумерного массива типа int
// 4.   Функция упорядочивания элементов каждой строки по убыванию
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

// 4.   Функция упорядочивания элементов каждой строки по убыванию
int[,] DescendingSortEachRow(int[,] array)
{
    int tmp = 0;
    // проходим по всем строкам k - индекс строки
    for (int k = 0; k < array.GetLength(0); k++)
    {
        // сортировка пузырьком каждой строки, i - индекс элемента в k-й строке
        for(int i = 0; i < array.GetLength(1)-1; i++) {
            for(int j = i; j < array.GetLength(1); j++){
                if(array[k, i] <= array[k, j]) {
                    tmp = array[k, i];
                    array[k, i] = array[k, j];
                    array[k, j] = tmp;
                }
            }
        }
    }
    return array;

    
}

// 5.   Демонстрация работы с выводом в консоль
System.Console.WriteLine("Программа создаёт двумерный массив с размерами M x N, введёнными " +
                         "пользователем и заполняет его случайными целыми числами." +
                         " Затем элементы каждой строки будут отсортированы по убыванию.");
System.Console.Write("Введите размер M:  ");
int mRows = getNumberFromUserWithCheck();
System.Console.Write("Введите размер N:  ");
int nColumns = getNumberFromUserWithCheck();
int[,] array = GenerateIntTwoDimArray(mRows, nColumns);
System.Console.WriteLine($"Создан массив: {mRows} строк, {nColumns} столбцов");
PrintIntTwoDimArray(array);
System.Console.WriteLine("Элементы каждой строки отсортированы по убыванию: ");
DescendingSortEachRow(array);
PrintIntTwoDimArray(array);

