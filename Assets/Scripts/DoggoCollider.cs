using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoggoCollider : MonoBehaviour
{
    private GameObject DoggyStyle; // collider
    private GameObject PlayerBoi; // player object
    private GameObject MC; // main camera
    // Start is called before the first frame update
    void Start()
    {
        DoggyStyle = GameObject.FindWithTag("Doggo");
        MC = GameObject.FindWithTag("MainCamera");
    }

    void OnTriggerEnter2D(Collider2D PlayerBoi)
    {
        if (PlayerBoi.tag == "Player")
            Debug.Log("Doggo collider triggered!");
            MC.GetComponent<CameraFollow>().isFollowing = false;
            //trigger so camera stops following player

            //add code to stop player here (for x amount of time?)
    }
}
