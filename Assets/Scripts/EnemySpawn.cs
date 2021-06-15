using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject bird;

    IEnumerator instantiateController;
    bool gameOver;

    public void Start()
    {
        instantiateController = SpawnLoop();
        StartCoroutine(instantiateController);
    }

    IEnumerator SpawnLoop()
    {
        while (!gameOver)
        {
            bool sholdSpawn = Random.Range(0f, 1f) > 0.5f;

            if (sholdSpawn)
            {
                Vector3 position = Vector3.up * Random.Range(-4f, 4f) + transform.position;
                Instantiate(bird, position, Quaternion.identity, transform);
            }

            yield return new WaitForSeconds(1);
        }
    }

    public void Stop()
    {
        StopCoroutine(instantiateController);
    }
}
