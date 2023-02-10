// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

// 1.   Функция проверки, что задано число
// 2.   Функция заполнения двумерного массива по спирали
// 3.   Функция вывода в консоль двумерного массива типа int
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

// 2.   Функция заполнения двумерного массива по спирали
int[,] SpiralFill2DArray(int mRows, int nColumns)
{
    int[,] array = new int[mRows, nColumns];
    int fillCount = 0;
    int i = 0; // индекс строки
    int j = 0; // индекс столбца
    int k = 0; // количество кругов
    int l = array.GetLength(0); // длина строки
    int h = array.GetLength(1); // высота столбца

    while(fillCount < array.GetLength(0) * array.GetLength(1)) {
        
        // заполнение строки вправо
        for(; j < l; j++) array[i, j] = ++fillCount;
        
        i++; j--; // сдвигаем позицию для дальнейшего продвижения

        // заполнение столбца вниз
        for( ; i < h; i++) array[i, j] = ++fillCount;

        i--; j--; // сдвигаем позицию для дальнейшего продвижения

        // заполнение строки влево
        for( ; j > -1 + k; j--) array[i, j] = ++fillCount;

        j++; i--; // сдвигаем позицию для дальнейшего продвижения

        // заполнение столбца вверх
        for( ; i > 0 + k; i--) array[i, j] = ++fillCount;

        i++; j++; l--; h--; k++; // сужаем массив, сдвигаем позицию внутрь
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

// 4.   Демонстрация работы с выводом в консоль
System.Console.WriteLine("Программа создаёт двумерный массив с размерами M x M, введёнными " +
                         "пользователем и заполняет его по спирали." +
                         " Затем будет выведен сформированный массив.");
System.Console.Write("Введите размер M:  ");
int mRows = getNumberFromUserWithCheck();
int nColumns = mRows;
int[,] array = SpiralFill2DArray(mRows, nColumns);
System.Console.WriteLine($"Создан массив: {mRows} строк, {nColumns} столбцов");
PrintIntTwoDimArray(array);



