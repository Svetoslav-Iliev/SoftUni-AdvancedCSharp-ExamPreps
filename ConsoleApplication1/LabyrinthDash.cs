using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class LabyrinthDash
    {
        static void Main()
        {
            string obstacles = "B";
            int[] rowsOfLabirynth = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[][] labyrinth=new char[rowsOfLabirynth[0]][];
            for (int i = 0; i < rowsOfLabirynth.GetLength(0); i++)
            {
                string inputLine = Console.ReadLine();
                labyrinth[i] = inputLine.ToCharArray();
            }
            int lives = 3;
            int movesCounter = 0;
            int row = 0;
            int col = 0;


            string commands = Console.ReadLine();

            foreach (var direction in commands)
            {
                int preciousRow = row;
                int previousCol = col;
                switch (direction)
                {
                    case'L':
                        col--;
                        break;
                    case'R':
                        col++;
                        break;
                    case'D':
                        row++;
                        break;
                    case'U':
                        row--;
                        break;
                }

                if (!IsCellInsideLabirynth(row,col,labyrinth)|| labyrinth[row][col]==' ')
                {
                    Console.WriteLine("won: {0}{1}",row,col);
                    
                    break;
                }
                if (labyrinth[row][col] == '_' || labyrinth[row][col] == '|')
                {
                    Console.WriteLine("Bumped a wall.");
                    row = previousCol;
                    col = previousCol;
                }
                else if (obstacles.Contains(labyrinth[row][col].ToString()))
                {
                    lives--;
                    movesCounter++;
                    Console.WriteLine("Ouch!Live left: {0}",lives);
                    if (lives==0)
                    {
                        Console.WriteLine("No lives left.Game Over!");
                        break;
                    }
                }
                else if (labyrinth[row][col]=='$')
                {
                    lives++;
                    labyrinth[row][col] = '.';
                    movesCounter++;
                    Console.WriteLine("Awesome! Live lesft: {0}",lives);
                }
                else
                {
                    movesCounter++;
                    Console.WriteLine("Made a move!");
                }
            }
            Console.WriteLine("Total moves mage: {0}",movesCounter);
        }

        private static bool IsCellInsideLabirynth (int row, int col, char[][] labirynth)
        {
            bool isRowInside = 0 <= row && row < labirynth.Length;

            if (!isRowInside)
            {
                return false;
            }

            bool isColInRange = 0 <= col && col < labirynth[row].Length;

            return isColInRange;
        }
    }
}
