using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public static class LifeSimulation
    {

        // Function to print next generation
        public static bool PrintNextGeneration(int[,] grid, int X, int Y)
        {
            int[,] future = default;

                 future = new int[Y, X];

            // Loop through every cell
            for (int l = 1; l < Y - 1; l++)
            {
                for (int m = 1; m < X - 1; m++)
                {
                    // finding no Of Neighbours that are alive
                    int aliveNeighbours = 0;
                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                            aliveNeighbours +=
                                    grid[l + i, m + j];

                    // The cell needs to be subtracted
                    // from its neighbours as it was counted before
                    aliveNeighbours -= grid[l, m];

                    // Implementing the Rules of Life

                    // Cell is lonely and dies
                    if ((grid[l, m] == 1) &&
                                (aliveNeighbours < 2))
                        future[l, m] = 0;

                    // Cell dies due to over population
                    else if ((grid[l, m] == 1) &&
                                 (aliveNeighbours > 3))
                        future[l, m] = 0;

                    // A new cell is born
                    else if ((grid[l, m] == 0) &&
                                (aliveNeighbours == 3))
                        future[l, m] = 1;

                    // Remains the same
                    else
                        future[l, m] = grid[l, m];
                }
            }
            Console.WriteLine("Output");
            for (int i = 0; i < Y; i++)
            {
                for (int j = 0; j < X; j++)
                {
                    if (future[i, j] == 0)
                        Console.Write(".");
                    else
                        Console.Write("*");
                }
                Console.WriteLine();
            }
            return true;
        }
        public static bool DisplayGrid(int[,] grid, int X, int Y)
        {
                    Console.WriteLine("Input");
                    for (int i = 0; i < Y; i++)
                    {
                        for (int j = 0; j < X; j++)
                        {
                            if (grid[i, j] == 0)
                                Console.Write(".");
                            else
                                Console.Write("*");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                return true;
        }
    }
}
