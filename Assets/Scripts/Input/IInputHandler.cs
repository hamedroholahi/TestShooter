using UnityEngine;

public interface IInputHandler
{
    Vector2 GetMoveInput();
    bool IsShooting();

    bool IsChangeGun();
}
