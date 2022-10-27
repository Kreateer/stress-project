using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThoughtBubble
{
    public class DragAndDrop : MonoBehaviour
    {
        // make sure that multiple item CANNOT be dragged at the same time!!!


        private GameObject playerMan;
        private bool stopHighlight;
        private Color startColor;
        private bool isDragged;
        private Vector3 originalPosition;
        private Vector3 orginalScale;
        private bool isPrefab;
        private bool deActivated;
        private bool stopFollow;
        //private GameObject Copy;
        public GameObject[] otherItems;

        void Start()
        {
            originalPosition = transform.position;
            orginalScale = transform.localScale;
            otherItems = GameObject.FindGameObjectsWithTag("Item");
            stopHighlight = false;
            isDragged = false;
            isPrefab = false;
            deActivated = false;
            stopFollow = false;
            ////var muzzleFlashPrefab = Resources.Load("Prefabs/MuzzleFlash") as GameObject;
            playerMan = GameObject.FindWithTag("Player");
            //Instantiate(Copy, new Vector3(0, 0, 0), Quaternion.identity);
            //call the script that will be associated with the player
            //write the code to clone the item
        }

        void Update()
        {

            if(isDragged == true)
            {
                DetectAndDeactivateItems();
            }

            if (transform.localScale.y < 0f)
            {
                transform.position = originalPosition;
                transform.localScale = orginalScale;
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.tag == "MainBrain")
            {
                stopFollow = true;
                stopHighlight = true;
            }
        }

        void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.tag == "MainBrain")
            {
                stopFollow = false;
 
            }
        }

        void OnMouseUp()
        {
            isDragged = false;
            DetectAndActivateItems();
        }

        void OnMouseDrag()
        {
            isDragged = true;
            GetComponent<Renderer>().material.color = startColor;
            if (stopFollow == false)
            {
                transform.position = GetMousePos();
            }
        }

        void OnMouseOver()
        {
           //when the script is associated with the current mouse positioning, chang animation of player though bubble yada yada 
        }

        void OnMouseEnter()
        {
            if (stopHighlight == false && deActivated == false)
            {
                startColor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = Color.green;
            }
        }

        void OnMouseExit()
        {
            if (deActivated == false)
            {
                GetComponent<Renderer>().material.color = startColor;
                //also script to make sure that the animation should stop within the player mind perhaps??
            }
        }

        void DetectAndDeactivateItems()
        {
            foreach (GameObject otherItem in otherItems)
            {
                otherItem.GetComponent<DragAndDrop>().deActivated = true;
            }
        }

        void DetectAndActivateItems()
        {
            foreach (GameObject otherItem in otherItems)
            {
                otherItem.GetComponent<DragAndDrop>().deActivated = false;
            }
        }

        Vector3 GetMousePos()
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            return mousePos;
        }


    }
}
