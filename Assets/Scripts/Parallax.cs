using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 1;

    Vector2 textureOffset;
    GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
    }

    void Update()
    {
        textureOffset.x += speed * gameController.cameraVelocity * Time.deltaTime;
        GetComponent<Renderer>().material.mainTextureOffset = textureOffset;
    }
}
