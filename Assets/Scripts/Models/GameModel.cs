using System;
using System.Collections.Generic;
using System.Diagnostics;
using WordBoggle.Definations;

namespace WordBoggle.Models
{
    public class GameModel
    {

        //gameModel stores all the things related to game like score, foundwords and have the isValidheck
        private HashSet<string> _validWords;
        private int _score;
        private HashSet<string> _foundWords;
        public GameModel(HashSet<string> validWords)
        {
            this._validWords = validWords;
            this._foundWords = new HashSet<string>();
        }
        public bool checkForvalidWord(string word, TileGridData[,] grid, List<GridPos> selectedTiles)
        {
            word = word.ToLower();
            if (this._validWords.Contains(word) && !this._foundWords.Contains(word))
            {
                this.onNewWordFound(word, grid, selectedTiles);
                return true;
            }
            return false;
        }

        protected virtual void onNewWordFound(string word, TileGridData[,] grid, List<GridPos> selectedTiles)
        {
            this.AddScore(this.CalculateScoreForWord(grid, selectedTiles));
            this._foundWords.Add(word);
        }

        private int CalculateScoreForWord(TileGridData[,] grid, List<GridPos> selectedTiles)
        {
            int score = selectedTiles.Count;

            foreach (var tile in selectedTiles)
            {
                if (grid[tile.Row, tile.Col].Type == TileType.Bonus)
                {
                    score += GameConstants.AdditionalScoreFromBonusTiles;
                }
            }
            return score;
        }

        void AddScore(int score)
        {
            this._score += score;
        }

        public int GetScore()
        {
            return this._score;
        }

        public float GetAveregeScorePerWord()
        {
            if (this._score == 0 || this._foundWords.Count == 0)
                return 0;
            return (this._score / this._foundWords.Count);

        }

        public int GetWordsFoundCount()
        {
            return this._foundWords.Count;
        }

        public void Reset()
        {
            this._score = 0;
            this._foundWords.Clear();
        }
    }
}