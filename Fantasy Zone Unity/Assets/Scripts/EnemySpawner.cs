using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    public List<GameObject> enemies;
    List<GameObject> bases;
    public GameObject bossPrefab;
    public bool bossSpawned = false;
    public AudioSource bossTheme;
    public AudioSource returnMusic;
    // Use this for initialization
    void Start () {

        InvokeRepeating("spawnEnemy", 2,2);
    }
	
	// Update is called once per frame
	void Update () {
      //  bases.Equals();
        CheckBases();
        //Comment
    }

    void CheckBases()
    {
        if (GameObject.FindGameObjectsWithTag("EnemyBase").Length == 0)
        {
            CancelInvoke("spawnEnemy");
            spawnBoss();
        }
    }

    void spawnBoss()
    {
        if (bossSpawned == false)
        {
            Instantiate(bossPrefab, GameObject.FindGameObjectWithTag("BossSpawn").transform.position, transform.rotation);
            bossSpawned = true;
            bossTheme.PlayDelayed(2);
            returnMusic.Stop();

    GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("PlayerBossSpawn").transform.position;
        }

    }

    void spawnEnemy()
    {

        int i = Random.Range(0, enemies.Count);
        Transform location = enemies[i].GetComponent<EnemyController>().updateSide();

        //Movement Rules for different Enemies
        //Enemy Syasaya
        if (i == 0)
        {

            for (float j = 0; j < 2; j++)
            {
                GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, 0, transform.position.z), enemies[i].transform.rotation);
                spawned.transform.position = new Vector3(location.position.x + (j * 0.4f) + 0.4f, 0.3f, enemies[i].transform.position.z);
            }
            for (float j = 0; j < 2; j++)
            {
                GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, 0, transform.position.z), enemies[i].transform.rotation);
                spawned.transform.position = new Vector3(location.position.x + (j * 0.4f) + 0.2f, 0, enemies[i].transform.position.z);
            }
            for (float j = 0; j < 2; j++)
            {
                GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, 0, transform.position.z), enemies[i].transform.rotation);
                spawned.transform.position = new Vector3(location.position.x + (j * 0.4f), -0.3f, enemies[i].transform.position.z);
            }

        }
        //Enemy Sousan
        if (i == 1)
        {
            int type = Random.Range(0, 4);
            if (type == 1)
            {
                float yMax = Camera.main.orthographicSize - 0.8f;
                float range = Random.Range(-yMax, yMax);

                for (float j = 0; j < 3; j++)
                {
                    GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, range, transform.position.z), enemies[i].transform.rotation);

                    spawned.transform.position = new Vector3(location.position.x - (j * 0.3f), range, enemies[i].transform.position.z);
                }
                for (float j = 0; j < 3; j++)
                {
                    GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, range - 1f, transform.position.z), enemies[i].transform.rotation);

                    spawned.transform.position = new Vector3(location.position.x - (j * 0.3f), range - 0.2f, enemies[i].transform.position.z);
                }
            }
            if (type == 2)
            {
                float yMax = Camera.main.orthographicSize - 0.6f;

                for (float j = 0; j < 3; j++)
                {
                    GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, yMax, transform.position.z), enemies[i].transform.rotation);

                    spawned.transform.position = new Vector3(location.position.x - (j * 0.3f), yMax, enemies[i].transform.position.z);
                }
                for (float j = 0; j < 3; j++)
                {
                    GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, -yMax, transform.position.z), enemies[i].transform.rotation);

                    spawned.transform.position = new Vector3(location.position.x - (j * 0.3f), -yMax, enemies[i].transform.position.z);
                }
            }
            if (type == 3)
            {
                for (float j = 0; j < 5; j++)
                {
                    GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, 0.1f, transform.position.z), enemies[i].transform.rotation);

                    spawned.transform.position = new Vector3(location.position.x - (j * 0.2f), 0.1f, enemies[i].transform.position.z);
                }
            }
        }
        //Enemy Mukoron
        if (i == 2)
        {
            int type = Random.Range(0, 3);

            if (type == 1)
            {
                for (float j = 0; j < 2; j++)
                {
                    GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, 0.1f, transform.position.z), enemies[i].transform.rotation);

                    spawned.transform.position = new Vector3(location.position.x - (j * 0.2f), 0.5f, enemies[i].transform.position.z);
                }
                for (float j = 0; j < 2; j++)
                {
                    GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, 0.1f, transform.position.z), enemies[i].transform.rotation);

                    spawned.transform.position = new Vector3(location.position.x - (j * 0.2f), 0.3f, enemies[i].transform.position.z);
                }
            }
            if (type == 2)
            {
                for (float j = 0; j < 4; j++)
                {
                    GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, 0.1f, transform.position.z), enemies[i].transform.rotation);

                    spawned.transform.position = new Vector3(location.position.x, 0.6f - (j * 0.35f), enemies[i].transform.position.z);
                }
            }

        }
        //Enemy Bottako
        if (i == 3)
        {
            int type = Random.Range(0, 3);

            if (type == 1)
            {
                GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, 0.1f, transform.position.z), enemies[i].transform.rotation);

                spawned.transform.position = new Vector3(location.position.x, 0.6f, enemies[i].transform.position.z);

                GameObject spawned2 = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x *2f, 0.1f, transform.position.z), enemies[i].transform.rotation);

                spawned2.transform.position = new Vector3(location.position.x - (location.position.x), 0.6f, enemies[i].transform.position.z);


            }
            if (type == 2)
            {
                for (float j = 0; j < 4; j++)
                {
                    GameObject spawned = (GameObject)Instantiate(enemies[i], new Vector3(transform.position.x, 0.1f, transform.position.z), enemies[i].transform.rotation);

                    spawned.transform.position = new Vector3(location.position.x, 1f - (j * 0.2f), enemies[i].transform.position.z);
                }
            }


        }
    }
}
