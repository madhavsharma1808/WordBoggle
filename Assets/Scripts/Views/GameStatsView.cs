using TMPro;
using UnityEngine;

namespace WordBoggle.View
{
    public class GameStatsView : MonoBehaviour
    {

        //View to see Stats
        [SerializeField] TextMeshProUGUI _currentcoreText;
        [SerializeField] TextMeshProUGUI _averegeScoreText;

        public void onScoreUpdate(int currentScore, float _averegeScore)
        {
            this._currentcoreText.text = currentScore.ToString();
            this._averegeScoreText.text = _averegeScore.ToString();
        }

    }
}
