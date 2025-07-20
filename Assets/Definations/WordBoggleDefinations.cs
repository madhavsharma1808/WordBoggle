using System;

namespace WordBoggle.Definations
{

    //This class has all the definations related code for the game
    public enum GameMode
    {
        Endless,
        Levels
    }

    public enum TileType
    {
        Normal = 0,
        Bonus = 1,
        Blocked = 2
    }

    public enum LevelObjectiveType
    {
        MakeWords,
        ReachScoreInTime,
        MakeWordsInTime
    }

    [Serializable]
    public class LevelDataList
    {
        public LevelData[] data;
    }


    [Serializable]
    public class GridTileData
    {
        public int tileType;
        public string letter;
    }

    [Serializable]
    public class GridSize
    {
        public int x;
        public int y;
    }

    [Serializable]
    public class LevelData
    {
        public int bugCount;
        public int wordCount;
        public int timeSec;
        public int totalScore;
        public GridSize gridSize;
        public GridTileData[] gridData;
    }

}
