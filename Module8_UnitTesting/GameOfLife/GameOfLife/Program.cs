using System;

namespace GameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initializing the grid.
            int[,] grid =
            {
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 1, 0, 0, 0},
                { 0, 0, 0, 1, 1, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0}
            };
            //GameOfLifeInitializer gameOfLife = new();
            try
            {
                LifeSimulation.DisplayGrid(grid, 8, 4);
                LifeSimulation.PrintNextGeneration(grid, 8, 4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
