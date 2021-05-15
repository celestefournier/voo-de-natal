using System.Collections;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    public GameObject treePrefab;
    public float speed;
    public float spawnTime;
    public int initialTrees;

    void Start()
    {
        InitialSpawn();
        StartCoroutine("SpawnLoop");
    }

    void InitialSpawn()
    {
        for (int i = 0; i < initialTrees; i++)
        {
            Vector3 position = new Vector3(Random.Range(-8.5f, 8.5f), transform.position.y, transform.position.z);
            GameObject tree = Instantiate(treePrefab, position, Quaternion.identity, transform);
            tree.GetComponent<MoveToLeft>().speed = speed;
        }
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            bool sholdSpawn = Random.Range(0f, 1f) > 0.25f;

            if (sholdSpawn)
            {
                GameObject tree = Instantiate(treePrefab, transform.position, Quaternion.identity, transform);
                tree.GetComponent<MoveToLeft>().speed = speed;
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
