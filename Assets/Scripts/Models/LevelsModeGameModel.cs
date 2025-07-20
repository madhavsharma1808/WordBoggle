using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using WordBoggle.Definations;

namespace WordBoggle.Models
{
    public class LevelsModeGameModel : GameModel
    {

        //LevelsGamemodel have level game mode specific functionlaity
        private LevelData _levelData;
        private int _currentLevel = 1;
        private LevelDataList _levelDataList = null;
        private LevelObjectiveType _levelObjectiveType;
        public LevelsModeGameModel(HashSet<string> validWords) : base(validWords)
        {
            this.CheckForLevelData();
        }

        //Have implemented the core functionality of LevelObjective but couldnt fully implement it because of 6-8 hours time constraint mentioned in the assignment
        //Architecture wise its sompleted

        protected override void onNewWordFound(string word, TileGridData[,] grid, List<GridPos> selectedTiles)
        {
            if (this._levelObjectiveType == LevelObjectiveType.MakeWords && this.GetWordsFoundCount() >= _levelData.wordCount)
            {
                WinLevel();
            }

            if (this._levelObjectiveType == LevelObjectiveType.MakeWordsInTime && this.GetWordsFoundCount() >= _levelData.wordCount)
            {
                WinLevel();
            }

            if (this._levelObjectiveType == LevelObjectiveType.ReachScoreInTime && this.GetScore() >= _levelData.totalScore)
            {
                WinLevel();
            }
            base.onNewWordFound(word, grid, selectedTiles);
        }

        void WinLevel()
        {
            this._currentLevel++;
            //this.Reset();
            this.CheckForLevelData();
        }

        private void CheckForLevelData()
        {
            this._levelData = this.LoadLevelData(this._currentLevel - 1);
            this._levelObjectiveType = this.GetObjectiveType();
        }


        public LevelObjectiveType GetObjectiveType()
        {
            bool hasWordCount = this._levelData.wordCount > 0;
            bool hasTime = this._levelData.timeSec > 0;
            bool hasScore = this._levelData.totalScore > 0;

            if (hasWordCount && hasTime)
            {
                return LevelObjectiveType.MakeWordsInTime;
            }
            else if (hasScore && hasTime)
            {
                return LevelObjectiveType.ReachScoreInTime;
            }
            else if (hasWordCount)
            {
                return LevelObjectiveType.MakeWords;
            }
            else
            {
                //Default value
                return LevelObjectiveType.MakeWords;
            }
        }

        private LevelData LoadLevelData(int levelIndex)
        {
            if (this._levelDataList == null)
            {
                TextAsset json = Resources.Load<TextAsset>("levelData");
                if (json == null)
                {
                    return null;
                }

                this._levelDataList = JsonUtility.FromJson<LevelDataList>(json.text);
            }

            if (levelIndex < 0 || levelIndex >= this._levelDataList.data.Length)
            {
                Debug.LogError("Invalid level index: " + levelIndex);
                return null;
            }
            return this._levelDataList.data[levelIndex];
        }

    }

    internal class LevelListData
    {

    }
}