using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_ : MonoBehaviour
{
    public EnemyHealth pHealth;
    public float damage = 1f;

    [Range(1, 10)]
    [SerializeField] private float speed = 20f;

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth>().health -= damage;
        }

        

    }

    

}
