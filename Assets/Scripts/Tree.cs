using UnityEngine;

public class Tree : MonoBehaviour
{
    public float speed = 1;

    Vector2 position;

    void Update()
    {
        position.x = Time.time * speed;
        transform.position = -position;
    }
}
