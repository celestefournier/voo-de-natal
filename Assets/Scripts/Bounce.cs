using DG.Tweening;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    float speed = 1;

    void Start()
    {
        transform.DOMoveY(4.4f, speed).SetEase(Ease.InOutSine).OnComplete(() =>
            transform.DOMoveY(-4.4f, speed).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
        );
    }
}
