using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMenuController : MonoBehaviour
{

    [SerializeField] GameObject powerUpMenu;
    [SerializeField] float fireRateBuff = 0.1f;
    [SerializeField] float damageBuff = 2f;
    [SerializeField] float bulletBuff;
    [SerializeField] float hpGiven;

    [SerializeField] int fireRateBuffAmount = 0;
    [SerializeField] int damageBuffAmount = 0;
    [SerializeField] int bulletBuffAmount = 0;
    [SerializeField] int hpBuffAmount = 0;
    private Player player;

    private void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
        player = playerObject.GetComponent<Player>();
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
        fireRateBuffAmount++;
    }

    public void buffDamage()
    {
        player.bulletDamage += damageBuff;
        powerUpMenu.SetActive(false);
        Time.timeScale = 1;
        damageBuffAmount++;
    }

    public void buffBullets()
    { 
        player.enableDoubleShot();
        powerUpMenu.SetActive(false);
        Time.timeScale = 1;
        bulletBuffAmount++;
    }

    public void buffHP()
    {
        gameObject.GetComponent<Player>().fireRate -= fireRateBuff;
        powerUpMenu.SetActive(false);
        Time.timeScale = 1;
        hpBuffAmount++;
    }

}
