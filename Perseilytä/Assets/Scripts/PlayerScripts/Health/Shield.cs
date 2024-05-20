using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public PlayerShield pShield;
    public float plusShield;
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
            other.gameObject.GetComponent<PlayerShield>().shield += plusShield;
            Destroy(gameObject);
        }

    }
}
