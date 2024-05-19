using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public playerHealth pHealth;
    public PlayerShield pShield;
    public float damage;
    Player playerScript;

    private bool isShield;

    // Start is called before the first frame update
    void Start()
    {
      playerScript = FindObjectOfType<Player>(); // callaan "player" scriptin että saa flashred funktion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {

            if (other.gameObject.GetComponent<PlayerShield>().shield > 0)
            {
                other.gameObject.GetComponent<PlayerShield>().shield -= damage;
            }

            else if(other.gameObject.GetComponent<PlayerShield>().shield <= 0)
            {
                other.gameObject.GetComponent<playerHealth>().health -= damage;
            }
            //other.gameObject.GetComponent<playerHealth>().health -= damage;
            
        }
    }
}

