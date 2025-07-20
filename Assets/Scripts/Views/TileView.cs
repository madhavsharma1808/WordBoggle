using TMPro;
using UnityEngine;
using UnityEngine.UI; // Needed for Image

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

        public void Init(char letter)
        {
            _textComponent.text = letter.ToString();
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