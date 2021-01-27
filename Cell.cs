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
        private bool isBomb;

        public Cell()
        {
            cell = 0;
            neighbors = 0;
            revealed = false;
            isBomb = false;

            createCell();
        }

        public void createCell()
        {
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

        public int getNeighbors()
        {
            return neighbors;
        }

        public void setBomb()
        {
            isBomb = true;
        }

        public bool checkBomb()
        {
            return isBomb;
        }
    }
}
