using TMPro;
using UnityEngine;
using WordBoggle.Definations;

public class ObjectiveView : MonoBehaviour
{
    [SerializeField] private TMP_Text _objectiveText;

//Objective view use to display the objective
    public void ShowObjective(GameMode gameMode, LevelData data)
    {

        if (gameMode == GameMode.Endless)
        {
            _objectiveText.text = "Endless Mode";
            return;
        }

        //The architecture for the objective is completed but due to time constraint couldnt complete it
        // switch(data.objectiveType)
        // {
        //     case LevelObjectiveType.MakeWords:
        //         _objectiveText.text = $"Make {data.targetWordsCount} words";
        //         break;
        //     case LevelObjectiveType.ReachScoreInTime:
        //         _objectiveText.text = $"Score {data.targetScore} in {data.timeLimitSec} seconds";
        //         break;
        //     case LevelObjectiveType.MakeWordsInTime:
        //         _objectiveText.text = $"Make {data.targetWordsCount} words in {data.timeLimitSec} seconds";
        //         break;
        // }
    }
    
}
