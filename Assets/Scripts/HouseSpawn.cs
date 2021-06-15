using System.Collections;
using UnityEngine;

public class HouseSpawn : MonoBehaviour
{
    public GameObject house;

    void Start()
    {
        StartCoroutine("SpawnHouse");
    }

    IEnumerator SpawnHouse()
    {
        yield return new WaitForSeconds(50.2f);

        Instantiate(house, transform);
    }
}
