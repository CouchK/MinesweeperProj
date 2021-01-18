using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper
{
    class Cell
    {
        private int neighbors;
        private bool revealed;
        private int cell;
        private const int MAX_BOMBS = 10;
        private int totalBombs;

        public Cell()
        {
            totalBombs = 0;
            cell = 0;

            createCell();
        }

        public void createCell()
        {
            //Get rand num
            Random rand = new Random();
            int randNum = rand.Next(5);

            if (randNum == 5)
            {
                if (totalBombs < MAX_BOMBS)
                {
                    cell = 99;
                    totalBombs++;
                }
            }
            else
            {
                cell = randNum;
            }

            revealed = false;
        }

      /*  public void createCells()
        {
            //Get rand num
            Random rand = new Random();
            int randNum = rand.Next(4);

            int currentBombs = 0;
            int totalBombs = 10;

            cells = new int[SIZE, SIZE];

            for (int x = 0; x < SIZE; ++x)
            {
                for (int y = 0; y < SIZE; ++y)
                {
                    if (randNum == 0)
                    {
                        /*if(currentBombs < totalBombs)
                        {
                            cells[x, y] = ;
                        }
                        cells[x, y] = 99;
                    }
                    else
                    {
                        cells[x, y] = randNum;
                    }
                    randNum = rand.Next(4);
                }
            }
        }*/

        public int getCellValue()
        {
            return cell;
        }

        public bool isRevealed()
        {
            return revealed;
        }

        public void setRevealed()
        {
            revealed = true;
        }

        public void setNeighbors(int amnt)
        {
            neighbors = amnt;
        }
    }
}
