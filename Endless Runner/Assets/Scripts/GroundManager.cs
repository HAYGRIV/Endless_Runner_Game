using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject groundPrefab; // Reference to the ground prefab
    public Transform player; // Reference to the player's transform
    public float spawnDistanceThreshold = 10f; // Distance ahead of the player to spawn new ground
    public float recycleDistanceThreshold = 20f; // Distance behind the player to recycle ground

    private Vector3 lastSpawnPosition; // Last position where ground was spawned

    void Start()
    {
        lastSpawnPosition = transform.position; // Initialize last spawn position
    }

    void Update()
    {
        // Check if player is about to reach the end of the platform
        if (player.position.z >= lastSpawnPosition.z - spawnDistanceThreshold)
        {
            SpawnGround(); // Spawn new ground piece
        }

        // Check if ground pieces need to be recycled
        if (player.position.z >= lastSpawnPosition.z + recycleDistanceThreshold)
        {
            RecycleGround(); // Recycle ground pieces
        }
    }

    void SpawnGround()
    {
        // Calculate spawn position ahead of the player
        Vector3 spawnPosition = lastSpawnPosition + Vector3.forward * spawnDistanceThreshold;
        // Instantiate a new ground piece at the spawn position
        Instantiate(groundPrefab, spawnPosition, Quaternion.identity);
        // Update last spawn position
        lastSpawnPosition = spawnPosition;
    }

    void RecycleGround()
    {
        // Reposition ground pieces behind the player to the front of the platform
        Transform[] grounds = GetComponentsInChildren<Transform>();
        foreach (Transform ground in grounds)
        {
            if (ground != transform && ground.position.z < player.position.z)
            {
                ground.position += Vector3.forward * (recycleDistanceThreshold * 2);
            }
        }
        // Update last spawn position
        lastSpawnPosition += Vector3.forward * (recycleDistanceThreshold * 2);
    }
}
