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
        }

        public int GetCellValue()
        {
            return cell;
        }

        public void SetCellValue(int newValue)
        {
            cell = newValue;
        }

        public bool IsRevealed()
        {
            return revealed;
        }

        public void SetRevealed()
        {
            revealed = true;
        }
        public void SetNeighbors(int count)
        {
            neighbors = count;
        }

        public int GetNeighbors()
        {
            return neighbors;
        }

        public void SetBomb()
        {
            isBomb = true;
        }

        public bool CheckBomb()
        {
            return isBomb;
        }
    }
}
