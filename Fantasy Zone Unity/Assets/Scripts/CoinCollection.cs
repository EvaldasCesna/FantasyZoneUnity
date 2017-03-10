using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour {
    PlayerSpawner player;
    public int value = 0;
    public float timeToDisapear;
    private float disapearCount;
   // private bool onScreen;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Respawn").GetComponent<PlayerSpawner>();
        disapearCount = timeToDisapear;
    
    }
	
	// Update is called once per frame
	void Update () {

        disapearInTime();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.addMoney(value);
            Destroy(gameObject);
        }
    }

    public void setValue(int newValue)
    {
        value = newValue;
    }

    public void disapearInTime()
    {
        disapearCount -= Time.deltaTime;
        if (disapearCount < 0f)
        {
            Destroy(gameObject);
        }
        

    }

}
