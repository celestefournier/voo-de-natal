using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    public float speed = 4;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
