using UnityEngine;
using System;

namespace WordBoggle.InputSystem
{
    public class InputManager : MonoBehaviour
    {

        //This class manages the all the things related to input independently and then calls gameplaycontroller and gameplaycontroller can decide which action to perform . 
        //So this helps us in mainatianing Single Responsibility principle 
        public event Action<Vector2> OnPlayerTouch;
        public  event Action OnPlayerTouchEnd;
        private Camera _cam;
        private IInputGetter _inputGetter;

        void Start()
        {
            this._cam = Camera.main;
            this._inputGetter = Application.isMobilePlatform ? new TouchInputGetter() : new MouseInputGetter();
        }

        void Update()
        {
            if (this._inputGetter.GetTouch(out Vector2 screenPos, out TouchPhase phase))
            {
                Vector2 worldPos = this._cam.ScreenToWorldPoint(screenPos);

                if (phase == TouchPhase.Began || phase == TouchPhase.Moved)
                    this.OnPlayerTouch?.Invoke(worldPos);

                if (phase == TouchPhase.Ended)
                    this.OnPlayerTouchEnd?.Invoke();
            }
        }
    }
}