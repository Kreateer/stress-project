using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
     Ray ray;
     RaycastHit hit;
    public Camera cam;

    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);

            

        if (Physics.Raycast(ray.origin, ray.direction * 100, out hit))
        {
             print (hit.collider.name);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
         }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
        }
     }
}

