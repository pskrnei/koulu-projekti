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
        playerScript = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(other.gameObject.GetComponent<playerHealth>().health < other.gameObject.GetComponent<playerHealth>().maxHealth)
            { 
                other.gameObject.GetComponent<playerHealth>().health += heal;
                Destroy(gameObject);
            }
        }

    }
}
