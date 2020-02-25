using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    float runSpeed = 2;// float to control speed
    float jumpForce = 300; // float for jump force
    Vector2 direction = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {



        float currentYVel = GetComponent<Rigidbody2D>().velocity.y;// create a float tracking current Y velocity

        if (Input.GetKey(KeyCode.LeftArrow)) // if player presses left arrow
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, currentYVel);
            // set velocity of player
            transform.localScale = new Vector2(-1, transform.localScale.y);
            // make sure facing current direction
            direction = new Vector2(-1, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, currentYVel);
            transform.localScale = new Vector2(1, transform.localScale.y);
            direction = new Vector2(1, 0);

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {


            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce)); //  jump


        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
            Debug.DrawLine(transform.position, transform.position + (Vector3)direction, Color.cyan);
            if (hit.collider != null)
            {
               // Debug.Log(direction);

                if (hit.collider.tag == "Character")
                {

                    CharacTalk hitCharacter = hit.collider.GetComponent<CharacTalk>();
                    if (hitCharacter)
                    {
                        hitCharacter.startTalking();
                    }

                   
                }
            }


        }

    }
}
