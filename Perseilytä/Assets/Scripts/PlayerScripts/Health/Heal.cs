using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Heal : MonoBehaviour
{

    public playerHealth pHealth;
    public float heal;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //playerScript.StartCoroutine(playerScript.FlashRed()); //pelaaja v‰l‰ht‰‰ kun ottaa damagea
            other.gameObject.GetComponent<playerHealth>().health += heal;
            Destroy(gameObject);
        }

    }
}
