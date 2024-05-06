using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreenScript : MonoBehaviour
{

    public Button restartButton;
    public Button mainMenuButton;
    public Button quitButton;



    void Start()
    {
        GameManagerScript.instance.gameOverUi = gameObject;
        gameObject.SetActive(false);
        restartButton.onClick.AddListener(restart);
        mainMenuButton.onClick.AddListener(mainMenu);
        quitButton.onClick.AddListener(quitGame);
 
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        // Debug.Log("main menu");
    }

    public void quitGame()
    {
        Application.Quit();
        // Debug.Log("Quit");
    }
}
