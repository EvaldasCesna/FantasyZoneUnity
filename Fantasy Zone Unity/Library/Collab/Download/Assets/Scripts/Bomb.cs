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
    public int currentWeapon;

	// Use this for initialization


	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButton("Fire2") && Time.time > nextFire && !GetComponent<HealthManager>().isdead)
        {
            nextFire = Time.time + upgrade[currentWeapon].fireRate;
            GameObject bomb = Instantiate(upgrade[currentWeapon].prefab, ShotSpawn.position, Quaternion.identity) as GameObject;

            if (GetComponent<PlayerMovement>().movHorizontal == 0)
            {
                bomb.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<PlayerMovement>().lastx, 0) * upgrade[currentWeapon].bombSpeed;
            }

            if (GetComponent<PlayerMovement>().movHorizontal != 0)
            {
                bomb.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<PlayerMovement>().movHorizontal, 0) * (upgrade[currentWeapon].bombSpeed + 0.5f);
            }
        }
    }
}
