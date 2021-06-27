using System.Collections;
using UnityEngine;

public class HouseSpawn : MonoBehaviour
{
    public GameObject house;

    public void Spawn()
    {
        Instantiate(house, transform);
    }
}
