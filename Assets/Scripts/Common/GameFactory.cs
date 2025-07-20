using System.Collections.Generic;
using WordBoggle.Controllers;
using WordBoggle.Definations;
using WordBoggle.InputSystem;
using WordBoggle.Models;
using WordBoggle.View;

public static class GameFactory
{
    public static GameModel CreateGameModel(GameMode mode, HashSet<string> wordList)
    {
        switch (mode)
        {
            case GameMode.Endless:
                return new EndlessModeGameModel(wordList);
            case GameMode.Levels:
                return new LevelsModeGameModel(wordList);
            default:
                throw new System.ArgumentException("Unsupported game mode");
        }
    }

    public static GameplayController CreateGameplayController(GameMode gameMode, GridView gridView, InputManager inputManager, ValidWordsList validWordList, GameStatsView gameStatsView, ObjectiveView objectiveView)
    {
        switch (gameMode)
        {
            case GameMode.Endless:
                return new EndlessModeGameplayController(gameMode, gridView, inputManager, validWordList, gameStatsView, objectiveView);
            case GameMode.Levels:
                return new LevelsModeGameplayController(gameMode, gridView, inputManager, validWordList, gameStatsView, objectiveView);
            default:
                throw new System.ArgumentException("Unsupported game mode");
        }
    }

    public static GridModel CreateGridModel(GameMode mode)
    {
        switch (mode)
        {
            case GameMode.Endless:
                return new EndlessModeGridModel();
            case GameMode.Levels:
                return new LevelsModeGridModel();
            default:
                throw new System.ArgumentException("Unsupported game mode");
        }
    }


}