using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

    public int damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //Hurt the enemy for damage specified
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBase" || collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<HealthManager>().takeDamage(damage);


        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBase" ||  collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<HealthManager>().takeDamage(damage);

        }
    }

}
