using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RajaPilvet : MonoBehaviour
{
    
    Player player;
    
    
    
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void borderWarning()
    {
        // jos pelaajan x pos on 100 tai -100, n�yt� warning text
        // jos pelaajan y pos on 80 tai -80, n�yt� warning text
    }
}
