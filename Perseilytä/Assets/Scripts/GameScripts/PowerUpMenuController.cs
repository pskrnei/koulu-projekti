using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpMenuController : MonoBehaviour
{

    [SerializeField] GameObject powerUpMenu;
    [SerializeField] float fireRateBuff = 0.1f;
    [SerializeField] float damageBuff = 2f;
    [SerializeField] float bulletBuff;
    [SerializeField] float hpGiven;

    private int fireRateBuffAmount = 0;
    private int damageBuffAmount = 0;
    private int bulletBuffAmount = 0;
    private int hpBuffAmount = 0;
    private Player player;

    [SerializeField] Button bulletUpgradeButton;
    [SerializeField] private Text feedbackText;

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
        bulletBuffAmount++;
        
        if(bulletBuffAmount >= 3)
        {
            bulletUpgradeButton.interactable = false;
           // feedbackText.Text = "maximum bulletcount upgrade reached";
        }

        switch (bulletBuffAmount)
        {
            case 1:
            {
                player.enableDoubleShot();
                break;
            }
            case 2:
            {
                player.enableTripleShot();
                break;
            }
            case 3:
            {
                player.enableQuadrupleShot();
                break;
            }
        }
        
        powerUpMenu.SetActive(false);
        Time.timeScale = 1;
        
    }

    public void buffHP()
    {
        gameObject.GetComponent<Player>().fireRate -= fireRateBuff;
        powerUpMenu.SetActive(false);
        Time.timeScale = 1;
        hpBuffAmount++;
    }

}
