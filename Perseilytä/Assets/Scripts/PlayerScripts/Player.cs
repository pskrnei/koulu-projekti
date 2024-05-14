using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    //Bullet variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 1f)]
    [SerializeField] private float fireRate = 0.5f;

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
    [SerializeField] public float currentExp = 0f;
    [SerializeField] float nextLevelExp = 10f;
    [SerializeField] float level = 1f;
    public Image expBar;
    [SerializeField] private float fillSpeed = 5f; // fillspeed palkin sulavuuteen

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // exp bar koodi
        float targetFillAmount = Mathf.Clamp(currentExp / nextLevelExp, 0f, 1f);
        expBar.fillAmount = Mathf.Lerp(expBar.fillAmount, targetFillAmount, Time.deltaTime * fillSpeed); // näin palkin saa liikkumaan sulavasti

        

        if (currentExp >= nextLevelExp)
        {
            audioSource.PlayOneShot(levelUpAudioClip);
            currentExp = 0;
            level++;
            nextLevelExp *= 2;
        }
        
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

    private void Shoot()
    {
        audioSource.PlayOneShot(shootingAudioClip);
        audioSource.pitch = UnityEngine.Random.Range(1.8f, 2f); // randomoi ääntä hiukan ettei siitä tulis liian toistuva
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation); 
    }


    //välähdyskoodi

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