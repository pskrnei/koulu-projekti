using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private GameObject ExpGem;
    
    [SerializeField] ScoreManager ScoreManager; // Viittaus ScoreManager-skriptiin
    public float health;
    public float maxHealth = 100f;

    //lisä
    private Rigidbody2D rb;

    public ParticleSystem deathParticles;

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
            DestroyEnemy();
            if (ScoreManager != null)
            {
                ScoreManager.UpdateScore();
            }
        }
    }

    public void DestroyEnemy()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Instantiate(ExpGem, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }

}
