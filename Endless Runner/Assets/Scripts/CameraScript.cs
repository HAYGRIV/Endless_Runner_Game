using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
    public float time; //for adjusting the cameras response time
    public float distance = 5f; // Distance between the camera and the player
    public float height = 2f; // Height of the camera above the player
    public float smoothSpeed = 0.125f; // Speed of camera movement

    private Vector3 velocity = Vector3.zero;
    //Now we will write a function so that our camera always look towards the target..
    private void FixedUpdate()
    {
        transform.LookAt(Player);
        transform.position = Vector3.Lerp(transform.position, Player.position + offset, time);  //this is for making the game 1st player
    }
    void LateUpdate()
    {
        // Check if player reference is set
        if (Player != null)
        {
            // Calculate the desired position of the camera
            Vector3 desiredPosition = Player.position - Player.forward * distance + Vector3.up * height;
            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
            // Make the camera look at the player
            transform.LookAt(Player.position);
        }
    }
}