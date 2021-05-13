using UnityEngine;

public class Bird : MonoBehaviour
{
    float speed = 4;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
