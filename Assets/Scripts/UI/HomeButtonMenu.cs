using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeButtonMenu : MonoBehaviour , IView
{
    [SerializeField] private TMP_Text titleTect;
    [SerializeField] public Button button;
    public void InitView()
    {
        SetActive(false);
    }

    public void SetActive(bool active)
    {
        titleTect.gameObject.SetActive(active);
    }
}
