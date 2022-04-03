using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class BusinessLogic
    {
        private const int SIZE = 8;

        bool CanPlace(int[][] board, int row, int rank)
        {
            //row to the left
            for (int i = 0; i < rank; i++)
            {
                if (board[row][i] == 1) return false;
            }

            //lower left diagonal
            for (int i = row, j = rank; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i][j] == 1) return false;
            }

            //upper left diagonal
            for (int i = row, j = rank; i < SIZE && j >= 0; i++, j--)
            {
                if (board[i][j] == 1) return false;
            }

            return true;
        }

        bool Solve(int[][] board, int rank)
        {
            if (rank >= SIZE) return true;
            for (int row = 0; row < SIZE; row++)
            {
                if (CanPlace(board, row, rank))
                {
                    board[row][rank] = 1;
                    if (Solve(board, rank + 1)) return true;
                    board[row][rank] = 0; //Backtrack
                }
            }

            return false;
        }
    }
}
