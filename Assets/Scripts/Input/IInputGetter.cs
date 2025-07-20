using UnityEngine;

namespace WordBoggle.InputSystem
{

    //This is base interface to get the user touch either from PC/laptop or mobile
    public interface IInputGetter
    {
        bool GetTouch(out Vector2 pos, out TouchPhase phase);
    }
    
}