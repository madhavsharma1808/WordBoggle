using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WordBoggle.Models
{
    public class GameModel
    {

        //gameModel stores all the state related to game like score, foundwords and have the isValidheck
        private HashSet<string> _validWords;
        private int _score;
        private HashSet<string> _foundWords;
        public GameModel(HashSet<string> validWords)
        {
            this._validWords = validWords;
            this._foundWords = new HashSet<string>();
        }
        public void checkForvalidWord(string word)
        {
            word = word.ToLower();
            if (this._validWords.Contains(word) && !this._foundWords.Contains(word))
            {
                this.onNewWordFound(word);
            }
        }

          void onNewWordFound(string word)
        {
            this.AddScore(word.Length);
            this._foundWords.Add(word);
        }


        void AddScore(int score)
        {
            this._score += score;
        }

        public int GetScore()
        {
            return this._score;
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