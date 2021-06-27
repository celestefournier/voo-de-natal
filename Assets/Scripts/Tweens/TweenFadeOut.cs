using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class TweenFadeOut : MonoBehaviour
{
    public bool autoPlay = true;
    public float moveFrom = 1;
    public float duration = 1.5f;
    public float delay;
    public Ease ease = Ease.Linear;
    public bool loop;
    public enum UpdateMode { Normal, UnscaledTime }
    public UpdateMode updateMode;
    public UnityEvent onComplete;

    CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (autoPlay) Play();
    }

    public void Play()
    {
        canvasGroup
            .DOFade(moveFrom, duration)
            .SetDelay(delay)
            .SetEase(ease)
            .SetLoops(loop ? -1 : 0)
            .SetUpdate(updateMode == UpdateMode.UnscaledTime)
            .OnComplete(onComplete.Invoke);
    }
}
