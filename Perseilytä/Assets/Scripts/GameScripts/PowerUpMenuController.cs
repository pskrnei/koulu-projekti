using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMenuController : MonoBehaviour
{

    [SerializeField] GameObject powerUpMenu;
    [SerializeField] float fireRateBuff = 0.1f;
    [SerializeField] float damageBuff;
    [SerializeField] float bulletBuff;
    [SerializeField] float hpGiven;

    private void Start()
    {
     //   Player player= GetComponent<Player>();
    }


    public void togglePowerUpMenu()
    {
        powerUpMenu.SetActive(!powerUpMenu.activeSelf);
    }

    public void buffFirerate()
    {
        GameObject playerObject = GameObject.Find("Player");
        Player player = playerObject.GetComponent<Player>();
        player.fireRate -= fireRateBuff;
        
        powerUpMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void buffDamage()
    {
        gameObject.GetComponent<Player>().fireRate -= fireRateBuff;
        powerUpMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void buffBullets()
    { 
        gameObject.GetComponent<Player>().fireRate -= fireRateBuff;
        powerUpMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void buffHP()
    {
        gameObject.GetComponent<Player>().fireRate -= fireRateBuff;
        powerUpMenu.SetActive(false);
        Time.timeScale = 1;
    }

}
