using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject bird;

    bool gameOver;

    void Start()
    {
        StartCoroutine("SpawnLoop");
    }

    IEnumerator SpawnLoop()
    {
        while (!gameOver)
        {
            bool sholdSpawn = Random.Range(0f, 1f) > 0.5f;

            if (sholdSpawn)
            {
                Vector3 position = Vector3.up * Random.Range(-4f, 4f) + transform.position;
                Instantiate(bird, position, Quaternion.identity);
            }

            yield return new WaitForSeconds(1);
        }
    }
}
