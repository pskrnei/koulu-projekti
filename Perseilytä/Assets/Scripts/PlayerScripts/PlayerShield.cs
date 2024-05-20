using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShield : MonoBehaviour
{
    public playerHealth pHealth;
    //Shield
    public float shield;
    public float maxShield;
    public Image shieldBar;

    private float fillSpeed = 5f; // healthbarin/shieldin sulavaan liikkumiseen

    private bool isShield; //gameover UI juttu

    // Start is called before the first frame update
    void Start()
    {
        maxShield = shield;
    }

    // Update is called once per frame
    void Update()
    {
        float targetFillAmount = Mathf.Clamp(shield / maxShield, 0f, 1f);
        shieldBar.fillAmount = Mathf.Lerp(shieldBar.fillAmount, targetFillAmount, Time.deltaTime * fillSpeed); // sulavasti liikkuva palkki

        if (shield <= 0 && !isShield)
        {
            isShield = true;

            // Additional death-related actions can be added here
        }
        else if (gameObject.GetComponent<playerHealth>().health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
