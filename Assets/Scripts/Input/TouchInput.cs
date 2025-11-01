
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchInput : IInputHandler
{
    private Vector2 lastTouchPos;
    private bool isShooting = false;
    private bool changeWeaponPressed = false;

    public TouchInput()
    {
        var shootBtn = GameObject.FindWithTag("ShootButton").GetComponent<Button>();
        var shootTrigger = shootBtn.gameObject.AddComponent<EventTrigger>();

        var shootDown = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        shootDown.callback.AddListener((data) => { isShooting = true; });

        var shootUp = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };
        shootUp.callback.AddListener((data) => { isShooting = false; });

        shootTrigger.triggers.Add(shootDown);
        shootTrigger.triggers.Add(shootUp);

        var changeBtn = GameObject.FindWithTag("ChangeWeapon").GetComponent<Button>();
        changeBtn.onClick.AddListener(() => { changeWeaponPressed = true; });
    }
    
    public Vector2 GetMoveInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float sensitivity = 0.03f;
            return new Vector2(touch.deltaPosition.x * sensitivity, 0);
        }
        return Vector2.zero;
    }

    public bool IsShooting()
    {
        return isShooting;
    }

    public bool IsChangeGun()
    {
        if (changeWeaponPressed)
        {
            changeWeaponPressed = false;
            return true;
        }
        return false;
    }
}
