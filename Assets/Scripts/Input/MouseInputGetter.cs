using UnityEngine;

namespace WordBoggle.InputSystem
{
    public class MouseInputGetter : IInputGetter
    {
        //This script will be used for testing on the system(PC/laptop) as it register the mouse click
        public bool GetTouch(out Vector2 pos, out TouchPhase phase)
        {
            pos = Vector2.zero;
            phase = TouchPhase.Canceled;

            if (Input.GetMouseButtonDown(0))
            {
                pos = Input.mousePosition;
                phase = TouchPhase.Began;
                return true;
            }
            else if (Input.GetMouseButton(0))
            {
                pos = Input.mousePosition;
                phase = TouchPhase.Moved;
                return true;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                pos = Input.mousePosition;
                phase = TouchPhase.Ended;
                return true;
            }

            return false;
        }
    }
}