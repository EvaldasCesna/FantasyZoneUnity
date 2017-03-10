using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour {

    public GameObject player;
    private Vector3 playerPos;
    public float movSpeed;
    private float distanceAhead;

    public BoxCollider2D cameraBounds;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera cam;
    private float hHeight;
    private float hWidth;

    public GameObject leftTp;
    public GameObject rightTp;



	// Use this for initialization
	void Start () {
     

        minBounds = cameraBounds.bounds.min;
        maxBounds = cameraBounds.bounds.max;

        cam = GetComponent<Camera>();
        hHeight = cam.orthographicSize;
        hWidth = hHeight * Screen.width / Screen.height;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Depending on what direction the player is looking look ahead with the camera in that direction
        if (player.GetComponent<PlayerMovement>().lastx > 0)
        {
            distanceAhead = 1f;
        }
        else if (player.GetComponent<PlayerMovement>().lastx < 0)
        {
            distanceAhead = -1f;
        }

        playerPos = new Vector3(player.transform.position.x + distanceAhead, player.transform.position.y, transform.position.z);

        // if the player is teleported, instantly move the camera instead of smoothly
        if (leftTp.GetComponent<Teleport>().wrap == false && rightTp.GetComponent<Teleport>().wrap == false && !player.GetComponent<HealthManager>().isdead )
        {
            transform.position = Vector3.Lerp(transform.position, playerPos, movSpeed * Time.deltaTime);
        }

        if (leftTp.GetComponent<Teleport>().wrap == true || rightTp.GetComponent<Teleport>().wrap == true || player.GetComponent<PlayerMovement>().boss)
        {
            transform.position = playerPos;
        }



        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + hWidth, maxBounds.x - hWidth);

        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + hHeight, maxBounds.y - hHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
