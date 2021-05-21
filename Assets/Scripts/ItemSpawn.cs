using System.Collections;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] items;
    public GameObject star;

    bool gameOver;

    void Start()
    {
        InstantiateItems();
    }

    void InstantiateItems()
    {
        foreach (GameObject item in items)
        {
            for (int i = 0; i < 3; i++)
            {
                float timeToSpawn = Random.Range(0f, 60f);
                StartCoroutine(WaitForInstantiate(item, timeToSpawn));
            }
        }

        StartCoroutine(WaitForInstantiate(star, 1f));
    }

    IEnumerator WaitForInstantiate(GameObject prefab, float timeToSpawn)
    {
        yield return new WaitForSeconds(timeToSpawn);

        Vector3 position = Vector3.up * Random.Range(-4f, 4f) + transform.position;
        Instantiate(prefab, position, Quaternion.identity);
    }
}
