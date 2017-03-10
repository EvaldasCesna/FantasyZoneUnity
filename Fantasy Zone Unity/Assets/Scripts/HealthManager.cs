using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    Animator anim;
    public bool isdead;

    // Use this for initialization
    void Start () {
   
        isdead = false;
        setMaxHealth();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0)
        {
            if (tag == "Enemy" || tag == "Boss" || tag == "EnemyBase")
            {
                isdead = true;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                anim.SetBool("isDead", isdead);
                

                Destroy(gameObject, 0.5f);
            }
            else if (this.tag == "Player")
            {
                isdead = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Destroy(gameObject, 3f);
                foreach (GameObject o in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    Destroy(o);
                }
                foreach (GameObject o in GameObject.FindGameObjectsWithTag("Bullets"))
                {
                    Destroy(o);
                }
            }
        }
	}


    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        GetComponent<AudioSource>().Play();
    }

    public void setMaxHealth()
    {
        currentHealth = maxHealth;
    }


}
