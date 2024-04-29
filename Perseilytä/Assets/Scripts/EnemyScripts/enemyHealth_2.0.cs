using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public ScoreManager ScoreManager; // Viittaus ScoreManager-skriptiin
    public float health;
    public float maxHealth = 100f;

    //lisä
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager = FindObjectOfType<ScoreManager>();

        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
   {
        if (health <= 0)
        {
            Destroy(gameObject);
            if (ScoreManager != null)
            {
                ScoreManager.UpdateScore();
            }
        }
    }
   
    

}
