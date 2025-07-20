// Scripts/Data/GameModeData.cs
using UnityEngine;
using WordBoggle.Definations;

[CreateAssetMenu(fileName = "GameModeData", menuName = "Game/ModeData")]
public class GameModeData : ScriptableObject
{

    //This class is used to pass gamemode data across scenes
    public GameMode selectedGameMode;
}