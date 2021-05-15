using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 1;

    Vector2 textureOffset;

    void Update()
    {
        textureOffset.x = Time.time * speed;
        GetComponent<Renderer>().material.mainTextureOffset = textureOffset;
    }
}
