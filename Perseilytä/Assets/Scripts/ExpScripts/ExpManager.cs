using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExpManager : MonoBehaviour
{

    private float maxExp;
    private float neededExpForLevelUp;

    [SerializeField] float Exp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().currentExp =+ Exp;
            Destroy(gameObject);
        }
    }



}
