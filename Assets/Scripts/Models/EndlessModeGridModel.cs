using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WordBoggle.Definations;

namespace WordBoggle.Models
{
    public class EndlessModeGridModel : GridModel
    {
        public EndlessModeGridModel() : base()
        {
        }

         public override void onWordValid()
        {
            this.CollapseAndRefillGrid();
            _selectedTiles.Clear();
        }

        private void CollapseAndRefillGrid()
        {
            var random = new Random();
            var groupedByCol = _selectedTiles
                .GroupBy(pos => pos.Col)
                .ToDictionary(g => g.Key, g => g.Select(p => p.Row).OrderBy(row => row).ToList());

            foreach (var val in groupedByCol)
            {
                int col = val.Key;
                List<int> rowsToRemove = val.Value;

                foreach (int rowToRemove in rowsToRemove)
                {
                    // Move all characters above the current one down by one
                    for (int row = rowToRemove; row > 0; row--)
                    {
                        _grid[row, col] = _grid[row - 1, col];
                    }

                    // Assign a new random letter at the top
                     char letter = (char)('A' + random.Next(0, 26));

                    this._grid[0, col] = new TileGridData(letter, this.GetTileTypeForGrid());
                }
            }
        }
    }
}