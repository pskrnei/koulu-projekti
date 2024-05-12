using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Damage : MonoBehaviour
{

    public playerHealth pHealth;
    public float damage;
    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
      playerScript = FindObjectOfType<Player>(); // callaan "player" scriptin ett‰ saa flashred funktion
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerScript.StartCoroutine(playerScript.FlashRed()); //pelaaja v‰l‰ht‰‰ kun ottaa damagea
            other.gameObject.GetComponent<playerHealth>().health -= damage;
        }
       
    }
}

