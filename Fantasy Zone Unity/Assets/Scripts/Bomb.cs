using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public GameObject archBomb;
    public Transform ShotSpawn;
    
    public float bombSpeed;
    private float nextFire;
    public float fireRate;

    public BombUpgrade[] upgrade;
    public int currentBomb;
    private string text;
    PlayerSpawner game;
    // Use this for initialization
    void Start()
    {
        game = GameObject.FindGameObjectWithTag("Respawn").GetComponent<PlayerSpawner>();
    }


    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButton("Fire2") && Time.time > nextFire && !GetComponent<HealthManager>().isdead)
        {
            nextFire = Time.time + upgrade[currentBomb].fireRate;
     
            if (currentBomb == 2)
            {
                Instantiate(upgrade[currentBomb].prefab, new Vector2(ShotSpawn.position.x, 1), Quaternion.identity);
            }
            else
            {
                GameObject bomb = Instantiate(upgrade[currentBomb].prefab, ShotSpawn.position, Quaternion.identity) as GameObject;
                if (GetComponent<PlayerMovement>().movHorizontal == 0)
                {
                    bomb.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<PlayerMovement>().lastx, 0) * upgrade[currentBomb].bombSpeed;
                }

                if (GetComponent<PlayerMovement>().movHorizontal != 0)
                {
                    bomb.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<PlayerMovement>().movHorizontal, 0) * (upgrade[currentBomb].bombSpeed + 0.5f);
                }
            }
           counter();
        }
        updateText();
    }

    public void counter()
    {
        int count = 1;
        if (currentBomb >= 2)
        {
            count--;
            if (count <= 0)
            {
                count = 0;
                currentBomb = 0;
            }

        }
        if (currentBomb == 0 || currentBomb == 1)
        {
            game.updateBombCounter(" ");
        }

    }

    public void updateText()
    {
        if (currentBomb == 0)
        {
            text = "1.BOMB";
        }
        if (currentBomb == 1)
        {
            text = "2.BOMBS";
        }
        if (currentBomb == 2)
        {
            text = "HEAVY";
        }
        if (currentBomb == 3)
        {
            text = "SMART";
        }
        if (currentBomb == 4)
        {
            text = "FIRE";
        }
        game.setBombText(text);
    }

}
