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
            board = new Cell[SIZE, SIZE];
            createBoard();
            setBombs();
            getNeighbors();
        }

        public void createBoard()
        {
            for (int x = 0; x < SIZE; ++x)
            {
                for (int y = 0; y < SIZE; ++y)
                {
                    board[x, y] = new Cell();
                }
            }     
        }

        public void setBombs()
        {
            Random rand = new Random();
            int randX = rand.Next(9);
            int randY = rand.Next(9);

            for(int x = 0; x < 10; x++)
            {
                board[randX, randY].setCellValue(-1);
                randX = rand.Next(9);
                randY = rand.Next(9);
            }
        }

        public void getNeighbors()
        {
            for(int x = 1; x < SIZE-1; ++x)
            {
                for(int y = 1; y < SIZE-1; ++y)
                {
                    int count = 0;
                    if(board[x-1, y-1].getCellValue() == 99)
                    {
                        count++;
                    }
                    if(board[x-1, y].getCellValue() == 99)
                    {
                        count++;
                    }
                    if(board[x-1, y+1].getCellValue() == 99)
                    {
                        count++;
                    }
                    if(board[x, y-1].getCellValue() == 99)
                    {
                        count++;
                    }
                    if(board[x, y+1].getCellValue() == 99)
                    {
                        count++;
                    }
                    if(board[x+1, y-1].getCellValue() == 99)
                    {
                        count++;
                    }
                    if(board[x+1, y].getCellValue() == 99)
                    {
                        count++;
                    }
                    if(board[x+1, y+1].getCellValue() == 99)
                    {
                        count++;
                    }
                    board[x, y].setNeighbors(count);
                }
            }
        }

        public int getBoardSize()
        {
            return SIZE;
        }

        public int[,] getBoard()
        {
            int[,] intBoard = new int[SIZE, SIZE];

            for(int x = 0; x < SIZE; ++x)
            {
                for(int y = 0; y < SIZE; ++y)
                {
                    intBoard[x, y] = board[x, y].getCellValue();
                }
            }

            return intBoard;
        }
    }
}
