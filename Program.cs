// Задача 54. Задайте двумерный массив. Напишите программу, которая 
//упорядочит по убыванию элементы каждой строки двумерного массива.
// Задача 56. Задайте прямоугольный двумерный массив. Напишите программу, 
//которая будет находить строку с наименьшей суммой элементов.
// Задача 58. Задайте две матрицы. Напишите программу, 
//которая будет находить произведение двух матриц.
// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных 
//чисел. Напишите программу, которая будет построчно выводить массив, 
//добавляя индексы каждого элемента.
// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.

bool isWork = true;

while(isWork)
{
    Console.WriteLine("Choose task 1, 2, 3, 4 or 5. For exit enter '-1'");

    if (int.TryParse(Console.ReadLine(), out int j))
    {
        switch (j)
        {
            case 1:
            {
                int firstLength = ReadInt("numbers of rows: ");
                int secondLength = ReadInt("numbers of colums: ");
                int[,] array = CreateTwoDementionIntArray(firstLength, secondLength);
                Console.WriteLine("Original array:");
                PrintTwoDementionIntArray(array);
                Console.WriteLine("Sorted array:");
                int [,] sortedArray = SortedTwoDementionIntArray(array);
                PrintTwoDementionIntArray(sortedArray);
                break;
            }

            case 2:
            {
                int firstLength = ReadInt("numbers of rows: ");
                int secondLength = ReadInt("numbers of colums: ");
                int[,] array = CreateTwoDementionIntArray(firstLength, secondLength);
                Console.WriteLine("Entered array:");
                PrintTwoDementionIntArray(array);
                int number = MinSumInLineIntArray(array);
                Console.WriteLine($"Row with minimal sum in array: {number + 1}");
                PrintRowFromArray(array, number);
                break;
            }

            case 3:
            {
                int rowsFirstMatrix = ReadInt("numbers of rows of the first matrix: ");
                int columsFirstRowsSecondMatrix = ReadInt("numbers of colums of the first matrix: ");
                int columsSecondMatrix = ReadInt("numbers of colums of the second matrix: ");
                int[,] firstMatrix = CreateTwoDementionIntArray(rowsFirstMatrix, columsFirstRowsSecondMatrix);
                Console.WriteLine("First matrix:");
                PrintTwoDementionIntArray(firstMatrix);
                int[,] secondMatrix = CreateTwoDementionIntArray(columsFirstRowsSecondMatrix, columsSecondMatrix);
                Console.WriteLine("Second matrix:");
                PrintTwoDementionIntArray(secondMatrix);
                int[,] resultMatrix = MultiplicationArray(firstMatrix, secondMatrix);
                Console.WriteLine("Multiplication of matrices:");
                PrintTwoDementionIntArray(resultMatrix);
                break;
            }

            case 4:
            {
                int[,,] array = CreateThreeDementionIntArray(2, 2, 2); //Максимальный размер массива (6, 5, 3)
                Console.WriteLine("Entered array:");
                PrintThreeDementionIntArray(array);
                break;
            }

            case 5:
            {
                int[,] array = CreateTwoDementionSpiralArray();
                Console.WriteLine("Entered array:");
                PrintTwoDementionIntArray(array);
                break;
            }

            case -1: isWork = false; break;
        }
    }
}

int ReadInt(string argument)
{
    Console.Write($"Input {argument}");
    int result = 0;

    while (!int.TryParse(Console.ReadLine(), out result))
    {
        Console.WriteLine("Try again");
    }

    return result;
}

int[,] SortedTwoDementionIntArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 1; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1) - j; k++)
            {
                if (array[i, k] > array[i, k + 1])
                {
                    int temp = array[i, k];
                    array[i, k] = array[i, k + 1];
                    array[i, k + 1] = temp;
                }
            }
        }
    }

    return array;
}

void PrintTwoDementionIntArray(int[,] array)
{
    for (int row = 0; row < array.GetLength(0); row++)
    {
        for (int colum = 0; colum < array.GetLength(1); colum++)
        {
            Console.Write($"{array[row, colum]} ");
        }

        Console.WriteLine();   
    }
}

void PrintRowFromArray(int[,] array, int number)
{
    for (int j = 0; j < array.GetLength(1); j++)
    {
        Console.Write($"{array[number, j]} ");
    }
    Console.WriteLine();
}

void PrintThreeDementionIntArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.WriteLine($"[{i}, {j}, {k}] = {array[i, j, k]} ");
            }
        } 
    }
}

int[,] CreateTwoDementionIntArray(int firstLength, int secondLength)
{
    int[,] result = new int[firstLength, secondLength];
    Random rnd = new Random();

    for (int row = 0; row < result.GetLength(0); row++)
    {
        for (int colum = 0; colum < result.GetLength(1); colum++)
        {
            result[row, colum] = rnd.Next(0, 9);
        }
    }

    return result;
}

int MinSumInLineIntArray(int[,] array)
{
    int number = 0;
    int sum = 0;
    int min = 0;

    for (int k = 0; k < array.GetLength(1); k++)
    {
        min = min + array[0, k]; 
    }

    for (int i = 1; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum = sum + array[i, j];
        }
        
        if (sum < min)
        {
            number = i;
            min = sum;
        }

        sum = 0;
    }

    return number;
}

int[,] MultiplicationArray(int[,] firstMatrix, int[,] secondMatrix)
{
    int[,] result = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];

    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            for (int k = 0; k < firstMatrix.GetLength(1); k++)
            {
                result[i, j] = result[i, j] + firstMatrix[i, k] * secondMatrix[k, j];
            }
        }
    }

    return result;
}

int[,,] CreateThreeDementionIntArray(int firstLength, int secondLength, int thirdLength)
{
    int[,,] result = new int[firstLength, secondLength, thirdLength];
    Random rnd = new Random();
    int minNumberRandom = 10;
    int maxNumberRandom = 20;
    int count = 1;

    while(count > 0)
    {
        count = 0;

        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                for (int k = 0; k < result.GetLength(2); k++)
                {
                    result[i, j, k] = rnd.Next(minNumberRandom, maxNumberRandom);

                    for (int ii = 0; ii < result.GetLength(0); ii++)
                    {
                        for (int jj = 0; jj < result.GetLength(1); jj++)
                        {
                            for (int kk = 0; kk < result.GetLength(2); kk++)
                            {
                                if ((i != ii | j != jj | k != kk) 
                                && result[i,j,k] == result[ii,jj,kk]) 
                                {
                                    result[ii, jj, kk] 
                                    = rnd.Next(minNumberRandom, maxNumberRandom);
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    return result;
}

int[,] CreateTwoDementionSpiralArray()
{
    int[,] result = new int[4, 4];
    int i = 0;
    int j = 0;
    int number = 10;

    for (j = 0; j < result.GetLength(1); j++)
    {
        result[i, j] = number;
        number++;
    }

    for (i = 0; i < result.GetLength(0); i++)
    {
        result[i, j-1] = number-1;
        number++;
    }

    for (j = result.GetLength(1)-1; j >= 0; j--)
    {
        result[i-1, j] = number-2;
        number++;
    }
    
    for (i = result.GetLength(0)-1; i > 0; i--)
    {
        result[i, j+1] = number-3;
        number++;
    }

    for (j = 1; j < result.GetLength(1)-1; j++)
    {
        result[i+1, j] = number-3;
        number++;
    }

    for (j = result.GetLength(0)-2; j > 0; j--)
    {
        result[i+2, j] = number-3;
        number++;
    }

    return result;
}