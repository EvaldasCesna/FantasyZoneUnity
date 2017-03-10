using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

    Renderer[] renderers;
    private bool seen = false;
	// Use this for initialization
	void Start () {

        renderers = GetComponentsInChildren<Renderer>();
	}

    void FixedUpdate()
    {
        DeleteOffScreen();
    }

    void DeleteOffScreen()
    {
        seen = CheckRenders();
        //if the bullet is not visible destroy it
        if(!seen)
        {
            Destroy(gameObject);
        }

    }

    bool CheckRenders()
    {
        foreach(Renderer renderer in renderers)
        {
            if (renderer.isVisible)
            {
                return true;
            }
        }
        return false;
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.tag == "SmartBomb" || this.gameObject.tag == "HeavyBomb" || this.gameObject.tag == "FireShot")
        {

        }
        else
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBase" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "Ground")
            {
                Destroy(gameObject);
                
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.gameObject.tag == "HeavyBomb" || this.gameObject.tag == "FireShot")
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.gameObject.tag == "HeavyBomb")
        {

        }
    }
}
