using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool stopHighlight;
    private Color startColor;
    public Transform thoughPosition;
    private Transform originalPosition;
    private bool isDragged = false;
    private bool inBubble = false;
    public Collider2D mainCollider;

    void Start()
    {
        originalPosition = thoughPosition;
    }

    void Update()
    {
        if (isDragged == false && inBubble == false)
        {
            transform.position = thoughPosition.position;
        }

        if (isDragged == false && inBubble == true && stopHighlight == true)
        {
            if (transform.localScale.y > 0f)
            {
                transform.localScale += new Vector3(0.1F, .1f, .1f) * -3f * Time.deltaTime;
            }
            else
            {
                //do the animation thingy associated with the animation
            }
        }


        OnMouseDragging();

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isDragged = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "MainBrain")
        {
            inBubble = true;
            Transform position = collider.GetComponent<Transform>();
            transform.position = position.position;
            stopHighlight = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "MainBrain")
        {
            inBubble = false;
        }
    }

    void OnMouseUp()
    {
        isDragged = false;
    }

    void OnMouseDragging()
    {
        if (inBubble == false)
        {
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
            {
                isDragged = true;
                transform.position = GetMousePos();
                GetComponent<Renderer>().material.color = startColor;
            }

        }
    }

    void OnMouseEnter()
    {
        if (stopHighlight == false)
        {
            startColor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = startColor;

        //Vector2 mousecoordinates = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //if (!mainCollider.OverlapPoint(mousecoordinates))
        //{
        //    print("out2");
        //    inBubble = false;
        //}
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }


}
