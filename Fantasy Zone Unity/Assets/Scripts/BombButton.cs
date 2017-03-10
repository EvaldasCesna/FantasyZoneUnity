using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombButton : MonoBehaviour
{

    // Use this for initialization
    public Bomb playerShooting;
    public int weaponNumber;
    private int money;
    private AudioClip clip;
    public Image imge;
    bool sold;
    Text counter;
    void Start()
    {
        counter = GameObject.FindGameObjectWithTag("BombCounter").GetComponent<Text>();
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
        Bomb shootingScript = shooting.GetComponent<Bomb>();


        if (money >= playerShooting.upgrade[weaponNumber].cost && !sold)
        {
            playerScript.money -= playerShooting.upgrade[weaponNumber].cost;
            playerScript.updateMoney();
            shootingScript.currentBomb = weaponNumber;
            sold = true;
            imge.enabled = true;
            counter.text = "1";

        }//else
         //{
         //add AUDIO
         //}

    }

}
