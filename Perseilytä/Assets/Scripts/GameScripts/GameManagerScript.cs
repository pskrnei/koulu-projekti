using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUi;

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//vaihtaa seuraavaa sceneen
    }

    public void gameOver()
    {
        gameOverUi.SetActive(true);
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
