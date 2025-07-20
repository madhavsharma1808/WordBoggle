using System;
using WordBoggle.Definations;

namespace WordBoggle.Models
{
    public class LevelsModeGridModel : GridModel
    {
        //LevelGridModell have level game mode specific functionlaity
        
        public LevelsModeGridModel() : base()
        {
        }

        public override int GetMaxRow()
        {
            return GameConstants.MaxCols;
        }

        public override int GetMaxCol()
        {
            return GameConstants.MaxRows;
        }

    //Currently generating random tile types for level grid
        protected override TileType GetTileTypeForGrid()
        {
            TileType type = TileType.Normal;
            var random = new Random();
            int rand = random.Next(0, 6);
            if (rand == 0)
                type = TileType.Bonus;
            else if (rand == 1)
                type = TileType.Blocked;
            return type;
        }
    }
}