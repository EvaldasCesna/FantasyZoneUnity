using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraLifeButton : MonoBehaviour
{

    // Use this for initialization
    public PlayerSpawner playerSpawner;
    private int money;
    private AudioClip clip;
    public int ExtraLifeCost =2500;
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


        if (money >= ExtraLifeCost &&  playerScript.lives < playerScript.maxLives && !sold )
        {
            playerScript.money -= ExtraLifeCost;
            playerScript.updateMoney();
            playerScript.lives++;
            sold = true;
            imge.enabled = true;


        }//else
         //{
         //add AUDIO
         //}

    }

}


