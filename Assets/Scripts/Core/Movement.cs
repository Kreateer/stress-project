using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Movement : MonoBehaviour

    {
        public float speed;
        public bool movementType;
        Vector2 mousePosition;
        private SpriteRenderer playerSprite;
        private Rigidbody2D playerBody;
        public bool spriteFlip;
        //private RigidbodyConstraints2D rigidBodyConstraints;
        private Animator playerWalk;

        void Start()
        {
            mousePosition = transform.position;
            playerSprite = GetComponent<SpriteRenderer>();
            //playerBody = GetComponent<Rigidbody2D>();
            spriteFlip = true;
            playerWalk = GetComponent<Animator>();
        }

        void Update()
        {
            if (movementType == true)
            {
                JustMove();
                //Debug.Log("JustMove is being called");
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

        public void JustMove(bool isMoving = true)
        {   // made public function to call in DoggoCollider.cs
            float translation = Input.GetAxis("Horizontal") * speed;
            //var moveVector = new Vector3(translation, 0, 0);
            if (isMoving == true)
            {
                //playerBody.constraints = RigidbodyConstraints2D.None;
                //playerBody.MovePosition(new Vector2((transform.position.x + moveVector.x * speed * Time.deltaTime),
                //    transform.position.y + moveVector.y * speed * Time.deltaTime));
				if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
				{
				//check input
                translation *= Time.deltaTime;
                transform.Translate(translation, 0, 0);
				//playerWalk.SetBool("isWalking", true);
				playerWalk.SetFloat("Walking", 0);
				//playerWalk.Play("Base Layer.Player_Walk");
                //Debug.Log("Player is moving.");
				}
				else
				{
					//playerWalk.SetBool("isWalking", false);
					playerWalk.SetFloat("Walking", 1);
				}
            }
            else
            {
                speed = 0; // simply put player speed to 0 to stop moving
				//playerWalk.SetBool("isWalking", false);
				//playerWalk.Play("Base Layer.Player_Idle");
				playerWalk.SetFloat("Walking", 1);
                Debug.Log("<color=red>Player speed set to: 0</color>");
                //playerBody.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }

        public void Flip()
        {
            if (spriteFlip == true)
            {
                float RotationNeed = Input.GetAxisRaw("Horizontal");
                if (RotationNeed > 0)
                {
                    playerSprite.flipX = false;
                    //gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                }
                else if (RotationNeed < 0)
                {
                    playerSprite.flipX = true;
                    //gameObject.transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
                }
            }
        }

        void MoveToPosition()
        {
            if (transform.position.x != mousePosition.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(mousePosition.x, 0), Time.deltaTime * 5);
                //transform.position = new Vector2(mousePosition.x * Time.deltaTime *5, 0);
            }
            else
            {
                //gonna add the thing for the thinking stopping thing
            }
        }
    }
}
