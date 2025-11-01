using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

public class HomeScreen : MonoBehaviour , IView
{

    [SerializeField] private Button startGameButton;

    public void InitView()
    {
        startGameButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);

    }
}
