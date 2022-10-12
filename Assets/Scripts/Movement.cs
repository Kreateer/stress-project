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

    void JustMove()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0,0);
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
        else {
            //gonna add the thing for the thinking stopping thing
        }
    }
}
