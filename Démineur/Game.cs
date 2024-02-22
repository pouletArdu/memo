
namespace Démineur;

public class Game
{
    public Cell[,] Field;
    public int BombLeft => Field.Cast<Cell>().Count(c => c.IsMined && !c.IsFlagged);

    public bool IsGameOver { get; private set;}

    public Game(int size, int bombNumber)
    {
        Field = new Cell[size,size];
        var bombCount = 0;
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (bombCount < bombNumber)
                {
                    Field[i, j] = new Cell(true);
                    bombCount++;
                }
                else
                Field[i, j] = new Cell(false);
            }
        }
        //shuffle field
        Field.Shuffle();  
        
        //set neighbour mines
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Field[i, j].NeighbourMines = GetNeighbourMines(i, j);
                Field[i, j].Position = (i, j);
            }
        }
    }

    private int GetNeighbourMines(int i, int j)
    {
        int count = 0;
        for (int x = i - 1; x <= i + 1; x++)
        {
            for (int y = j - 1; y <= j + 1; y++)
            {
                if (x >= 0 && x < Field.GetLength(0) && y >= 0 && y < Field.GetLength(1))
                {
                    if (Field[x, y].IsMined)
                    {
                        count++;
                    }
                }
            }
        }
        return count;
       
    }

    public void RevealCell(Cell cell)
    {
        try
        {
            cell.IsRevealed = true;
            if (cell.IsMined)
            {

                IsGameOver = true;

                RevealAllCells();
            }
            else if (cell.NeighbourMines == 0)
            {
                var x = cell.Position.Item1;
                var y = cell.Position.Item2;
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (i >= 0 && i < Field.GetLength(0) && j >= 0 && j < Field.GetLength(1))
                        {
                            if (!Field[i, j].IsRevealed)
                            {
                                RevealCell(Field[i, j]);
                            }
                        }
                    }
                }
            }

        }
        catch (Exception e)
        {

            throw;
        }

    }

    private void RevealAllCells()
    {
        for (int i = 0; i < Field.GetLength(0); i++)
        {
            for (int j = 0; j < Field.GetLength(1); j++)
            {
                Field[i, j].IsRevealed = true;
            }
        }
    }
    
    public void FlagCell(Cell cell)
    {
        cell.IsFlagged = !cell.IsFlagged;
    }

    public void DisplayFieldInConsole()
    {
        for (int i = 0; i < Field.GetLength(0); i++)
        {
            for (int j = 0; j < Field.GetLength(1); j++)
            {
                if (Field[i, j].IsMined)
                {
                    Console.Write("X ");
                }
                else
                {
                    Console.Write(Field[i, j].NeighbourMines + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
