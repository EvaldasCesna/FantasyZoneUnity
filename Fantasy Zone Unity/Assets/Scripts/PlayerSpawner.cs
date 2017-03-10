using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour {
    public int lives;
    public int maxLives = 5;
    public GameObject player;
    GameObject newPlayer;
    GameObject[] livespanel;
    public GameObject deathparticles;
    public GameObject shop;
    Text weaponText;
    Text bombText;
    Text scoreText;
    Text coinText;
    Text weaponTimer;
    Text bombCounter;
    public int score;
    public int money;
    bool isrespawning = false;
    bool boss = false;
    bool spawnedShop = false;
    // Use this for initialization
    void Start () {
        shop = GameObject.FindGameObjectWithTag("Shop");
        weaponTimer = GameObject.FindGameObjectWithTag("WeaponTimer").GetComponent<Text>();
        bombCounter = GameObject.FindGameObjectWithTag("BombCounter").GetComponent<Text>();
        weaponText = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Text>();
        bombText = GameObject.FindGameObjectWithTag("Bomb").GetComponent<Text>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        coinText = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();
        livespanel = GameObject.FindGameObjectsWithTag("Lives");
        score = 0;
        updateScore();
        newPlayer = (GameObject)Instantiate(player, transform.position, transform.rotation);
        Camera.main.GetComponent<CameraContoller>().player = newPlayer;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //If player dies spawn a new one and take away life
        spawnShop();
        if (newPlayer.GetComponent<HealthManager>().currentHealth == 0)
        {
            Instantiate(deathparticles, newPlayer.transform.position, transform.rotation);
        }
        if (newPlayer.GetComponent<HealthManager>().isdead)
        {
            isrespawning = true;
            newPlayer.GetComponent<HealthManager>().currentHealth = 1;
       
            Invoke("respawn", 2f);
        }

        for (int i = 0; i < maxLives; i++)
        {
            livespanel[i].SetActive(false);
        }

        for (int i = 0; i < lives - 1; i++)
        {
            livespanel[i].SetActive(true);
        }
    }

   void respawn()
    {
        if (isrespawning && lives != 0)
        {
            lives--;
            boss = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>().bossSpawned;
            if (!boss)
            {
                newPlayer = (GameObject)Instantiate(player, transform.position, transform.rotation);
            }
            else
            {
                newPlayer = (GameObject)Instantiate(player, GameObject.FindGameObjectWithTag("PlayerBossSpawn").transform.position, transform.rotation);
            }
            Camera.main.GetComponent<CameraContoller>().player = newPlayer;
            isrespawning = false;
            spawnedShop = false;
        }
        if (lives == 0)
        {
            SceneManager.LoadScene("TitleScreen");
        }
     
    }

    void spawnShop()
    {
        if (!spawnedShop)
        {
            if (money > 1000 && money < 9000)
            {
                shop.transform.position = new Vector2(newPlayer.transform.position.x, newPlayer.transform.position.y + 0.8f);
                spawnedShop = true;
            }
        }
    }


    public void addScore(int newScore)
    {
        score += newScore;
        updateScore();
    }
     void updateScore()
    {
        scoreText.text = score.ToString();
    }

    public void addMoney(int newMoney)
    {
        money += newMoney;
        updateMoney();
    }
    public void updateMoney()
    {
        coinText.text = money.ToString();
    }

    public void setWeaponText(string weapon)
    {
        weaponText.text = weapon;
    }

    public void setBombText(string bomb)
    {
        bombText.text = bomb;
    }

    public void updateWeaponTimer(string time)
    {
        weaponTimer.text = time;
    }

    public void updateBombCounter(string count)
    {
        bombCounter.text = count;
    }

}
