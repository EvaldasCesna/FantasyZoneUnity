using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Animator anim;
    public float speed;
    private Rigidbody2D rig;
    private Vector2 mov;
    public float lastx = 1;
    public float lasty;
    bool OnGround;
    bool isFlying;
    public float movHorizontal;
    float movVertical;
    public bool boss;
    public UpGradeObject[] upgrades;
    public int currentUpgrade = 0;


    // Use this for initialization
    void Start () {
      
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        boss = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>().bossSpawned;
        movHorizontal = Input.GetAxisRaw("Horizontal");

         movVertical = Input.GetAxisRaw("Vertical");
        updateAnimation();
        isFlying = (Mathf.Abs(movHorizontal) + Mathf.Abs(movVertical)) > 0 && transform.position.y >= -0.73;

        if (isFlying && !GetComponent<HealthManager>().isdead)
        {
            OnGround = false;
            anim.SetBool("OnGround", false);
            mov = new Vector2(movHorizontal, movVertical);

            movement();
            if (movHorizontal != 0 && !boss)
            {
                lastx = movHorizontal;
            }
            if (boss)
            {
                lastx = 1;
                lasty = movVertical;
            }

            rig.velocity = mov * upgrades[currentUpgrade].speed * Time.deltaTime;
        }
        else if (transform.position.y <= -0.73)
        {
            OnGround = true;
            anim.SetBool("OnGround", true);
            anim.SetFloat("Speed", 0f);
            movement();
        }
        else
        {
            anim.SetFloat("Speed", 0.5f);
            if(!boss)
            mov = new Vector2(lastx, 0);
            rig.velocity = mov * 20f * Time.deltaTime;

        }
        
    }

    //Movement 
    void movement()
    {
        anim = GetComponent<Animator>();
        mov = new Vector2(movHorizontal, movVertical);
        anim.SetFloat("Speed", 1f);
        if (movHorizontal == 0 && !boss)
        {
            if (lastx < 0)
            {
                anim.SetFloat("Speed", 0.5f);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                mov = new Vector2(lastx + 0.6f, movVertical);
                rig.velocity = mov * Time.deltaTime;
            }
            else if (lastx > 0)
            {
                anim.SetFloat("Speed", 0.5f);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                mov = new Vector2(lastx - 0.6f, movVertical);
                rig.velocity = mov * Time.deltaTime;
            }
            if (OnGround)
            {
                anim.SetFloat("Speed", 0f);
                mov = new Vector2(0, movVertical);
                rig.velocity = mov * 20f * Time.deltaTime;
            }
        }

        if (movHorizontal != 0 && !boss)
        {
  
            lastx = movHorizontal;
        }
        if (boss)
        {
            lastx = 1;
        }

        rig.velocity = mov * upgrades[currentUpgrade].speed * Time.deltaTime;

       
        if (lastx < 0 && !boss)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
 
    void updateAnimation()
    {

        if (currentUpgrade == 0)
        {
            anim.SetBool("HasBigWing", false);
            anim.SetBool("HasEnGin", false);
            anim.SetBool("HasEnGin2", false);
            anim.SetBool("HasRocket", false);
        }
        if (currentUpgrade == 1)
        {
            anim.SetBool("HasBigWing", true);
            anim.SetBool("HasEnGin", false);
            anim.SetBool("HasEnGin2", false);
            anim.SetBool("HasRocket", false);
        }
        if (currentUpgrade == 2)
        {
            anim.SetBool("HasBigWing", false);
            anim.SetBool("HasEnGin", true);
            anim.SetBool("HasEnGin2", false);
            anim.SetBool("HasRocket", false);
        }
        if (currentUpgrade == 3)
        {
            anim.SetBool("HasBigWing", false);
            anim.SetBool("HasEnGin", false);
            anim.SetBool("HasEnGin2", true);
            anim.SetBool("HasRocket", false);
        }
        if (currentUpgrade == 4)
        {
            anim.SetBool("HasBigWing", false);
            anim.SetBool("HasEnGin", false);
            anim.SetBool("HasEnGin2", false);
            anim.SetBool("HasRocket", true);
        }
    }
   
}
