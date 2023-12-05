using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject circle;
    public GameObject square;

    public Transform spawnPoint;

    public bool spawnCircle;
    private bool destroyCircle;
    public bool spawnSquare;
    private bool destroySquare;

    public Canvas circleTutsUI;
    public Canvas squareTutsUI;


    float timer;

    private void Start() {
        timer = 0;

        spawnCircle = false;
        destroyCircle = false;
        spawnSquare = false;
        destroySquare = false;
    }

    public void Update() {
        timer += Time.deltaTime;

        if(timer > 1) {
            spawnCircle = true;
        }

        if(spawnCircle ) {
            SpawnShape(circle);
        }
    }

    void SpawnShape(GameObject prefab) {
        Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
    }

    
}
