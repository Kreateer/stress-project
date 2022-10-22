using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.UIElements;

namespace Events
{
    public class TutorialEvents : MonoBehaviour
    {
        private GameObject PlayerBoi;
        private GameObject mainCamera;
        private GameObject CV;

        void Awake()
        {
            PlayerBoi = GameObject.FindWithTag("Player");
            mainCamera = GameObject.FindWithTag("MainCamera");
            //CV = GameObject.Find("ButtonCanvas");
        }
        
        /* Alright, lemme explain this here:
         
         I put two separate functions instead of one for simplicity's sake.
         The Buttons have an 'On Click()' function within the Editor, which
         is tied to a GameObject and a function of that object's attached script.
         By default, the buttons expect left mouse click as trigger.
         This means that the buttons check for clicks on their own, but
         they only listen to separate functions. Hence my decision.
         
         Tl;dr: im lazy and enjoy clicking buttons :D */

        /*public void RunBack()
        {

            //flip player then move toon back
            CV.SetActive(false);
            PlayerBoi.GetComponent<SpriteRenderer>().flipX = true;
            PlayerBoi.transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(0, 0), Time.deltaTime * 5);
            
            //re-enable camera and player movement
            mainCamera.GetComponent<CameraFollow>().isFollowing = true;
            PlayerBoi.GetComponent<Movement>().JustMove(true);
            PlayerBoi.GetComponent<Movement>().speed = 4;
            PlayerBoi.GetComponent<Movement>().spriteFlip = true;
        }

        public void RunPast()
        {
            //flip player then move toon forward
            CV.SetActive(false);
            PlayerBoi.GetComponent<SpriteRenderer>().flipX = false;
            PlayerBoi.transform.position = Vector2.MoveTowards(transform.position,
                new Vector2(1, 0), Time.deltaTime * 5);

            //re-enable camera and player movement
            mainCamera.GetComponent<CameraFollow>().isFollowing = true;
            PlayerBoi.GetComponent<Movement>().JustMove(true);
            PlayerBoi.GetComponent<Movement>().speed = 4;
            PlayerBoi.GetComponent<Movement>().spriteFlip = true;
        }*/
    }
}
