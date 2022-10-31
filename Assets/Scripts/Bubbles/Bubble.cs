using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThoughtBubble.Bubble
{


    public class Bubble : MonoBehaviour
    {
        public Animator anim;
        void Start()
        {
            //anim.Play("BubbleAN", 1, float.NegativeInfinity);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                anim.SetBool("Think", true);
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                anim.SetBool("Think", false);
            }
        }

    void OnTriggerStay2D(Collider2D collider)
        {
            //if (collider.tag == "Item")
            //{
            //    collider.transform.position = transform.position;

            //    if (collider.transform.localScale.y > 0f)
            //    {
            //        collider.transform.localScale += new Vector3(0.1F, .1f, .1f) * -3f * Time.deltaTime;
            //    }
            //    //drag and activate necessary event the checking the items name and associated event with it
            //}
        }

    }
}
