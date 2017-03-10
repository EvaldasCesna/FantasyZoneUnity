using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject shot;
    public Transform shotSpawn;
    public float shotSpeed;
   
    public float fireRate;
    private float nextFire;

    public WeponUpGrade[] upgrades;
    public int currentWeapon;
    string text;
    PlayerSpawner game;

    // Use this for initialization
    void Start () {
        game = GameObject.FindGameObjectWithTag("Respawn").GetComponent<PlayerSpawner>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextFire && !GetComponent<HealthManager>().isdead)
        {
            nextFire = Time.time + upgrades[currentWeapon].fireRate;
            GameObject bullet = (GameObject)Instantiate(upgrades[currentWeapon].prefab, shotSpawn.position, shotSpawn.rotation);
            bullet.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<PlayerMovement>().lastx, 0) * upgrades[currentWeapon].shotSpeed * Time.deltaTime;
            GetComponent<AudioSource>().Play();

            if (currentWeapon == 1)
            {
                GameObject bullet2 = (GameObject)GameObject.Instantiate(upgrades[currentWeapon].prefab, shotSpawn.position, shotSpawn.rotation);
                GameObject bullet3 = (GameObject)GameObject.Instantiate(upgrades[currentWeapon].prefab, shotSpawn.position, shotSpawn.rotation);
                GameObject bullet4 = (GameObject)GameObject.Instantiate(upgrades[currentWeapon].prefab, shotSpawn.position, shotSpawn.rotation);
                GameObject bullet5 = (GameObject)GameObject.Instantiate(upgrades[currentWeapon].prefab, shotSpawn.position, shotSpawn.rotation);
                GameObject bullet6 = (GameObject)GameObject.Instantiate(upgrades[currentWeapon].prefab, shotSpawn.position, shotSpawn.rotation);
                GameObject bullet7 = (GameObject)GameObject.Instantiate(upgrades[currentWeapon].prefab, shotSpawn.position, shotSpawn.rotation);

                bullet2.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<PlayerMovement>().lastx, 0.2f) * (shotSpeed- 50f )* Time.deltaTime;
                bullet3.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<PlayerMovement>().lastx, -0.2f) * (shotSpeed - 50f) * Time.deltaTime;
                bullet4.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<PlayerMovement>().lastx, 0.4f) * (shotSpeed - 100f) * Time.deltaTime;
                bullet5.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<PlayerMovement>().lastx, -0.4f) * (shotSpeed- 100f) * Time.deltaTime;
                bullet6.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<PlayerMovement>().lastx, 0.8f) * (shotSpeed- 159f) * Time.deltaTime;
                bullet7.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.GetComponent<PlayerMovement>().lastx, -0.8f) * (shotSpeed- 150f) * Time.deltaTime;
            }


        }
        updateText();
        countdown();

    }

    public void countdown()
    {
        float count = 60;
        if (currentWeapon != 0)
        {
            count -= Time.time;
            count = (int)count;
            game.updateWeaponTimer(count.ToString());
            if (count < 0)
            {
                currentWeapon = 0;
                game.updateWeaponTimer(" ");
            }
        }
        if (currentWeapon == 0)
        {
            game.updateWeaponTimer(" ");
        }
    }

    public void updateText()
    {
        if (currentWeapon == 0)
        {
            text = "SHOT";
        }
        if (currentWeapon == 1)
        {
            text = "7.SHOT";
        }
        if (currentWeapon == 2)
        {
            text = "LASER";
        }
        if (currentWeapon == 3)
        {
            text = "WIDE";
        }
        game.setWeaponText(text);
    }
}





