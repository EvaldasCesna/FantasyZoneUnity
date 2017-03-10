using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponButtons : MonoBehaviour {

    // Use this for initialization
    public PlayerShooting playerShooting;
    public int weaponNumber;
    private int money;
    private AudioClip clip;
    public Image imge;
    bool sold;
    Text timer;
    void Start () {
        timer = GameObject.FindGameObjectWithTag("WeaponTimer").GetComponent<Text>();
        //AudioSource audio = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {

        GameObject player = GameObject.Find("PlayerSpawner");
        PlayerSpawner playerScript = player.GetComponent<PlayerSpawner>();
        money = playerScript.money;

        GameObject shooting = GameObject.FindGameObjectWithTag("Player");
        PlayerShooting shootingScript = shooting.GetComponent<PlayerShooting>();
        

        if (money >= playerShooting.upgrades[weaponNumber].cost && !sold)
        {
            playerScript.money -= playerShooting.upgrades[weaponNumber].cost;
            playerScript.updateMoney();
            shootingScript.currentWeapon = weaponNumber;
            imge.enabled = true;
            sold = true;
            timer.text = "60";
        }//else
         //{
         //add AUDIO
         //}

    }

}
