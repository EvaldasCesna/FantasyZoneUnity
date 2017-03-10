using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombUpgrade : ScriptableObject {

    public string bombName = "Bomb Name";
    public int cost = 2000;

    public GameObject prefab;
    public int counter = 1;
    public float bombSpeed;
    public float fireRate;

}
