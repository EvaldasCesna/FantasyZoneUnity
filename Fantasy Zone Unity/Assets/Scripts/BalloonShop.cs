using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonShop : MonoBehaviour {

    public Canvas balloonPanel;
    public AudioSource shopMusic;
    public AudioSource returnMusic;
    public float betweenMovesTime;
    private float betweenMovesCount;
    public float toMoveTime;
    private float toMoveCount;
    private Rigidbody2D rig;
    private Vector2 mov;
    bool moving;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        balloonPanel = GameObject.Find("ShopCanvas_1").GetComponent<Canvas>();

    }

    private void Update()
    {
     //   shopMusic = GameObject.Find("ShopMusic").GetComponent<AudioSource>();
      //  returnMusic = GameObject.Find("BackRoundMusic").GetComponent<AudioSource>();
        movement();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            OpenShop();
    }
    
    void OpenShop()
    {
        balloonPanel.enabled = true;
        Time.timeScale = 0;
        shopMusic.Play();
        returnMusic.Stop();
    }
    
    public void CloseShop()
    {
        balloonPanel.enabled = false;

        Time.timeScale = 1;
        returnMusic.Play();
        shopMusic.Stop();
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, 1);
    }

    public void movement()
    {

        if (moving)
        {
            toMoveCount -= Time.fixedDeltaTime;
            rig.velocity = mov;
            if (toMoveCount < 0f)
            {
                moving = false;
                betweenMovesCount = Random.Range(betweenMovesTime * 0.75f, betweenMovesTime * 1.25f);
            }
        }
        else
        {
            betweenMovesCount -= Time.fixedDeltaTime;
            rig.velocity = Vector2.zero;
            if (betweenMovesCount < 0f)
            {
                moving = true;
                toMoveCount = Random.Range(toMoveTime * 0.75f, toMoveTime * 1.25f);
                mov = new Vector3(Random.Range(-1f, 1f), Random.Range(0, 0.2f) * 0.2f, 0);
            }
        }

    }

}
