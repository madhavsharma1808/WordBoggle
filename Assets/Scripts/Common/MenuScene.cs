// LoadingSceneController.cs
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WordBoggle.Definations;
using Unity.VisualScripting;

public class MenuScene : MonoBehaviour
{

    //this is menuscen and is responsible for loading the gamescen and have the option to select endless or level mode
    [SerializeField] private Button _endlessButton;
    [SerializeField] private Button _levelsButton;
    [SerializeField] private GameModeData _gameModeData;

    private void Start()
    {
        _endlessButton.onClick.AddListener(() =>
        {
            _gameModeData.selectedGameMode = GameMode.Endless;
            SceneManager.LoadScene("GameScene");
        });

        _levelsButton.onClick.AddListener(() =>
        {
            _gameModeData.selectedGameMode = GameMode.Levels;
            SceneManager.LoadScene("GameScene");
        });
    }

}