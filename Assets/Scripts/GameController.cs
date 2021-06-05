using System.Collections;
using DG.Tweening;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public CanvasGroup gameCanvas, menuCanvas;
    public GameObject loseCanvas;
    public ScoreManager scoreManager;
    public GameObject SpawnPoint;
    public Timer timer;

    void Start()
    {
        menuCanvas.DOFade(0, 1.2f).From().SetEase(Ease.Linear);
    }

    public void StartGame()
    {
        menuCanvas.DOFade(0, 0.2f).SetEase(Ease.Linear);
        player.SetActive(true);
        player.transform.DOMoveX(-11, 2).From().SetEase(Ease.OutQuint).SetDelay(0.3f);
        gameCanvas.gameObject.SetActive(true);
        gameCanvas.DOFade(1, 0.2f).SetEase(Ease.Linear).SetDelay(1.5f).OnComplete(() =>
        {
            timer.StartTimer();
            SpawnPoint.SetActive(true);
        });
    }

    public void Lose()
    {
        Time.timeScale = 0;
        StartCoroutine("OpenLoseScreen");
    }

    IEnumerator OpenLoseScreen()
    {
        yield return new WaitForSecondsRealtime(1);
        gameCanvas.DOFade(0, 0.2f).SetEase(Ease.Linear).SetUpdate(true);
        player.GetComponent<SpriteRenderer>().DOFade(0, 0.2f).SetUpdate(true);
        loseCanvas.SetActive(true);
        loseCanvas.GetComponent<CanvasGroup>().DOFade(1, 0.5f).SetEase(Ease.Linear).SetUpdate(true);
        timer.Stop();
        foreach (Transform item in SpawnPoint.transform)
        {
            Destroy(item.gameObject);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        scoreManager.Restart();
        loseCanvas.GetComponent<CanvasGroup>().DOFade(0, 0.2f).OnComplete(() => loseCanvas.SetActive(false));
        player.transform.position = new Vector2(-11, 0);
        player.transform.DOMoveX(-6.02f, 2).SetEase(Ease.OutQuint).SetDelay(0.3f);
        player.GetComponent<SpriteRenderer>().color = Color.white;
        gameCanvas.DOFade(1, 0.2f).SetEase(Ease.Linear).SetDelay(1.5f).OnComplete(() =>
        {
            timer.Restart();
            SpawnPoint.GetComponent<ItemSpawn>().Restart();
        });
    }
}
