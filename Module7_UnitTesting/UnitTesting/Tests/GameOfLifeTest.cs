using NUnit.Framework;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    internal class GameOfLifeTest
    {
        public static IEnumerable<TestCaseData> TestCaseSourceDataNegativeX()
        {
            yield return new TestCaseData(new int[,] {
                 { 0, 0, 0, 0, 0, 0, 0, 0},
                 { 0, 0, 0, 0, 1, 0, 0, 0},
                 { 0, 0, 0, 1, 1, 0, 0, 0},
                 { 0, 0, 0, 0, 0, 0, 0, 0}
            }, -1, 1);
        }
        public static IEnumerable<TestCaseData> TestCaseSourceDataNegativeY()
        {
            yield return new TestCaseData(new int[,] {
                 { 0, 0, 0, 0, 0, 0, 0, 0},
                 { 0, 0, 0, 0, 1, 0, 0, 0},
                 { 0, 0, 0, 1, 1, 0, 0, 0},
                 { 0, 0, 0, 0, 0, 0, 0, 0}
            }, 1, -1);
        }
        public static IEnumerable<TestCaseData> TestCaseSourceData4x7Grid()
        {
            yield return new TestCaseData(new int[,] {
                 { 0, 0, 0, 0, 0, 0, 0},
                 { 0, 0, 0, 0, 1, 0, 0},
                 { 0, 0, 0, 1, 1, 0, 0},
                 { 0, 0, 0, 0, 0, 0, 0}
            }, 8, 4);
        }
        public static IEnumerable<TestCaseData> TestCaseSourceDataValidParameters()
        {
            yield return new TestCaseData(new int[,] {
                 { 0, 0, 0, 0, 0, 0, 0, 0},
                 { 0, 0, 0, 0, 1, 0, 0, 0},
                 { 0, 0, 0, 1, 1, 0, 0, 0},
                 { 0, 0, 0, 0, 0, 0, 0, 0}
            }, 8, 4);
        }
        public static IEnumerable<TestCaseData> TestCaseSourceDataLargeValidParameters()
        {
            yield return new TestCaseData(new int[,] {
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, }
            }, 25, 15);
        }


        [TestCaseSource("TestCaseSourceDataNegativeX")]
        [TestCaseSource("TestCaseSourceDataNegativeY")]
        public void DisplayGrid_NegativeAxis_ThrowsException(int[,] grid, int x, int y)
        {
            Assert.That(() => GameOfLife.LifeSimulation.DisplayGrid(grid, x, y), Throws.InvalidOperationException);
        }

        [TestCaseSource("TestCaseSourceData4x7Grid")]
        public void DisplayGrid_InvalidGrid_ThrowsException(int[,] grid, int x, int y)
        {
            Assert.That(() => GameOfLife.LifeSimulation.DisplayGrid(grid, x, y), Throws.InvalidOperationException);
        }

     

        [TestCaseSource("TestCaseSourceDataValidParameters")]
        [TestCaseSource("TestCaseSourceDataLargeValidParameters")]
        public void DisplayGrid_ValidArguments_ReturnsTrue(int[,] grid, int x, int y)
        {
            var result = GameOfLife.LifeSimulation.DisplayGrid(grid, x, y);

            Assert.True(result);
        }

        [TestCaseSource("TestCaseSourceDataNegativeX")]
        [TestCaseSource("TestCaseSourceDataNegativeY")]
        public void PrintNextGeneration_NegativeAxis_ThrowsException(int[,] grid, int x, int y)
        {
            Assert.That(() => GameOfLife.LifeSimulation.PrintNextGeneration(grid, x, y), Throws.InvalidOperationException);
        }

        [TestCaseSource("TestCaseSourceDataValidParameters")]
        [TestCaseSource("TestCaseSourceDataLargeValidParameters")]
        public void PrintNextGeneration_ValidArguments_ReturnsTrue(int[,] grid, int x, int y)
        {
            var result = GameOfLife.LifeSimulation.PrintNextGeneration(grid, x, y);

            Assert.True(result);
        }

        [TestCaseSource("TestCaseSourceData4x7Grid")]
        public void PrintNextGeneration_InvalidGrid_ThrowsException(int[,] grid, int x, int y)
        {
            Assert.That(() => GameOfLife.LifeSimulation.PrintNextGeneration(grid, x, y), Throws.InvalidOperationException);
        }
    }
}