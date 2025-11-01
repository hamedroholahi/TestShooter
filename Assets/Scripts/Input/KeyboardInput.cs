using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : IInputHandler
{
    public Vector2 GetMoveInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"),0);
    }

    public bool IsShooting()
    {
        return Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0);
    }

    public bool IsChangeGun()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }

}
