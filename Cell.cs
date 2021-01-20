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
            cell = 0;
            neighbors = 0;

            createCell();
        }

        public void createCell()
        {
            //Get rand num
            Random rand = new Random();
            int randNum = rand.Next(4);

            cell = randNum;

            revealed = false;
        }

        public int getCellValue()
        {
            return cell;
        }

        public void setCellValue(int val)
        {
            cell = val;
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
