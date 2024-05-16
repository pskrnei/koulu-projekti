using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExpManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip collectGemClip;
    private float maxExp;
    private float neededExpForLevelUp;

    [SerializeField] float Exp;


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
