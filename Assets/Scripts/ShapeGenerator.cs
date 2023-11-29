using UnityEngine;

public class ShapeGenerator : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array of prefabs to spawn
    public Vector2 spawnRange = new Vector2(-5f, 5f); // Range where objects will be spawned
    public float spawnDelay = 2f; // Time delay between spawns

    void Start() {
        // Start spawning objects with a delay
        InvokeRepeating("SpawnObject", 0f, spawnDelay);
    }

    void SpawnObject() {
        // Generate a random index to select a prefab from the array
        int randomIndex = Random.Range(0, objectsToSpawn.Length);
        GameObject objectPrefab = objectsToSpawn[randomIndex];

        //// Generate a random position within the specified range
        //float randomX = Random.Range(spawnRange.x, spawnRange.y);
        //Vector3 spawnPosition = new Vector3(randomX, transform.position.y, 0f);

        // Instantiate the randomly selected object at the random position
        Instantiate(objectPrefab, transform.position, Quaternion.identity);
    }
}
