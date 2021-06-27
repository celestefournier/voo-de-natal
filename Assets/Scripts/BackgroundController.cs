using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public Parallax star, mountainBack, mountainMiddle, mountainFront;
    public float speed;

    float starSpeed, mountainBackSpeed, mountainMiddleSpeed, mountainFrontSpeed;

    void Start()
    {
        speed = 1;
        starSpeed = star.speed;
        mountainBackSpeed = mountainBack.speed;
        mountainMiddleSpeed = mountainMiddle.speed;
        mountainFrontSpeed = mountainFront.speed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        star.speed = speed * starSpeed;
        mountainBack.speed = speed * mountainBackSpeed;
        mountainMiddle.speed = speed * mountainMiddleSpeed;
        mountainFront.speed = speed * mountainFrontSpeed;
    }
}
