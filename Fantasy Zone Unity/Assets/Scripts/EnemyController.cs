using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyController : MonoBehaviour
{

    private Rigidbody2D rig;
    private GameObject player;
    private Vector2 mov;
    private HealthManager health;
    private PlayerSpawner playerspawner;
    private bool moving;

    public Transform enemySpawn;
    public GameObject coin;
    public float speed;
    public float movY;
    public float movX;

    public float betweenMovesTime;
    private float betweenMovesCount;
    public float toMoveTime;
    private float toMoveCount;
    public bool flips;
    public bool spawnsFromBase;
    public bool isBoss;
    public float maxSpeed;
    bool dropped = false;
   

    // Use this for initialization
    void Start()
    {
        playerspawner = GameObject.FindGameObjectWithTag("Respawn").GetComponent<PlayerSpawner>();
        health = GetComponent<HealthManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        // mov = new Vector2(-1, 0);
        if (tag == "Enemy")
        {
            updateSide();
        }
        rig = GetComponent<Rigidbody2D>();
        // InvokeRepeating("movemement", 1 ,1);
        betweenMovesCount = betweenMovesTime;
        toMoveCount = toMoveTime;

        if (spawnsFromBase)
        {
            switchSide();
            rig.velocity = new Vector2(0, -1f) * speed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // updateSide();
        dropCoinAddScore();

    }

    private void FixedUpdate()
    {
        if (!isBoss)
            movement();
        else
            bossMovement();

        if(health.isdead && tag == "Boss")
        {
            endgame();
        }
    }

    void OnBecameInvisible()
    {
        if (tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }


    public Transform updateSide()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<PlayerMovement>().lastx >= 0)
        {
            enemySpawn = GameObject.FindGameObjectWithTag("EnemySpawnR").transform;
            mov.x = -1;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            return enemySpawn;
        }
        else
        {
            enemySpawn = GameObject.FindGameObjectWithTag("EnemySpawnL").transform;
            mov.x = 1;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            return enemySpawn;
        }

    }

    public void movement()
    {
        rig = GetComponent<Rigidbody2D>();
        //mov = new Vector2(mov.x, 0);
        // rig.velocity = mov * speed * Time.deltaTime;

        if (moving)
        {
            toMoveCount -= Time.fixedDeltaTime;
            rig.velocity = mov * speed * Time.deltaTime;
            if (toMoveCount < 0f)
            {
                mov = new Vector2(mov.x, movY);
                moving = false;
                betweenMovesCount = betweenMovesTime;
                rig.velocity = mov * speed * Time.deltaTime;
            }
        }
        else
        {
            betweenMovesCount -= Time.fixedDeltaTime;

            if (betweenMovesCount < 0f)
            {
                if (flips)
                {
                    switchSide();
                }
                moving = true;
                toMoveCount = toMoveTime;
                if ((mov.x > 0 && mov.x < maxSpeed) || (mov.x < 0 && mov.x > -maxSpeed))
                {
                    mov = new Vector2(mov.x * movX, -movY);
                }
                else
                {
                    mov = new Vector2(mov.x, -movY);
                    if (flips)
                    {
                        mov.x = -mov.x * 1.2f;
                        mov = new Vector2(mov.x, 3);
                    }
                }
                rig.velocity = mov * speed * Time.deltaTime;
                
            }

        }
    }

    public void bossMovement()
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
                mov = new Vector3(movX, Random.Range(-player.GetComponent<PlayerMovement>().lasty, player.GetComponent<PlayerMovement>().lasty) * speed, 0);
            }
        }

    }

    public void switchSide()
    {
        if (mov.x > 0)
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if (mov.x < 0)
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        //mov = new Vector2(-mov.x, -mov.y);
    }

    public void dropCoinAddScore()
    {
        if (health.isdead && !dropped)
        {
            if (tag == "Enemy")
            {
                playerspawner.addScore(100);
                int luck = Random.Range(0, 10);
                if (luck == 1)
                {
                    GameObject droppedCoin = (GameObject)Instantiate(coin, transform.position, transform.rotation);
                    droppedCoin.AddComponent<CoinCollection>();
                    droppedCoin.GetComponent<CoinCollection>().setValue(100);
                    droppedCoin.GetComponent<CoinCollection>().timeToDisapear = 7f;
                }
            }
            if (tag == "EnemyBase")
            {
                playerspawner.addScore(1000);
                GameObject droppedCoin = (GameObject)Instantiate(coin, transform.position, transform.rotation);
                droppedCoin.AddComponent<CoinCollection>();

                int luck = Random.Range(0, 2);
                if (luck == 1)
                {
                    droppedCoin.transform.localScale = new Vector2(1.5f, 1.5f);
                    droppedCoin.GetComponent<CoinCollection>().setValue(1000);
                    droppedCoin.GetComponent<CoinCollection>().timeToDisapear = 10f;
                }
                else
                    droppedCoin.GetComponent<CoinCollection>().setValue(100);
                droppedCoin.GetComponent<CoinCollection>().timeToDisapear = 7f;
            }
            if (tag == "Boss")
            {
                playerspawner.addScore(10000);
                for (int i = 0; i < 20; i++)
                {
                    GameObject droppedCoin = (GameObject)Instantiate(coin, transform.position, transform.rotation);
                    droppedCoin.AddComponent<CoinCollection>();

                    int luck = Random.Range(0, 2);
                    if (luck == 1)
                    {
                        droppedCoin.transform.localScale = new Vector2(1.5f, 1.5f);
                        droppedCoin.GetComponent<CoinCollection>().setValue(1000);
                        droppedCoin.GetComponent<CoinCollection>().timeToDisapear = 10f;
                    }
                    else
                        droppedCoin.GetComponent<CoinCollection>().setValue(100);
                    droppedCoin.GetComponent<CoinCollection>().timeToDisapear = 7f;
                
                }
                endgame();

            }
            dropped = true;
        }

    }

    public void endgame()
    {
        SceneManager.LoadScene("TitleScreen");
    }

}
