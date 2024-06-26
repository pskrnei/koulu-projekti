using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eBullet_ : MonoBehaviour
{
    public playerHealth pHealth;
    public PlayerShield pShield;
    public float damage = 1f;

    [Range(1, 10)]
    [SerializeField] private float speed = 10f;

    [Range(1, 10)]
    [SerializeField] private float lifeTime = 0.5f;

    private Rigidbody2D rb;

    //public LayerMask ignoreLayer; //Define the layer to ignore collision with.

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerShield>().shield > 0)
            {
                other.gameObject.GetComponent<PlayerShield>().shield -= damage;
            }

            else if (other.gameObject.GetComponent<PlayerShield>().shield <= 0)
            {
                other.gameObject.GetComponent<playerHealth>().health -= damage;
            }
            //other.gameObject.GetComponent<playerHealth>().health -= damage;
            Destroy(gameObject);
        }


    }

    

}
