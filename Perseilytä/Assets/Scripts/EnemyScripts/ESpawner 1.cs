using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESpawner : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    private float spawnRateMin = 1f; // Minimi spawnRate
    private float spawnRateMax = 5f; // Maksimi spawnRate
    private float timer = 0;
    public float widthOffset = 10;
    public float heightOffset = 10;
    private float leftPoint;
    private float rightPoint;
    private float upPoint;
    private float downPoint;
    public float enemy1Probability = 0.3f; // Esimerkkiarvo
    public float enemy2Probability = 0.4f; // Esimerkkiarvo
    public float enemy3Probability = 0.3f; // Esimerkkiarvo
    public float minSpeed = 2f; // Esimerkkiarvo
    public float maxSpeed = 10f; // Esimerkkiarvo

    // Start is called before the first frame update
    void Start()
    {
        // M‰‰rit‰ pelialueen leveys
        float halfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        float halfHeight = Camera.main.aspect * Camera.main.orthographicSize;

        leftPoint = transform.position.x - halfWidth;
        rightPoint = transform.position.x + halfWidth;
        downPoint = transform.position.y - halfHeight;
        upPoint = transform.position.y + halfHeight;

        // Aseta spawnRate satunnaisesti v‰lille 1 ja 5
        SetRandomSpawnRate();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (timer < spawnRateMin)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                SpawnEnemy();
                timer = 0;

                // Aseta uusi satunnainen spawnRate
                SetRandomSpawnRate();
            }
        }
    }

    // Aseta uusi satunnainen spawnRate v‰lille spawnRateMin ja spawnRateMax
    void SetRandomSpawnRate()
    {
        spawnRateMin = Random.Range(1f, 1.1f);
        spawnRateMax = spawnRateMin;
    }

    void SpawnEnemy()
    {
        // Generoi satunnainen todenn‰kˆisyysarvo v‰lilt‰ 0 ja 1
        float randomProb = Random.Range(0f, 1f);

        // Generoi satunnainen x- ja y-koordinaatti
        float spawnX = Random.Range(leftPoint, rightPoint);
        float spawnY = Random.Range(upPoint, downPoint);

        // Luo spawnPosition satunnaisen kohdan ymp‰rille
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0);

        // Valitse vihollistyyppi satunnaisen todenn‰kˆisyysarvon perusteella
        GameObject enemyToSpawn = null;
        float enemy1Threshold = enemy1Probability;
        float enemy2Threshold = enemy1Threshold + enemy2Probability;
        float enemy3Threshold = enemy2Threshold + enemy3Probability;

        if (randomProb < enemy1Threshold)
        {
            enemyToSpawn = Enemy1;
        }
        else if (randomProb < enemy2Threshold)
        {
            enemyToSpawn = Enemy2;
        }
        else if (randomProb < enemy3Threshold)
        {
            enemyToSpawn = Enemy3;
        }

        // Luo vihollinen ja aseta nopeus
        GameObject enemy = Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * Random.Range(minSpeed, maxSpeed);
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found!");
        }

        // Aseta viholliselle elinaika
        float enemyLifetime = 60f; // Aseta elinaika haluamaksesi
        Destroy(enemy, enemyLifetime); // Tuhotaan vihollinen enemyLifetime sekunnin kuluttua
    }
}
