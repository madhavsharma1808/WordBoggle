using System;
using System.Collections.Generic;
using System.Linq;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using WordBoggle.Definations;

namespace WordBoggle.Models
{
    public class GridModel
    {
        protected TileGridData[,] _grid;
        protected List<GridPos> _selectedTiles = new List<GridPos>();

        public GridModel()
        {
            this._grid = new TileGridData[this.GetMaxRow(), this.GetMaxCol()];
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            var random = new System.Random();
            for (int row = 0; row < this.GetMaxRow(); row++)
            {
                for (int col = 0; col < this.GetMaxCol(); col++)
                {
                    char letter = (char)('A' + random.Next(0, 26));
                    TileType type = this.GetTileTypeForGrid();
                    this._grid[row, col] = new TileGridData(letter, type);
                }
            }
        }

        protected virtual TileType GetTileTypeForGrid()
        {
            return TileType.Normal;
        }

        public char GetLetterAt(GridPos pos)
        {
            return this._grid[pos.Row, pos.Col].Letter;
        }

        public TileType GetTileTypeAt(GridPos pos)
        {
            return this._grid[pos.Row, pos.Col].Type;
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

        public virtual void onWordValid()
        {
            this.CheckAndUnblockAdjacentTiles();
        }


        private void CheckAndUnblockAdjacentTiles()
        {

            foreach (var tile in _selectedTiles)
            {
                Vector2Int pos = new Vector2Int(tile.Col, tile.Row); // x = col, y = row

                foreach (var dir in _directions) // right/down/left/up
                {
                    Vector2Int neighbor = pos + dir;
                    if (IsValidPosition(neighbor))
                    {
                        int row = neighbor.y;
                        int col = neighbor.x;

                        if (_grid[row, col].Type == TileType.Blocked)
                        {
                            _grid[row, col].Type = TileType.Normal;
                        }
                    }
                }
            }
        }

        private bool IsValidPosition(Vector2Int pos)
        {
            return pos.x >= 0 && pos.x < GetMaxRow() &&
                   pos.y >= 0 && pos.y < GetMaxCol();
        }

        private readonly Vector2Int[] _directions = new Vector2Int[]
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };


        public List<GridPos> GetCurrentlySelectedTiles()
        {
            return this._selectedTiles;
        }

        private bool IsValidSelection(GridPos pos)
        {
            if (this._grid[pos.Row, pos.Col].Type == TileType.Blocked)
            {
                return false;
            }
            if (_selectedTiles.Contains(pos))
                return false;

            if (_selectedTiles.Count == 0)
                return true;

            GridPos lastPos = _selectedTiles[_selectedTiles.Count - 1];

            int rowDiff = Math.Abs(pos.Row - lastPos.Row);
            int colDiff = Math.Abs(pos.Col - lastPos.Col);
            return rowDiff <= 1 && colDiff <= 1;
        }

        public TileGridData[,] GetGrid()
        {
            //return (TileGridData[,])this._grid.Clone();
            return this._grid;
        }

        public virtual int GetMaxRow()
        {
            return GameConstants.MaxRows;
        }

        public virtual int GetMaxCol()
        {
            return GameConstants.MaxCols;
        }
    }
}