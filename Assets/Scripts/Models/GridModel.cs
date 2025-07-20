using System;
using System.Collections.Generic;
using System.Linq;

namespace WordBoggle.Models
{
    public class GridModel
    {

        //GridModel has all the things related to the grid . We have seperated to gridmodel and gamemodel as gridmodel is only concerned with grid based things and gamemodel is concerned with gamePlay related things
        //So its easy to manage and maintain in the future as well
       
        private char[,] _grid;
        private List<GridPos> _selectedTiles = new List<GridPos>();
        public int Rows { get; }
        public int Columns { get; }

        public GridModel(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            this._grid = new char[rows, columns];
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            var random = new Random();
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    this._grid[row, col] = (char)('A' + random.Next(0, 26));
                }
            }
        }
        public char GetLetterAt(GridPos pos)
        {
            return this._grid[pos.Row, pos.Col];
        }

        public bool TrySelectTile(GridPos pos)
        {
            if (IsValidSelection(pos))
            {
                this._selectedTiles.Add(pos);
                return true;
            }
            return false;
        }

        public string GetSelectedWord()
        {
            return string.Concat(_selectedTiles.Select(pos => GetLetterAt(pos)));
        }

        public void ClearSelection()
        {
            _selectedTiles.Clear();
        }

        private bool IsValidSelection(GridPos pos)
        {
            if (_selectedTiles.Contains(pos))
                return false;

            if (_selectedTiles.Count == 0)
                return true;

            GridPos lastPos = _selectedTiles[_selectedTiles.Count - 1];

            int rowDiff = Math.Abs(pos.Row - lastPos.Row);
            int colDiff = Math.Abs(pos.Col - lastPos.Col);
            return rowDiff <= 1 && colDiff <= 1;
        }

        public char[,] GetGrid()
        {
            return (char[,])this._grid.Clone();
        }
    }
}