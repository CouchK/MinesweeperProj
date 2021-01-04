using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Board
    {
        private const int SIZE = 5;
        private String bomb = "bomb";
        private String[,] board;

        public Board()
        {
            createBoard();
        }

        public void createBoard()
        {
            board = new String[SIZE, SIZE];

            Random rand = new Random();
            int randNum = 0;

            //Fill board
            for(int x = 0; x < SIZE; ++x)
            {
                for(int y = 0; y < SIZE; ++y)
                {
                    randNum = rand.Next(4);

                    if (randNum == 0) board[x, y] = bomb;
                    else board[x, y] = randNum.ToString();
                }
            }
        }

        public String[,] getBoard()
        {
            return board;
        }

        public int getSize()
        {
            return SIZE;
        }

        public Boolean checkIfBomb()
        {
            return false;
        }
    }
}
