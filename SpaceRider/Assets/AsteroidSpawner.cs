using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public Vector3[] spawnPos;
    public float spawnInterval = 1;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            int e = Random.Range(0, 3);
            List<GameObject> wave = new List<GameObject>();
            for (int i = 0; i < spawnPos.Length; i++)
            {
                GameObject asteroid = Instantiate<GameObject>(asteroidPrefab, spawnPos[i], Quaternion.identity);
                asteroid.name = "Asteroid";
                wave.Add(asteroid);
            }
            wave[e].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            wave[e].name = "Points";

            timer = 0;
            spawnInterval = Random.Range(0.8f, 1.2f);
        }
    }
}
