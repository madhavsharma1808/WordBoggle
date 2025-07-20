using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
using WordBoggle.Definations;
using WordBoggle.Models;
using TileGridData = WordBoggle.Models.TileGridData;

namespace WordBoggle.View
{
    public class TileView : MonoBehaviour
    {
        //GridView has all the UI logic . I have kept the Ui and the logical part seperately following the MVC model and its the job of the gameplaycontroller to manage the state of both view and controllers 
        //This script will manage the UI state of the individual tile
        [SerializeField] private TextMeshProUGUI _textComponent;
        [SerializeField] private Image _image;
        [SerializeField] private Color _highlightColor;
        [SerializeField] private Color _unhighlightColor;
        [SerializeField] private GameObject _bonusGameObject;
        [SerializeField] private GameObject _blockedGameObject;


        public void Init(TileGridData tileGridData)
        {
            this._textComponent.text = tileGridData.Letter.ToString();
            if (tileGridData.Type == TileType.Blocked)
            {
                Debug.Log("It is blocked : " + tileGridData.Letter);
            }
            this._bonusGameObject.SetActive(tileGridData.Type == TileType.Bonus);
            this._blockedGameObject.SetActive(tileGridData.Type == TileType.Blocked);
        }

        public void Highlight()
        {
            if (this._image)
                this._image.color = _highlightColor;
        }

        public void UnHighlight()
        {
            if (this._image)
                this._image.color = _unhighlightColor;
        }
    }
}