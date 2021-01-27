using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Board
    {
        private Cell[,] board;
        private const int SIZE = 10;

        public Board()
        {
            board = new Cell[SIZE+2, SIZE+2];
            createBoard();
            setBombs();
            CalcNeighbors();
        }

        public void createBoard()
        {
            for (int x = 0; x < SIZE+2; ++x)
            {
                for (int y = 0; y < SIZE+2; ++y)
                {
                    board[x, y] = new Cell();
                }
            }     
        }
        public int[,] getBoard()
        {
            int[,] intBoard = new int[SIZE, SIZE];

            for (int x = 0; x < SIZE; ++x)
            {
                for (int y = 0; y < SIZE; ++y)
                {
                    intBoard[x, y] = board[x, y].getCellValue();
                }
            }

            return intBoard;
        }


        public void setBombs()
        {
            Random rand = new Random();
            int randX = rand.Next(9);
            int randY = rand.Next(9);

            for(int x = 0; x < 10; x++)
            {
                board[randX, randY].setCellValue(-1);
                board[randX, randY].setBomb();
                randX = rand.Next(9);
                randY = rand.Next(9);
            }
        }

        public void CalcNeighbors()
        {
            for(int x = 1; x < SIZE; ++x)
            {
                for(int y = 1; y < SIZE; ++y)
                {
                    int count = 0;
                    if(board[x-1, y-1].checkBomb())
                    {
                        count++;
                    }
                    if(board[x-1, y].checkBomb())
                    {
                        count++;
                    }
                    if(board[x-1, y+1].checkBomb())
                    {
                        count++;
                    }
                    if(board[x, y-1].checkBomb())
                    {
                        count++;
                    }
                    if(board[x, y+1].checkBomb())
                    {
                        count++;
                    }
                    if(board[x+1, y-1].checkBomb())
                    {
                        count++;
                    }
                    if(board[x+1, y].checkBomb())
                    {
                        count++;
                    }
                    if(board[x+1, y+1].checkBomb())
                    {
                        count++;
                    }
                    board[x, y].setNeighbors(count);
                }
            }
        }

        public int getNeighbors(int x, int y)
        {
            return board[x, y].getNeighbors();
        }

        public int getBoardSize()
        {
            return SIZE;
        }

        public bool isRevealed(string posX, string posY)
        {
            int x = int.Parse(posX);
            int y = int.Parse(posY);
            if (board[x, y].isRevealed())
                return true;
            else
                return false;
        }

        public void setRevealed(string posX, string posY)
        {
            int x = int.Parse(posX);
            int y = int.Parse(posY);
            board[x, y].setRevealed();
        }

        public int getCellValue(int x, int y)
        {
            return board[x, y].getCellValue();
        }
    }
}
