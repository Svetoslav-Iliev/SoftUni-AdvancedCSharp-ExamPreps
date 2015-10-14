using System;

class TargetPractice
{
    static void Main()
    {
        string[] dimensions = Console.ReadLine().Split();

        int numberOfRows = int.Parse(dimensions[0]);
        int numberOfColumns = int.Parse(dimensions[1]);

        char[,] matrix = new char[numberOfRows,numberOfColumns];

        string snake = Console.ReadLine();

        FillSnakeMatrix(numberOfRows, numberOfColumns, snake, matrix);
        
        string[] shotArguments = Console.ReadLine().Split();
        int inpactRow=int.Parse(shotArguments[0]);
        int inpactCol=int.Parse(shotArguments[1]);
        int inpactRadius=int.Parse(shotArguments[2]);

        FireAShot(matrix, inpactRow, inpactCol, inpactRadius);
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            RunGravity(matrix, col);
        }

        PrintMatrix(matrix);
    }

    private static void FireAShot(char[,] matrix, int inpactRow, int inpactCol, int inpactRadius)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if ((col - inpactCol) * (col - inpactCol)+(row-inpactRow)*(row-inpactRow)<= inpactRadius*inpactRadius)
                {
                    matrix[row, col] = ' ';
                }
            }
        }
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0}",matrix[row,col]);
            }
            Console.WriteLine();
        }
    }
    private static void FillSnakeMatrix(int numberOfRows, int numberOfColumns, string snake, char[,] matrix)
    {
        bool isMovingLeft = true;
        int currentIndex = 0;

        for (int row = numberOfRows - 1; row >= 0; row--)
        {
            if (isMovingLeft)
            {
                for (int col = numberOfColumns - 1; col >= 0; col--)
                {
                    if (currentIndex >= snake.Length)
                    {
                        currentIndex = 0;
                    }

                    matrix[row, col] = snake[currentIndex];
                    currentIndex++;
                }
            }
            else
            {
                for (int col = 0; col < numberOfColumns; col++)
                {
                    if (currentIndex >= snake.Length)
                    {
                        currentIndex = 0;
                    }

                    matrix[row, col] = snake[currentIndex];
                    currentIndex++;
                }
            }
            isMovingLeft = !isMovingLeft;
        }
    }

    static void RunGravity(char[,] matrix, int col)
    {
        while (true)
        {
            bool hasFallen = false;
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                char topChar = matrix[row - 1, col];
                char currentChar = matrix[row, col];
                if (currentChar == ' ' && topChar != ' ')
                {
                    matrix[row, col] = topChar;
                    matrix[row - 1, col] = ' ';
                    hasFallen = true;
                }
            }

            if (!hasFallen)
            {
                break;
            }
        }

    }
}

