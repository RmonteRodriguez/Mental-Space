using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float respawnTime;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.x));
        StartCoroutine(platformWave());
    }

    private void spawnPlatform()
    {
        Vector3 position = new Vector3(Random.Range(-15f, 15f), 15, 0);
        Instantiate(platformPrefab, position, Quaternion.identity);
    }
    IEnumerator platformWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnPlatform();
        }
    }
}
