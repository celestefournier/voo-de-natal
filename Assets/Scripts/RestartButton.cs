using DG.Tweening;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    [HideInInspector]
    public SceneManager sceneManager;
    public CanvasGroup loseScene;

    void Start()
    {
        sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
    }

    public void Restart()
    {
        loseScene.DOFade(0, 0.2f).SetUpdate(true).SetEase(Ease.Linear).OnComplete(() => {
            sceneManager.Restart();
            Destroy(loseScene.gameObject);
        });
    }
}
