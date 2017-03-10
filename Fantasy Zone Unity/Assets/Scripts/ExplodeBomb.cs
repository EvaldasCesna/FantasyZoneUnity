using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeBomb : MonoBehaviour {

    public GameObject explodePrefab;

    private void OnDestroy()
    {
        if (tag == "Bomb")
        {
            GameObject prefab = (GameObject)Instantiate(explodePrefab, transform.position, transform.rotation);
            Destroy(prefab, 0.1f);
        }

        if (tag == "FireBomb") {
            GameObject rightShot = (GameObject)Instantiate(explodePrefab, transform.position, transform.rotation);
            rightShot.GetComponent<Rigidbody2D>().velocity = new Vector3(1.5f, 0, 0);

            GameObject leftShot = (GameObject)Instantiate(explodePrefab, transform.position, transform.rotation);
            leftShot.transform.localRotation = Quaternion.Euler(0, 180, 0);
            leftShot.GetComponent<Rigidbody2D>().velocity = new Vector3(-1.5f, 0, 0);
        }
    }
}
