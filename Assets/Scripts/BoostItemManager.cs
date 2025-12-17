using UnityEngine;

public class BoostItemManager : MonoBehaviour
{
    public static BoostItemManager Instance;

    public GameObject boostItemPrefab; // Assign the Boost Item prefab in the Inspector
    public int maxBoostItems = 3; // Maximum number of Boost Items
    public Transform respawnPointsParent; // Parent GameObject containing all respawn points

    private Transform[] respawnSquares;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Get all "Square" child GameObjects under the respawn points
        respawnSquares = GetAllSquares(respawnPointsParent);

        // Spawn initial Boost Items
        for (int i = 0; i < maxBoostItems; i++)
        {
            SpawnBoostItem();
        }
    }

    private Transform[] GetAllSquares(Transform parent)
    {
        // Collect all "Square" child GameObjects from the respawn points
        var squaresList = new System.Collections.Generic.List<Transform>();
        foreach (Transform respawnPoint in parent)
        {
            foreach (Transform square in respawnPoint)
            {
                squaresList.Add(square);
            }
        }
        return squaresList.ToArray();
    }

    private void SpawnBoostItem()
    {
        // Spawn with safety check for initial spawn
        if (transform.childCount < maxBoostItems)
        {
            Transform randomSquare = respawnSquares[Random.Range(0, respawnSquares.Length)];
            GameObject newBoostItem = Instantiate(boostItemPrefab, randomSquare.position, Quaternion.identity, transform);
        }
    }

    public void RespawnBoostItem()
    {
        // Respawn without check - we know an item is being destroyed
        Transform randomSquare = respawnSquares[Random.Range(0, respawnSquares.Length)];
        GameObject newBoostItem = Instantiate(boostItemPrefab, randomSquare.position, Quaternion.identity, transform);
    }
}