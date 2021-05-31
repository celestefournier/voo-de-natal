using DG.Tweening;
using UnityEngine;

public class TweenRotate : MonoBehaviour
{
    public Vector3 rotateFrom;
    public float duration = 2f;
    public Ease ease = Ease.InOutSine;
    public bool loop;
    public LoopType loopType = LoopType.Yoyo;

    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        rectTransform
            .DORotate(rotateFrom, duration)
            .SetEase(ease)
            .SetLoops(loop ? -1 : 0, loopType);
    }
}
