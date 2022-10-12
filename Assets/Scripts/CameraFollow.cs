using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Camera mainCamera;
    public GameObject player;
    private Vector3 initialOffset;
    private Vector3 cameraPosition;
    public float smoothness;
    public bool isFollowing;

    // Start is called before the first frame update
    void Start()
    {
        initialOffset = transform.position - player.transform.position;
        isFollowing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing == true)
        {
            cameraPosition = player.transform.position + initialOffset;
            transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.fixedDeltaTime);
        }
    }

    //public void CameraFollowing(bool isFollowing = true)
    //{
    //   if (isFollowing == true)
    //    {
    //        cameraPosition = player.transform.position + initialOffset;
    //        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.fixedDeltaTime);
    //    }
    //}
}
