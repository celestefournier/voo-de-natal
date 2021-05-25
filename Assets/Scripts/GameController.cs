using DG.Tweening;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject menuUI, gameUI;
    public GameObject SpawnPoint;
    public Timer timer;

    CanvasGroup menuUICanvas, gameUICanvas;

    void Start()
    {
        menuUICanvas = menuUI.GetComponent<CanvasGroup>();
        gameUICanvas = gameUI.GetComponent<CanvasGroup>();

        menuUICanvas.DOFade(0, 1.2f).From().SetEase(Ease.Linear);
    }

    public void StartGame()
    {
        menuUICanvas.DOFade(0, 0.2f).SetEase(Ease.Linear);
        player.SetActive(true);
        player.transform.DOMoveX(-11, 2).From().SetEase(Ease.OutQuint).SetDelay(0.3f);
        gameUI.SetActive(true);
        gameUICanvas.DOFade(1, 0.2f).SetEase(Ease.Linear).SetDelay(1.5f).OnComplete(() =>
        {
            timer.StartTimer();
            SpawnPoint.SetActive(true);
        });
    }

    public void Lose()
    {
        Time.timeScale = 0;
    }
}
