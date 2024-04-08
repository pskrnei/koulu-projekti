using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 100f;

    //lisä
    private Rigidbody2D rb;

    //lisä

    //[SerializeField] StatusBarHealth statusBar;

    private void Awake()
    {
       // statusBar = GetComponent<StatusBarHealth>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        //statusBar.UpdateStatusBar(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
   {
        // statusBar.UpdateStatusBar(health, maxHealth);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
   
    

}
