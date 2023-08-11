// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] ProducTwoMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++) // цикл перебирает строки первой матрицы
    {
        for (int j = 0; j < matrix2.GetLength(1); j++) // цикл перебирает столбцы второй матрицы
        {
            for (int k = 0; k < matrix1.GetLength(1); k++) // цикл выполняет суммирование произведений элементов
            {
                result[i, j] += matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    return result;
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

int[,] GetMassive2D(int rows, int columns, int from, int to)
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

int PromptNumber(string text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
}

int rows1 = PromptNumber("Строк в  1-й матрице: ");
int cols1 = PromptNumber("Столбцов в 1-й матрице: ");
int rows2 = PromptNumber(@"Строк в  2-й матрице.
Совпадает с количесвтом столбцов в 1-й матрице: "); 
int cols2 = PromptNumber("Столбцов в 2-й матрице: ");
Console.WriteLine();
if (cols1 != rows2)
{
    Console.WriteLine(@"Количество строк 2-й матрицы должно быть равно количеству столбцов 1-й!
Повторите ввод.");
    return;
}
int[,] mas1 = GetMassive2D(rows1, cols1, 1, 10);
int[,] mas2 = GetMassive2D(rows2, cols2, 1, 10);
int[,] resultMas = ProducTwoMatrix(mas1, mas2);
Console.WriteLine("Первая:");
PrintMassive2D(mas1);
Console.WriteLine();
Console.WriteLine("Вторая ");
PrintMassive2D(mas2);
Console.WriteLine();
PrintMassive2D(resultMas);