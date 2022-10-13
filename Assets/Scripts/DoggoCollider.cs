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
        PlayerBoi = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D PlayerBoi)
    {
        if (PlayerBoi.tag == "Player")
            Debug.Log("Doggo collider triggered!");
            MC.GetComponent<CameraFollow>().isFollowing = false;
            Debug.Log("Camera no longer following player!");
            //trigger so camera stops following player

            PlayerBoi.GetComponent<Movement>().JustMove(false);
            Debug.Log("Player can no longer move!");
            PauseTimer();
            //add code to stop player here (for x amount of time?)
    }
    private void PauseTimer() //function to call a timer for player pause effect
    {
        StartCoroutine(PausingTime());

        IEnumerator PausingTime()
        {
            Debug.Log("Started pause timer!");
            yield return new WaitForSeconds(5);
            enabled = false;
            MC.GetComponent<CameraFollow>().isFollowing = true; //optional; used for testing for now
            Debug.Log("Camera following player again!");
            PlayerBoi.GetComponent<Movement>().JustMove(true);
            PlayerBoi.GetComponent<Movement>().speed = 4;
            Debug.Log("Player can move again!");
        }        
    }
}
