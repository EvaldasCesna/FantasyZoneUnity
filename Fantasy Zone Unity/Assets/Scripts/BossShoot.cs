using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour {

    public GameObject shot;
    public Transform shotPosition;
    Animator anim;
    public float speed;
    public int numberOfShots;
    private float nextFire;
    public float fireRate;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        shoot();
      //  finishedshooting = false;
    }

    void shoot()
    {
        anim.SetBool("isShooting", false);
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            anim.SetBool("isShooting", true);
            for (int i = 0; i < numberOfShots; i++)
            {
                GameObject shots = (GameObject)Instantiate(shot, shotPosition.transform.position, shot.transform.rotation);
                shots.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(0f, -1f), Random.Range(-0.6f, 0.6f), 0) * speed;
            }
        }

    }
}
