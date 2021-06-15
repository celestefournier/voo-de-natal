using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] items;
    public GameObject star;

    bool gameOver;
    List<IEnumerator> instantiateController = new List<IEnumerator>();

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
                float timeToSpawn = Random.Range(0f, 45f);
                instantiateController.Add(WaitForInstantiate(item, timeToSpawn));
                StartCoroutine(instantiateController.Last());
            }
        }

        instantiateController.Add(WaitForInstantiate(star, 45f));
        StartCoroutine(instantiateController.Last());
    }

    IEnumerator WaitForInstantiate(GameObject prefab, float timeToSpawn)
    {
        yield return new WaitForSeconds(timeToSpawn);

        Vector3 position = Vector3.up * Random.Range(-4f, 4f) + transform.position;
        GameObject item = Instantiate(prefab, position, Quaternion.identity, transform);
        item.name = prefab.name;
    }

    public void Restart()
    {
        foreach (IEnumerator instantiate in instantiateController)
        {
            StopCoroutine(instantiate);
        }
        Start();
    }
}
