using WordBoggle.Definations;

namespace WordBoggle.Models
{

    //Just a struct to hold the row and col of a grid position for easy readability
    public struct GridPos
    {
        public int Row { get; }
        public int Col { get; }

        public GridPos(int row, int col)
        {
            Row = row;
            Col = col;
        }

    }

    //Just a struct to hold the grid tile data for better readibility
    public struct TileGridData
    {
        public char Letter;
        public TileType Type;

        public TileGridData(char letter, TileType type)
        {
            this.Letter = letter;
            this.Type = type;
        }
    }
}