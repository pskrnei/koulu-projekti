using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;

    public playerHealth pHealth;
    public float damage;

    public float distanceToShoot = 5f;
    public float distanceToStop = 3f;

    public float fireRate;
    private float timeToFire;
    

    public Transform firingPoint;
    
    public AudioSource audioSource;
    public AudioClip shootingEnemy;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Enemy rotates
    private void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }        

        if (target != null && Vector2.Distance(target.position, transform.position) <= distanceToShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (timeToFire <= 0f)
        {
            audioSource.PlayOneShot(shootingEnemy);
            audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (target != null) 
        { 
            if (Vector2.Distance(target.position, transform.position) >= distanceToStop) 
            { 
            rb.velocity = transform.up * speed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void GetTarget()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            target = playerObject.transform;
        }
        else
        {
            // Pelaajaa ei l�ytynyt, joten tuhotaan t�m� vihollis-GameObject
            Destroy(gameObject);
        }
    }

    
    //v�l�hdyskoodi

    public SpriteRenderer sprite;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            StartCoroutine(FlashRed());
        }
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

}
