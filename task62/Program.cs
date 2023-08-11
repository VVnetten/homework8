// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

void PrintMassive2D(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j].ToString("D2")} ");
        }
        Console.WriteLine();
    }
}

int[,] CreateSpiralize2D(int rows, int columns)
{
    int[,] array = new int[rows, columns];
    int size = rows * columns;
    int number = 1; 
    int currentRow = 0;
    int currentColumn = 0;
    int currentDirection = 0;
    int[] directions = { 0, 1, 0, -1, 0 }; // вправо, вниз, влево, вверх, вправо

    while (number <= size) // заполняем, пока число не превысит размер массива
    {
        array[currentRow, currentColumn] = number;
        number++;

        // Определяем следующую ячейку в зависимости от текущего направления
        int nextRow = currentRow + directions[currentDirection];
        int nextColumn = currentColumn + directions[currentDirection + 1];

        // Проверяем, достигли ли границы массива или уже заполнили ячейку
        if (nextRow < 0 || nextRow >= rows || nextColumn < 0 ||
            nextColumn >= columns || array[nextRow, nextColumn] != 0)
        {
            // Изменяем направление движения по часовой стрелке
            currentDirection = (currentDirection + 1) % 4;
        }
        currentRow += directions[currentDirection];
        currentColumn += directions[currentDirection + 1];
    }
    return array;
}

int GetSize(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int row = GetSize("Введите количество строк: ");
int col = GetSize("Введите количество столбцов: ");
int[,] massive = CreateSpiralize2D(row, col);
Console.WriteLine("Сгенерирован спирально заполненный массив:");
PrintMassive2D(massive);