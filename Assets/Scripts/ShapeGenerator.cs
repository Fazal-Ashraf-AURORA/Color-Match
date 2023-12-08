using UnityEngine;

public class ShapeGenerator : MonoBehaviour {
    public GameObject[] shapesToSpawn;
    private float spawnDelay = 2f;
    private bool isSpawningAllowed = true;

    private void Start() {
        // InvokeRepeating calls the SpawnObject method with the specified delay and repeat rate
        InvokeRepeating("SpawnObject", 0f, spawnDelay);
    }

    void SpawnObject() {
        // Check if spawning is allowed
        if (!isSpawningAllowed)
            return;

        int randomIndex = Random.Range(0, shapesToSpawn.Length);
        GameObject shapePrefab = shapesToSpawn[randomIndex];

        Instantiate(shapePrefab, transform.position, Quaternion.identity);
    }

    // Call this method to stop spawning after game over
    public void StopSpawning() {
        isSpawningAllowed = false;
    }

    public void StartSpawning() {
        isSpawningAllowed = true;
    }
}
