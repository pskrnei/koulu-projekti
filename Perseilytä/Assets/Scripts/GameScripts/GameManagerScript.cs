using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mono.Data.Sqlite;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public GameObject gameOverUi;
    public ScoreManager scoreManager;
    public SimpleDB SimpleDB;

    private string playerName;
    private int playerScore;

    private string dbName = "URI=file:Player.db";
    

    void Start()
    {
        SimpleDB.CreateDB();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // S‰ilytt‰‰ scriptin scenejen v‰lill‰
        }
        else
        {
            Destroy(gameObject); // varmistaa ett‰ vain yksi GameManager scripti on olemassa
        }
    }

    //tietokanta funktiot
    public void setPlayerName(string playerName)
    {
        playerName = name;
    }
    public void updatePlayerScore(int score)
    {
        playerScore += score; // TODO korjaa ett‰ ylikirjoittaa scoren vain jos se on isompi
    }
    public void SavePlayerData()
    {
        SimpleDB.savePlayerData(playerName, playerScore); // Save player data using SimpleDB
    }



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
