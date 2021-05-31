using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class TweenMove : MonoBehaviour
{
    public Vector2 moveFrom;
    public float duration = 1.5f;
    public float delay;
    public Ease ease = Ease.OutQuart;
    public bool loop;
    public UnityEvent onComplete;

    void Start()
    {
        GetComponent<RectTransform>()
            .DOAnchorPos(moveFrom, duration)
            .From()
            .SetDelay(delay)
            .SetEase(ease)
            .SetLoops(loop ? -1 : 0)
            .OnComplete(onComplete.Invoke);
    }
}
