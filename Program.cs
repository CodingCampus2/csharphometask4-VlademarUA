using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Task4, char[,]> TaskSolver = task =>
             {
                 // Your solution goes here
                 // You can get all needed inputs from task.[Property]
                 // Good luck!
                 char[,] board = task.Board;
                 int m = board.GetLength(0);
                 int n = board.GetLength(1);
                 char[,] nextBoard = board.Clone() as char[,];

                 for (int i = 0; i < m; i++)
                 {
                     for (int j = 0; j < n; j++)
                     {
                         int aliveNeighbours = IsNeighborAlive(board, i, j, -1, -1) +
                            IsNeighborAlive(board, i, j, -1, 0) +
                            IsNeighborAlive(board, i, j, -1, 1) +
                            IsNeighborAlive(board, i, j, 0, -1) +
                            IsNeighborAlive(board, i, j, 0, 1) +
                            IsNeighborAlive(board, i, j, 1, -1) +
                            IsNeighborAlive(board, i, j, 1, 0) +
                            IsNeighborAlive(board, i, j, 1, 1);
                         nextBoard[i, j] = GetNextIterationValue(board[i, j], aliveNeighbours);
                     }
                 }

                 return nextBoard;
             };

            Task4.CheckSolver(TaskSolver);
        }
        private static int IsNeighborAlive(char[,] board, int x, int y, int offsetx, int offsety)
        {
            int result = 0;
            int targetX = x + offsetx;
            int targetY = y + offsety;
            bool inBounds = targetX >= 0 && targetX < board.GetLength(0) &&
                targetY >= 0 && targetY < board.GetLength(1);
            if (inBounds)
            {
                result = board[targetX, targetY] == '1' ? 1 : 0;
            }

            return result;
        }

        private static char GetNextIterationValue(char cellState, int aliveNeighbours)
        {
            if (cellState == '1')
            {
                if (aliveNeighbours < 2 || aliveNeighbours > 3)
                {
                    return '0';
                }
            }
            else
            {
                if (aliveNeighbours == 3)
                {
                    return '1';
                }
            }
            return cellState;
        }
    }
}


