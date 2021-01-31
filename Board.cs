using System;

namespace Minesweeper
{
    class Board
    {
        private Cell[,] board;
        private const int SIZE = 10;

        public Board()
        {
            board = new Cell[SIZE+2, SIZE+2];
            CreateBoard();
            SetBombs();
            CalcNeighbors();
        }

        public void CreateBoard()
        {
            for (int x = 0; x < SIZE+2; ++x)
            {
                for (int y = 0; y < SIZE+2; ++y)
                {
                    board[x, y] = new Cell();
                }
            }     
        }

        public void SetBombs()
        {
            Random rand = new Random();
            int randX = rand.Next(1,9);
            int randY = rand.Next(1,9);

            for(int x = 0; x < 10; x++)
            {
                board[randX, randY].SetCellValue(-1);
                board[randX, randY].SetBomb();
                randX = rand.Next(1,9);
                randY = rand.Next(1,9);
            }
        }

        public void CalcNeighbors()
        {
            for(int r = 1; r < SIZE; ++r)
            {
                for(int c = 1; c < SIZE; ++c)
                {
                    int count = 0;
                    if(board[r-1, c-1].CheckBomb())
                    {
                        count++;
                    }
                    if(board[r-1, c].CheckBomb())
                    {
                        count++;
                    }
                    if(board[r-1, c+1].CheckBomb())
                    {
                        count++;
                    }
                    if(board[r, c-1].CheckBomb())
                    {
                        count++;
                    }
                    if(board[r, c+1].CheckBomb())
                    {
                        count++;
                    }
                    if(board[r+1, c-1].CheckBomb())
                    {
                        count++;
                    }
                    if(board[r+1, c].CheckBomb())
                    {
                        count++;
                    }
                    if(board[r+1, c+1].CheckBomb())
                    {
                        count++;
                    }
                    board[r, c].SetNeighbors(count);
                }
            }
        }

        public int GetNeighbors(int x, int y)
        {
            return board[x, y].GetNeighbors();
        }

        public int GetBoardSize()
        {
            return SIZE;
        }

        public bool IsRevealed(int x, int y)
        {
            if (board[x, y].IsRevealed())
                return true;
            else
                return false;
        }

        public void SetRevealed(int x, int y)
        {
            board[x, y].SetRevealed();
        }

        public int GetCellValue(int x, int y)
        {
            return board[x, y].GetCellValue();
        }

        public bool isBomb(int x, int y)
        {
            return board[x, y].CheckBomb();
        }
    }
}
