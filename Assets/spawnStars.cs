using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnStars : MonoBehaviour
{
    public GameObject starPrefab;
    public int starCount = 10;
    public float spawnAreaWidth = 10f;
    public float spawnAreaHeight = 10f;

    void Start()
    {
        transform.position = Vector2.zero;

        SpawnStars();   
    }

    void SpawnStars()
    {
        for (int i = 0; i < starCount; i++)
        {

            float x = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            float y = Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2);
            Vector3 spawnPosition = new Vector3(x, y, 0);

   
            GameObject star = Instantiate(starPrefab, spawnPosition, Quaternion.identity);

            // star.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.5f, 1f); // Random color
            // star.transform.localScale = Vector3.one * Random.Range(0.5f, 1.5f); // Random size
        }
    }
    void OnDrawGizmos()
    {
        // Draw a rectangle to represent the spawn area
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaWidth, spawnAreaHeight, 0));
    }
}
