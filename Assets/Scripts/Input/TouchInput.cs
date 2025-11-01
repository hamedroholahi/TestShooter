
using UnityEngine;

public class TouchInput : IInputHandler
{
    private Vector2 lastTouchPos;

    public Vector2 GetMoveInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 delta = touch.deltaPosition;

            return new Vector2(delta.x / Screen.width * 10f, 0f);
        }

        return Vector2.zero;
    }

    public bool IsShooting()
    {
        return Input.touchCount > 1;
    }

    public bool IsChangeGun()
    {
        return false;
    }
}
