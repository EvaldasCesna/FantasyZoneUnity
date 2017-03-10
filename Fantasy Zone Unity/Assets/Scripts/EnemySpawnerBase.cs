using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerBase : MonoBehaviour {

    public GameObject enemy;

    // Use this for initialization
    void Start () {

    }


    void spawnEnemy()
    {
        GameObject spawned = (GameObject)Instantiate(enemy, transform.position, transform.rotation);
        spawned.transform.position = this.transform.position;

    }

    private void OnBecameVisible()
    {
        int min = Random.Range(0, 3);
        int max = Random.Range(5, 7);
        InvokeRepeating("spawnEnemy", min, max);
    }

    private void OnBecameInvisible()
    {
        CancelInvoke("spawnEnemy");
    }


}
