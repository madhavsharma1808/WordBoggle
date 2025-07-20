
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using WordBoggle.Models;


namespace WordBoggle.View
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] private GameObject tilePrefab;
        [SerializeField] private float _tileSpacing = 1f;

        [SerializeField] private Camera _camera;
        private TileView[,] _tiles;

        public void init(int rows, int columns, char[,] letters)
        {
            this.CreateGrid(rows, columns, letters);
        }
        public void CreateGrid(int rows, int columns, char[,] letters)
        {
            this._tiles = new TileView[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var tile = Instantiate(tilePrefab, transform);
                    TileView tileView = tile.GetComponent<TileView>();
                    this._tiles[row, col] = tileView;
                    tileView.Init(letters[row, col]);
                    tile.transform.SetParent(transform, false);
                    var tileRect = tile.GetComponent<RectTransform>();
                    float tileWidth = tileRect.rect.width;
                    float tileHeight = tileRect.rect.height;
                    tile.transform.localPosition = new Vector3(col * (tileWidth + this._tileSpacing), -row * (tileHeight + this._tileSpacing), 0);
                }
            }
        }

        public GridPos? GetGridPosFromWorldPosition(Vector2 worldPos)
        {
            for (int row = 0; row < _tiles.GetLength(0); row++)
            {
                for (int col = 0; col < _tiles.GetLength(1); col++)
                {
                    RectTransform rect = _tiles[row, col].GetComponent<RectTransform>();
                    Vector2 localPoint;
                    if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                        rect, worldPos, null, out localPoint))
                    {
                        if (rect.rect.Contains(localPoint))
                        {
                            return new GridPos(row, col);
                        }
                    }
                }
            }
            return null;
        }

        public void HighlightTile(GridPos pos)
        {
            this._tiles[pos.Row, pos.Col].Highlight();
        }

        public void ClearHighlights()
        {
            foreach (var tile in this._tiles)
                tile.UnHighlight();
        }

    }
}
