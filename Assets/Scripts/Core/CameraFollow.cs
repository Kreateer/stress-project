using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {
        //public Camera mainCamera;
        public GameObject player;
        private Vector3 initialOffset;
        private Vector3 cameraPosition;
        public float smoothness;
        public bool isFollowing;
        public float clampLeftPosition; // left border
        public float clampRightPosition; //  right border
        public float clampTopPosition; //top border
        public float clampBottomPosition; //bottom border
        public bool clamped;
        private float halfWidth;
        private float halfHeight;

        // Start is called before the first frame update
        void Start()
        {
            initialOffset = transform.position - player.transform.position;
            isFollowing = true;
            halfHeight = Camera.main.orthographicSize;
            halfWidth = Camera.main.aspect * halfHeight;
            //"It's working! It's working!".gif
        }

        // Update is called once per frame
        void Update()
        {
            if (isFollowing == true)
            {
                cameraPosition = player.transform.position + initialOffset;
                transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.fixedDeltaTime);
            }

            CheckIfClamped();
        }

        void OnDrawGizmos() // this draws the red lines representing camera clamp borders
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(clampLeftPosition, clampTopPosition),
                new Vector2(clampRightPosition, clampTopPosition));
            Gizmos.DrawLine(new Vector2(clampRightPosition, clampTopPosition),
                new Vector2(clampRightPosition, clampBottomPosition));
            Gizmos.DrawLine(new Vector2(clampRightPosition, clampBottomPosition),
                new Vector2(clampLeftPosition, clampBottomPosition));
            Gizmos.DrawLine(new Vector2(clampLeftPosition, clampBottomPosition),
                new Vector2(clampLeftPosition, clampTopPosition));
        }

        void CheckIfClamped() // this checks if the 'clamped' checkbox is ticked in the editor
        {
            if (clamped == true)
            {
                transform.position = new Vector3
                (
                    Mathf.Clamp(transform.position.x, clampLeftPosition + halfWidth, clampRightPosition - halfWidth),
                    Mathf.Clamp(transform.position.y, clampBottomPosition + halfHeight, clampTopPosition - halfHeight),
                    transform.position.z);
                //Debug.Log("Clamped called");
            }
        }
    }
}
