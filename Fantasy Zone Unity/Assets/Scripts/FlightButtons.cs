using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlightButtons : MonoBehaviour
{

    // Use this for initialization
    public PlayerMovement playerShooting;
    public int weaponNumber;
    private int money;
    private AudioClip clip;
    public Image imge;
    bool sold;
    void Start()
    {

        //AudioSource audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {

        GameObject player = GameObject.Find("PlayerSpawner");
        PlayerSpawner playerScript = player.GetComponent<PlayerSpawner>();
        money = playerScript.money;

        GameObject shooting = GameObject.FindGameObjectWithTag("Player");
        PlayerMovement shootingScript = shooting.GetComponent<PlayerMovement>();


        if (money >= playerShooting.upgrades[weaponNumber].cos && !sold)
        {
            playerScript.money -= playerShooting.upgrades[weaponNumber].cos;
            playerScript.updateMoney();
            shootingScript.currentUpgrade = weaponNumber;
            imge.enabled = true;
            sold = true;

        }//else
         //{
         //add AUDIO
         //}

    }

}
