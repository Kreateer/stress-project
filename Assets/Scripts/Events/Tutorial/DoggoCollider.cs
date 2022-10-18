using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Events
{
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
                Debug.Log("<color=red>Doggo collider triggered!</color>");
            MC.GetComponent<CameraFollow>().isFollowing = false;
            Debug.Log("<color=red>Camera no longer following player!</color>");
            //trigger so camera stops following player

            PlayerBoi.GetComponent<Movement>().JustMove(false);
            PlayerBoi.GetComponent<Movement>().spriteFlip = false;
            Debug.Log("<color=red>Player can no longer move!</color>");
            PauseTimer();
            //stop player for x seconds
        }
        private void PauseTimer() //function to call a timer for player pause effect
        {
            StartCoroutine(PausingTime());

            IEnumerator PausingTime()
            {
                Debug.Log("<color=yellow>Started pause timer!</color>");
                yield return new WaitForSeconds(5);
                enabled = false;
                MC.GetComponent<CameraFollow>().isFollowing = true; //optional; used for testing for now
                Debug.Log("<color=lime>Camera following player again!</color>");
                PlayerBoi.GetComponent<Movement>().JustMove(true);
                PlayerBoi.GetComponent<Movement>().speed = 4;
                PlayerBoi.GetComponent<Movement>().spriteFlip = true;
                Debug.Log("<color=lime>Player can move again!</color>");
            }
        }
    }
}
