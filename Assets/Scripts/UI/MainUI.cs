using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : SingletonBase<MainUI> , IView
{
    [SerializeField] private HomeButtonMenu[] homeButtons;
    [SerializeField] private List<RectTransform> panels;

    [SerializeField] private SettingsScreen settingsScreen;
    [SerializeField] private HomeScreen homeScreen;
    
    private int currentPageIndex =1;

    void Start()
    {
        InitView();
    }

   
    public void InitView()
    {
        homeScreen.InitView();
        settingsScreen.InitView();

        for (int i = 0; i < homeButtons.Length; i++)
        {
            int index = i;
            homeButtons[i].button.onClick.RemoveAllListeners();
            homeButtons[i].InitView();
            homeButtons[i].button.onClick.AddListener(() => OnClickBottomMenu(index));
        }
        
        OnClickBottomMenu(0);

    }
    
    
    private void OnClickBottomMenu(int index)
    {
        if (index == currentPageIndex) return;
        foreach (var button in homeButtons)
        {
            button.SetActive(false);
        }

        homeButtons[index].SetActive(true);

        RectTransform currentPanel = panels[currentPageIndex];
        RectTransform newPanel = panels[index];
        
        currentPanel.gameObject.SetActive(false);
        newPanel.gameObject.SetActive(true);

        currentPageIndex = index;
    }
}
