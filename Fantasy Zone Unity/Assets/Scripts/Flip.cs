using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flip : MonoBehaviour {

    //private bool facingRight = true;
    private SpriteRenderer spritee;
    public float lastx;

    // Use this for initialization
	void Awake () {

        spritee = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        lastx = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().lastx;
       
      

        if (lastx < 0)
            spritee.flipX = true;
        else if (lastx > 0)
            spritee.flipX = false;
    }



}
