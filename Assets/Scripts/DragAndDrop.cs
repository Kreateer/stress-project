using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool stopHighlight;
    private Color startColor;
    void OnMouseDrag()
    {
        transform.position = GetMousePos();
        GetComponent<Renderer>().material.color = startColor;
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
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
