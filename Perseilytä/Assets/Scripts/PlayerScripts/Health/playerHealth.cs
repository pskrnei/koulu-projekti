using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;

    private float fillSpeed = 5f; // healthbarin sulavaan liikkumiseen



    private bool isDead; //gameover UI juttu

   
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
       //isDead = false; // Make sure isDead is initialized to false
    }

    // Update is called once per frame
    void Update()
    {

        float targetFillAmount = Mathf.Clamp(health / maxHealth, 0f, 1f);
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, targetFillAmount, Time.deltaTime * fillSpeed); // sulavasti liikkuva palkki

   
        if (health <= 0 && !isDead)
        {
            isDead = true;
            GameManagerScript.instance.gameOver();
            Destroy(gameObject);
            // Additional death-related actions can be added here
        }
 
    }
}
