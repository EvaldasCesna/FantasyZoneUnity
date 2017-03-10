using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject otherside;
    public bool wrap;
    public bool isLeft;
    //Teleport the player to the other end so the level is endless
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLeft)
        {
            if (collision.tag == "Player")
            {
                wrap = true;
                collision.gameObject.transform.position = new Vector3(otherside.transform.position.x + collision.GetComponent<Collider2D>().bounds.size.x, collision.gameObject.transform.position.y, 0f);
            }
        }
        if (!isLeft)
        {
            if (collision.tag == "Player")
            {
                wrap = true;
                collision.gameObject.transform.position = new Vector3(otherside.transform.position.x - collision.GetComponent<Collider2D>().bounds.size.x, collision.gameObject.transform.position.y, 0f);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            wrap = false;

        }
    }
    

    //   Renderer[] renderers;

    //   private bool isWrappingX = false;

    //   void Start()
    //   {
    //       renderers = GetComponentsInChildren<Renderer>();
    //   }


    //// Update is called once per frame
    //void FixedUpdate () {


    //       ScreenWrap();
    //}

    //   void ScreenWrap()
    //   {

    //       bool isVisible = CheckRenders();

    //       if(isVisible)
    //       {
    //           isWrappingX = false;
    //           return;
    //       }

    //       if (isWrappingX)
    //       {
    //           return;
    //       }

    //       Vector3 newPosition = transform.position;

    //       if (newPosition.x > 1 || newPosition.x < 0)
    //       {
    //           newPosition.x = -newPosition.x;
    //           isWrappingX = true;
    //       }

    //       transform.position = newPosition;
    //   }

    //   bool CheckRenders()
    //   {
    //       foreach(Renderer renderer in renderers)
    //       {
    //           if(renderer.isVisible)
    //           {
    //               return true;
    //           }
    //       }
    //       return false;
    //   }


}
