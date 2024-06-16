using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public GameObject groundPrefab; // The prefab of the ground object
    public float respawnDistance = 50f; // Distance at which the ground should be respawned
    private float lastRespawnPosition; // Position where the last respawn occurred
    private List<GameObject> groundList = new List<GameObject>(); // List to keep track of spawned ground objects

    void Start()
    {
        lastRespawnPosition = playerTransform.position.z; // Initialize the last respawn position
    }

    void Update()
    {
        // Check if the player has moved beyond the respawn distance
        if (playerTransform.position.z - lastRespawnPosition >= respawnDistance)
        {
            // Respawn the ground
            RespawnGround();
        }
    }

    void RespawnGround()
    {
        // Calculate the position for the new ground
        Vector3 newPosition = new Vector3(0, 0, lastRespawnPosition + respawnDistance);

        // Instantiate the new ground prefab at the calculated position
        GameObject newGround = Instantiate(groundPrefab, newPosition, Quaternion.identity);
        groundList.Add(newGround); // Add the new ground to the list

        // Update the last respawn position
        lastRespawnPosition += respawnDistance;

        // Destroy the oldest ground if necessary to manage memory
        DestroyOldestGround();
    }

    void DestroyOldestGround()
    {
        // Check if there are more than 2 ground objects
        if (groundList.Count > 2)
        {
            // Destroy the oldest ground (the one furthest behind the player)
            Destroy(groundList[0]);
            groundList.RemoveAt(0); // Remove the destroyed ground from the list
        }
    }
}
