using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Viittaus tekstikentt��n, jossa n�ytet��n pistem��r�
    public int score = 0; // Pistem��r� alussa on 0
    
    [SerializeField] private GameObject[] extraSpawners; 


    void Start()
    {
        // Etsit��n tekstikentt�, jos sit� ei ole asetettu Inspectorissa
        if (scoreText == null)
            scoreText = GetComponent<Text>();

        // P�ivitet��n pistem��r� n�yt�ll�
        UpdateScoreDisplay();
        
        GameManagerScript.instance.scoreManager = this;
    }

    void Update()
    {
        addSpawners();
    }
    // Metodi, jolla p�ivitet��n pistem��r� n�yt�ll�
    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString(); // Asetetaan tekstikent�n sis�lt� pistem��r�n mukaan
    }

    // Metodi, jota kutsutaan, kun pistem��r�� pit�� p�ivitt��
    public void UpdateScore()
    {
        //gameManagerScript.updatePlayerScore(++score); koittaa tota jos muu toimii
        score++; // Lis�t��n yksi piste pistem��r��n
        UpdateScoreDisplay(); // P�ivitet��n pistem��r� n�yt�ll�
       // Debug.Log(score);
    }

    public void addSpawners()
    {
        for (int i = 0; i < extraSpawners.Length; i++)
        {
            // Vaadittu score uudelle spawnerille
            if (score >= (i + 1) * 100)
            {
                // onko spawner jo aktiivinen
                if (!extraSpawners[i].activeInHierarchy)
                {
                    extraSpawners[i].SetActive(true);
                }
            }
        }
    }
}
