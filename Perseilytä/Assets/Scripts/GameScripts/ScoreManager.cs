using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Viittaus tekstikentt‰‰n, jossa n‰ytet‰‰n pistem‰‰r‰
    public int score = 0; // Pistem‰‰r‰ alussa on 0
    public GameManagerScript gameManagerScript;

    void Start()
    {
        // Etsit‰‰n tekstikentt‰, jos sit‰ ei ole asetettu Inspectorissa
        if (scoreText == null)
            scoreText = GetComponent<Text>();

        // P‰ivitet‰‰n pistem‰‰r‰ n‰ytˆll‰
        UpdateScoreDisplay();
    }

    // Metodi, jolla p‰ivitet‰‰n pistem‰‰r‰ n‰ytˆll‰
    void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString(); // Asetetaan tekstikent‰n sis‰ltˆ pistem‰‰r‰n mukaan
    }

    // Metodi, jota kutsutaan, kun pistem‰‰r‰‰ pit‰‰ p‰ivitt‰‰
    public void UpdateScore()
    {
        score ++; // Lis‰t‰‰n yksi piste pistem‰‰r‰‰n
        UpdateScoreDisplay(); // P‰ivitet‰‰n pistem‰‰r‰ n‰ytˆll‰
        Debug.Log(score);
    }
}
