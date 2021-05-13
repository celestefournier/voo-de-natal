using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetAxis("Vertical") > 0 && transform.position.y < 3.5f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * Input.GetAxis("Vertical") * speed;
        }
        else if (Input.GetAxis("Vertical") < 0 && transform.position.y > -3.3f)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * Input.GetAxis("Vertical") * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
