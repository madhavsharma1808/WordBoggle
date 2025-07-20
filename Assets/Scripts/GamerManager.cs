using System.Collections.Generic;
using UnityEngine;
using WordBoggle.Controllers;
using WordBoggle.Definations;
using WordBoggle.InputSystem;
using WordBoggle.View;

namespace WordBoggle.Core
{
    public class GameManager : MonoBehaviour
    {

        //gamemanager is thhe Monobehaviour script which creates gameplayController and is treated as the starting point of the game. I injects the Gridview, input manager and the validWordList scriptable object/
        //We could directly make gameplaycontroller a mono instead of GameManager being the starting point but this is approach is more flexible and allows us to add more functionality to the game later on as
        //Gameplaycontroller should only worry about gameplay related tasks and gameManager is the starting point that creates the gameplaycontroller

        [SerializeField] private GridView _gridView;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private ValidWordsList _validWordList;
        [SerializeField] private GameStatsView _gameStatsView;
        [SerializeField] private GameModeData _gameModeData;
        [SerializeField] private ObjectiveView _objectiveView;
        private GameplayController _gameplayController;

        void Start()
        {
            this._gameplayController = GameFactory.CreateGameplayController(_gameModeData.selectedGameMode, this._gridView, this._inputManager, this._validWordList, this._gameStatsView, this._objectiveView);
        }

        void OnDestroy()
        {
            this._gameplayController.DeRegisterListeners();
        }

    }
}