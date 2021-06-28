using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    public float speed = 4;
    BackgroundController bgController;

    void Start()
    {
        bgController = FindObjectOfType<BackgroundController>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * bgController.speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
