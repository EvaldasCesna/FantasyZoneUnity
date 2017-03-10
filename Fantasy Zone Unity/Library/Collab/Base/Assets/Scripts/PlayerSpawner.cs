using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour {
    public int lives;
    int maxLives = 5;
    public GameObject player;
    GameObject newPlayer;
    GameObject[] livespanel;
    public GameObject deathparticles;
    public float respawnTimer;
    

    // Use this for initialization
    void Start () {

        livespanel = GameObject.FindGameObjectsWithTag("Lives");
        newPlayer = (GameObject)Instantiate(player, transform.position, transform.rotation);
        Camera.main.GetComponent<CameraContoller>().player = newPlayer;
    }
	
	// Update is called once per frame
	void Update () {
		//If player dies spawn a new one and take away life
        
	}

    public void Respawn()
    {
        StartCoroutine(RespawnCo());
    }


    public IEnumerator RespawnCo()
    {
        if (newPlayer.GetComponent<HealthManager>().currentHealth <= 0)
        {
            lives--;


            Instantiate(deathparticles, newPlayer.transform.position, transform.rotation);
            yield return new WaitForSeconds(respawnTimer);

            newPlayer = (GameObject)Instantiate(player, transform.position, transform.rotation);
            Camera.main.GetComponent<CameraContoller>().player = newPlayer;
        }

        for (int i = 0; i < maxLives; i++)
        {
            livespanel[i].SetActive(false);
        }

        for (int i = 0; i < lives; i++)
        {
            livespanel[i].SetActive(true);
        }

    }

}
