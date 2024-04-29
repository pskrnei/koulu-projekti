using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eBullet_ : MonoBehaviour
{
    public EnemyHealth pHealth;
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
        /*foreach (Collider2D collider in GetComponents<Collider2D>())
        {
            Physics2D.IgnoreLayerCollision(gameObject.layer, ignoreLayer, true);
        }*/
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playerHealth>().health -= damage;
        }

        //Destroy(gameObject);

    }

    

}
