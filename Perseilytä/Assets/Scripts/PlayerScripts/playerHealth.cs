using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;

    private bool isDead; //gameover UI juttu

    public GameManagerScript gameManager;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
       //isDead = false; // Make sure isDead is initialized to false
    }

    // Update is called once per frame
    void Update()
    {
       
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0 && !isDead)
        {
            isDead = true;
            gameManager.gameOver();
            Destroy(gameObject);
            // Additional death-related actions can be added here
        }
 
    }
}
