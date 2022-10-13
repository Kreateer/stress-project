using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    public float speed;
    public bool movementType;
    Vector2 mousePosition;

    void Start()
    {
        mousePosition = transform.position;
    }

    void Update()
    {
        if (movementType == true)
        {
            JustMove();
            //Debug.Log("JustMove is being called");
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                MousePosition();
            }
            MoveToPosition();
        }

        Flip();
    }

    void MousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void JustMove(bool isMoving = true)
    {   // made public function to call in DoggoCollider.cs
        float translation = Input.GetAxis("Horizontal") * speed;
        if (isMoving == true)
        {
            translation *= Time.deltaTime;
            transform.Translate(translation, 0, 0);
            //Debug.Log("Player is moving.");
        }
        else
        {
            speed = 0; // simply put player speed to 0 to stop moving
            Debug.Log("Player speed set to: 0");
        }
    }

    void Flip()
    {
        float RotationNeed = Input.GetAxisRaw("Horizontal");
        if (RotationNeed > 0)
        {
            gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if(RotationNeed < 0)
        {
            gameObject.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        } 
    }

    void MoveToPosition()
    {
        if (transform.position.x != mousePosition.x) {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(mousePosition.x,0), Time.deltaTime * 5);
            //transform.position = new Vector2(mousePosition.x * Time.deltaTime *5, 0);
        }
        else 
        {
            //gonna add the thing for the thinking stopping thing
        }
    }
}
