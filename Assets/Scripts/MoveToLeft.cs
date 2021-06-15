using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    public float speed = 4;
    GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * gameController.cameraVelocity * Time.deltaTime);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
