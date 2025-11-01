using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings
{
    public static ControlType controlType = ControlType.Keyboard;

    public static void SetControlType(ControlType type)
    {
        controlType = type;
        PlayerPrefs.SetInt("ControlType" , (int)type);
    }

    public static void LoadSetting()
    {
        controlType = (ControlType)PlayerPrefs.GetInt("ControlType", 0);
    }
}

public enum ControlType {
    Keyboard,
    Touch
}
