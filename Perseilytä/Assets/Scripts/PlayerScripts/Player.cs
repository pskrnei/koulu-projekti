using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    //Bullet variables
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] public float fireRate = 1f;
    public float bulletDamage = 2f;

    private Rigidbody2D rb;
    private float mx;
    private float my;

    //
    private Vector2 mousePos;
    //

    private float fireTimer;

    //pelaajan audiot
    public AudioSource audioSource;
    public AudioClip shootingAudioClip;
    public AudioClip levelUpAudioClip;

    //Exp variablet
    [SerializeField] public float currentExp = 0;
    [SerializeField]
    int[] expToNextLevel = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, // 1 - 10
    /*array levu exp vaatimuksiin*/           110, 120, 130, 140, 150, 160, 170, 180, 190, 200, // 11 - 20
                                              210, 220, 230, 240, 250, 260, 270, 280, 290, 300, // 21 - 30
                                              310, 320, 330, 340, 350, 360, 370, 380, 390, 400, // 31 - 40
                                              410, 420, 430, 440, 450, 460, 470, 480, 490, 500};// 41 - 50
    
    
    [SerializeField] int level = 1;
    public Image expBar;
    [SerializeField] private float fillSpeed = 5f; // fillspeed palkin sulavuuteen
    
    [SerializeField] GameObject powerUpMenu;
    private Player player;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        // exp bar koodi
        float targetFillAmount = Mathf.Clamp(currentExp / expToNextLevel[level - 1], 0f, 1f);
        expBar.fillAmount = Mathf.Lerp(expBar.fillAmount, targetFillAmount, Time.deltaTime * fillSpeed); // noin palkin saa liikkumaan sulavasti
        levelUp();
        

        if (Input.GetMouseButton(0) && fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(mx, my).normalized * speed;
    }


    private void levelUp()
    {
     if (currentExp >= expToNextLevel[level - 1])
            {
                Time.timeScale = 0;
                audioSource.PlayOneShot(levelUpAudioClip);
                currentExp = 0;
                level++;
                powerUpMenu.SetActive(true);
            }
    }


    private void Shoot()
    {
        audioSource.PlayOneShot(shootingAudioClip);
        // audioSource.pitch = UnityEngine.Random.Range(1.8f, 2f);  aanen randomointiin, mutta toi rikkoo levelup soundin pitchin
        
        GameObject Bullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
        Bullet_ bulletScript = Bullet.GetComponent<Bullet_>();
        bulletScript.initializeDamage(player.bulletDamage);
    }

    
    //valahdyskoodi
    public SpriteRenderer playerSprite;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            StartCoroutine(FlashRed());
        }
    }

    public IEnumerator FlashRed()
    {
        playerSprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        playerSprite.color = Color.white;
    }
}