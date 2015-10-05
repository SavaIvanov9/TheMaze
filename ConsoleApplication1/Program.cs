using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMaze
{
    class Program
    {

        static void Main(string[] args)
        {

            char[,] mazeMatrix =
            {
                { '#','#','#','#','#','#','#','#','#','#' },
                { 'O',' ','#',' ',' ',' ','#',' ',' ','#' },
                { '#',' ','#',' ','#',' ','#','#',' ','#' },
                { '#',' ',' ',' ','#',' ',' ',' ',' ','#' },
                { '#','#','#',' ','#','#','#','#',' ','#' },
                { '#',' ',' ',' ',' ','#',' ',' ',' ','#' },
                { '#',' ','#','#',' ','#',' ','#',' ','#' },
                { '#',' ','#',' ',' ','#',' ','#','#','#' },
                { '#',' ','#',' ','#','#',' ',' ',' ',' ' },
                { '#','#','#','#','#','#','#','#','#','#' },                
            };

            printMaze(mazeMatrix);

            // Console settings
            Console.CursorVisible = false;

            // Set Start
            int currentCol = 0;
            int currentRow = 1;
            char currentPlace = mazeMatrix[currentRow, currentCol];

            while (true)
            {
                // Move current place
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                    while (Console.KeyAvailable) { Console.ReadKey(true); }
                    if (keyPressed.Key == ConsoleKey.LeftArrow)
                    {
                        if ((currentCol >= 1) &&
                            (mazeMatrix[currentRow, currentCol - 1] != '#'))
                        {
                            char previousPosition = currentPlace;
                            mazeMatrix[currentRow, currentCol] = ' ';
                            mazeMatrix[currentRow, currentCol - 1] = previousPosition;
                            currentCol--;
                            Console.Clear();
                            printMaze(mazeMatrix);
                        }

                    }
                    if (keyPressed.Key == ConsoleKey.RightArrow)
                    {
                        if (((currentCol + 1) < mazeMatrix.GetLength(1)) &&
                            (mazeMatrix[currentRow, currentCol + 1] != '#'))
                        {
                            char previousPosition = currentPlace;
                            mazeMatrix[currentRow, currentCol] = ' ';
                            mazeMatrix[currentRow, currentCol + 1] = previousPosition;
                            currentCol++;
                            Console.Clear();
                            printMaze(mazeMatrix);
                        }

                    }
                    if (keyPressed.Key == ConsoleKey.DownArrow)
                    {
                        if ((mazeMatrix[currentRow + 1, currentCol] != '#') &&
                            (currentRow + 1) < mazeMatrix.GetLength(0))
                        {
                            char previousPosition = currentPlace;
                            mazeMatrix[currentRow, currentCol] = ' ';
                            mazeMatrix[currentRow + 1, currentCol] = previousPosition;
                            currentRow++;
                            Console.Clear();
                            printMaze(mazeMatrix);
                        }
                    }
                    if (keyPressed.Key == ConsoleKey.UpArrow)
                    {
                        if ((mazeMatrix[currentRow - 1, currentCol] != '#') &&
                            ((currentRow - 1) > 0))
                        {
                            char previousPosition = currentPlace;
                            mazeMatrix[currentRow, currentCol] = ' ';
                            mazeMatrix[currentRow - 1, currentCol] = previousPosition;
                            currentRow--;
                            Console.Clear();
                            printMaze(mazeMatrix);
                        }
                    }
                }
            }


        }
        static void printMaze(char[,] mazeMatrix)
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    Console.Write("{0} ", mazeMatrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}