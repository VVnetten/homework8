﻿// Задача 54: Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

void SortArrayRowsDescend(int[,] array)
{
    for (int row = 0; row < array.GetLength(0); row++)
    {
        for (int col = 0; col < array.GetLength(1) - 1; col++)
        {
            int colMax = col;
            for (int j = col + 1; j < array.GetLength(1); j++) // просто находим макс значение в оставшемся
            {
                if (array[row, j] > array[row, colMax])
                {
                    colMax = j;
                }
            }
            int temp = array[row, col];
            array[row, col] = array[row, colMax];
            array[row, colMax] = temp;
        }
    }
}

void PrintMassive2D(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int[,] Get2dMassive(int rows, int columns, int from, int to)
{
    int[,] array = new int[rows, columns];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(from, to);
        }
    }
    return array;
}

int GetSize(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int m = GetSize("Введите количество строк: ");
int n = GetSize("Введите количество столбцов: ");
int[,] massive = Get2dMassive(m, n, 10, 100);
PrintMassive2D(massive);
SortArrayRowsDescend(massive);
Console.WriteLine();
PrintMassive2D(massive);