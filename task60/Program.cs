// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся 
// двузначных чисел. Напишите программу, которая будет построчно 
// выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

// 1.   Функция получения числа от пользователя с проверкой, что задано число
// 2.   Функция создания трёхмерного массива, заполненного целыми двузначными числами 
// 3.   Функция вывода в консоль трёхмерного массива типа int построчно с индексами элементов
// 4.   Демонстрация работы с выводом в консоль

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
int[,,] GenerateInt3DArray(int mRows, int nColumns, int thirdDimension)
{
    int[,,] array = new int[mRows, nColumns, thirdDimension];
    Random tmp = new Random();
    for (int i = 0; i < mRows; i++)
    {
        for (int j = 0; j < nColumns; j++)
        {
            for (int k = 0; k < thirdDimension; k++)
            {
                array[i, j, k] = tmp.Next(10, 100);      // такой интервал - по условию
            }
        }
    }
    return array;
}

// 3.   Функция вывода в консоль трёхмерного массива типа int построчно с индексами элементов 
void PrintInt3DArrayWithIndexes(int[,,] array)
{
    for (int k = 0; k < array.GetLength(0); k++)
    {
        for (int i = 0; i < array.GetLength(1); i++)
        {
            for (int j = 0; j < array.GetLength(2); j++)
            {
                System.Console.Write(array[i, j, k] + $"({i}, {j}, {k}) ");
            }
            System.Console.WriteLine("");
        }
    }
}

// 4.   Демонстрация работы с выводом в консоль
System.Console.WriteLine("Программа создаёт двумерный массив с размерами M x N х K, введёнными " +
                         "пользователем и заполняет его случайными целыми двузначными числами." +
                         " Затем будут выведены все элементы с индексами.");
System.Console.Write("Введите размер M:  ");
int mRows = getNumberFromUserWithCheck();
System.Console.Write("Введите размер N:  ");
int nColumns = getNumberFromUserWithCheck();
System.Console.Write("Введите размер K:  ");
int thirdDimension = getNumberFromUserWithCheck();
int[,,] array = GenerateInt3DArray(mRows, nColumns, thirdDimension);
System.Console.WriteLine($"Создан массив: {mRows} строк, {nColumns} столбцов, {thirdDimension} слоёв");
PrintInt3DArrayWithIndexes(array);




