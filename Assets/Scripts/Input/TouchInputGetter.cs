using UnityEngine;

namespace WordBoggle.InputSystem
{
    public class TouchInputGetter : IInputGetter
    {
        //This scriptt will be used for testing on the mobile device as it registers the touch input on the touch screen.
        public bool GetTouch(out Vector2 pos, out TouchPhase phase)
        {
            pos = Vector2.zero;
            phase = TouchPhase.Canceled;

            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                pos = touch.position;
                phase = touch.phase;
                return true;
            }

            return false;
        }
    }
}