namespace Minesweeper
{
    class Cell
    {
        private int neighbors;
        private bool revealed;
        private bool isBomb;

        public Cell()
        {
            neighbors = 0;
            revealed = false;
            isBomb = false;
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
