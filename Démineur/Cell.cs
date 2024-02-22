namespace Démineur
{
    public class Cell(bool isMined)
    {
        public bool IsMined { get; } = isMined;
        public bool IsFlagged { get; set; }
        public bool IsRevealed { get; set; }
        public int NeighbourMines { get; set; }
        public (int,int) Position { get; set; }

        public void Reveal()
        {
            IsRevealed = true;
        }
    }
}
