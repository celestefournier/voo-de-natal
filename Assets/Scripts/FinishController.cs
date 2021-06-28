using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FinishController : MonoBehaviour
{
    public Text candy, bell, ornament, star;

    [HideInInspector]
    public SceneManager sceneManager;

    void Start()
    {
        sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
    }

    public void SetScore(int candies, int bells, int ornaments, int stars)
    {
        candy.text = $"{candies}/3";
        bell.text = $"{bells}/3";
        ornament.text = $"{ornaments}/3";
        star.text = $"{stars}/1";
    }

    public void Retry()
    {
        GetComponent<CanvasGroup>().DOFade(0, 0.3f).OnComplete(sceneManager.Retry);
    }
}
