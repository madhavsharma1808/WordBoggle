using System.Collections.Generic;
using UnityEngine;
using WordBoggle.InputSystem;
using WordBoggle.Models;
using WordBoggle.View;

namespace WordBoggle.Controllers
{
    public class GameplayController
    {
        private GridView _gridView;
        private GameModel _gameModel;
        private GridModel _gridModel;
        private InputManager _inputManager;
        public GameplayController(GridView gridView, InputManager inputManager, ValidWordsList validWordList)
        {
            this._gridView = gridView;
            this._inputManager = inputManager;
            this._gridModel = new GridModel(4, 4);
            this._gameModel = new GameModel(new HashSet<string>(validWordList.words));
            this._gridView.init(this._gridModel.Rows, this._gridModel.Columns, this._gridModel.GetGrid());
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
           Debug.Log("The selcted word is : "+ selectedWord);

           this._gameModel.checkForvalidWord(selectedWord);
           Debug.Log("The current game state is : "+ this._gameModel.GetScore() + " : "+ this._gameModel.GetWordsFoundCount());
           this._gridModel.ClearSelection();
           this. _gridView.ClearHighlights();
        }
    }
}