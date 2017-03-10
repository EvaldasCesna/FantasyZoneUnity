using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponUpGrade : ScriptableObject {

    public string weaponName = "Weapon Name";
    public int cost = 50;
    public GameObject prefab;
   
    public int timer = 20;
    public float shotSpeed = 20;
    public float fireRate = 0;


}
