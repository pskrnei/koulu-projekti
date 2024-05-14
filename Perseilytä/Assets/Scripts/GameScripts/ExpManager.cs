using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExpManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip collectGemClip;

    [SerializeField] float Exp; // exp m‰‰r‰ jonka gem antaa

    
    // lis‰‰ pelaajalle gemin antaman exp:n
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collectGemClip, transform.position, 0.3f); // float lopussa s‰‰t‰‰ volumea
            collision.gameObject.GetComponent<Player>().currentExp += Exp;
            Destroy(gameObject);
        }
    }



}
