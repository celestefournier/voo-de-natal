using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 1;

    Vector2 textureOffset;

    void Update()
    {
        textureOffset.x += speed * Time.deltaTime;
        GetComponent<Renderer>().material.mainTextureOffset = textureOffset;
    }
}
