using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed = 5.0f;
    private Camera cam;

    SavePlayerPosScript playerPosData;

    private void Awake()
    {
        playerPosData = FindObjectOfType<SavePlayerPosScript>();
        playerPosData.PlayerPosLoad();
    }

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        /*if () // An interactable object is in the view
        {
            if () // a puzzle
                // playerprefs "puzzle" changed to the object / corresponding number
                // open puzzle scene and use the previous player pref to define which puzzle to open
            if () // not a puzzle
                    // zoom in on the object?? change scene??? just start dialogue?? esc to return to play... ??
        }*/
    }

    void Move()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        // Get directions relative to camera
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        // Project forward and right direction on the horizontal plane (not up and down), then
        // normalize to get magnitude of 1
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Set the direction for the player to move
        Vector3 dir = right * hMove + forward * vMove;

        // Set the direction's magnitude to 1 so that it does not interfere with the movement speed
        dir.Normalize();

        // Move the player by the direction multiplied by speed and delta time 
        transform.position += dir * speed * Time.deltaTime;

        // Set rotation to direction of movement if moving
        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(forward), 0.2f);
        }
    }
}
