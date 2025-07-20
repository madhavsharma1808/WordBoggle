using System;
using System.Collections.Generic;
using UnityEngine;
using WordBoggle.Definations;
using WordBoggle.InputSystem;
using WordBoggle.Models;
using WordBoggle.View;

namespace WordBoggle.Controllers
{
    public class GameplayController
    {

        //This is the gamePlayController And is created by a monobehaviour class Gamemanager it hav acces to the view and models. I am going with a MVC pattern for this project as it 
        //is scalable for adding more gamemodes and functionality in the future
        protected GridView _gridView;
        private GameModel _gameModel;
        protected GridModel _gridModel;
        private InputManager _inputManager;
        private GameStatsView _gameStatsView;
        private ObjectiveView _objectiveView;
        public GameplayController(GameMode mode, GridView gridView, InputManager inputManager, ValidWordsList validWordList, GameStatsView gameStatsView, ObjectiveView objectiveView)
        {
            this._gridView = gridView;
            this._inputManager = inputManager;
            this._gameStatsView = gameStatsView;
            this._objectiveView = objectiveView;
            this._objectiveView.ShowObjective(mode, null);
            this._gridModel = GameFactory.CreateGridModel(mode);
            this._gameModel = GameFactory.CreateGameModel(mode, new HashSet<string>(validWordList.words));
            this._gridView.init(this._gridModel.GetMaxRow(), this._gridModel.GetMaxCol(), this._gridModel.GetGrid());
            this._inputManager.OnPlayerTouch += HandlePlayerTouch;
            this._inputManager.OnPlayerTouchEnd += HandlePlayerTouchEnd;
        }

        public void DeRegisterListeners()
        {
            this._inputManager.OnPlayerTouch -= HandlePlayerTouch;
            this._inputManager.OnPlayerTouchEnd -= HandlePlayerTouchEnd;
        }
        void HandlePlayerTouch(Vector2 worldPos)
        {
            GridPos? gridPos = _gridView.GetGridPosFromWorldPosition(worldPos);
            if (gridPos.HasValue)
            {
                GridPos pos = gridPos.Value;
                if (_gridModel.TrySelectTile(pos))
                {
                    _gridView.HighlightTile(pos);
                }
            }
        }

        void HandlePlayerTouchEnd()
        {
            string selectedWord = _gridModel.GetSelectedWord();

            if (this._gameModel.checkForvalidWord(selectedWord, this._gridModel.GetGrid(), this._gridModel.GetCurrentlySelectedTiles()))
            {
                this.onWordValid();
            }
            this._gridModel.ClearSelection();
            this._gridView.ClearHighlights();
        }

        protected virtual void onWordValid()
        {
            this._gameStatsView.onScoreUpdate(this._gameModel.GetScore(), this._gameModel.GetAveregeScorePerWord());
            this._gridModel.onWordValid();
            this._gridView.updateGridView(this._gridModel.GetGrid());
        }
    }
}