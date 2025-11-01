using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class SettingsScreen : MonoBehaviour , IView
{
    [SerializeField] private Button KeyboardButton , touchBUtton;
    [SerializeField] private TMP_Text inputText;

    public void InitView()
    {
        GameSettings.LoadSetting();
        UpdateUI();
        
        KeyboardButton.onClick.AddListener(OnKeyboardClick);
        touchBUtton.onClick.AddListener(OnTouchClick);
        
    }
    
    void ChangeControl(ControlType type)
    {
        GameSettings.SetControlType(type);
        UpdateUI();
    }

    void UpdateUI()
    {
        inputText.text = $"Current: {GameSettings.controlType}";

        Color selected = new Color(0.3f, 1f, 0.3f);
        Color normal = Color.white;

        KeyboardButton.GetComponent<Image>().color =
            GameSettings.controlType == ControlType.Keyboard ? selected : normal;

        touchBUtton.GetComponent<Image>().color =
            GameSettings.controlType == ControlType.Touch ? selected : normal;
    }

    void OnKeyboardClick()
    {
        ChangeControl(ControlType.Keyboard);
    }

    void OnTouchClick()
    {
        ChangeControl(ControlType.Touch);
    }
}
