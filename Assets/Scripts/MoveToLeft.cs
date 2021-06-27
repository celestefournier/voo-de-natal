using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    public float speed = 4;
    float gameSpeed;

    void Start()
    {
        gameSpeed = FindObjectOfType<BackgroundController>().speed;
    }

    void Update()
    {
        print(gameSpeed);
        transform.Translate(Vector2.left * speed * gameSpeed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
