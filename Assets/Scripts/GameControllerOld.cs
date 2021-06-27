using System.Collections;
using DG.Tweening;
using UnityEngine;

public class GameControllerOld : MonoBehaviour
{
    public GameObject player;
    public CanvasGroup gameCanvas, menuCanvas;
    public GameObject loseCanvas, finishCanvas;
    public ScoreManager scoreManager;
    public GameObject SpawnPoint;
    public TreeSpawn treeSpawn;

    [HideInInspector]
    public float cameraVelocity = 1;

    void EndGame(int time)
    {
        if (time == 0)
        {
            DOTween.To(() => cameraVelocity, x => cameraVelocity = x, 0.01f, 4).SetEase(Ease.Linear);
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.GetComponent<Player>().enabled = false;
            player.transform.DOMove(new Vector3(-3.5f, -3.9f, 1.5f), 3).SetEase(Ease.Linear);
            player.transform.DOScale(new Vector2(0.3f, 0.3f), 3).SetEase(Ease.Linear);
            player.GetComponent<SpriteRenderer>().DOColor(Color.gray, 2).SetEase(Ease.Linear);
            player.transform.DOMove(new Vector3(0, -3.9f, 1.5f), 4).SetEase(Ease.OutQuad).SetDelay(3);
            DOTween.To(
                () => player.GetComponent<Animator>().speed,
                x => player.GetComponent<Animator>().speed = x, 0, 4
            ).SetEase(Ease.Linear).SetDelay(2);
            StartCoroutine("OpenEndScreen");
        }
    }

    IEnumerator OpenEndScreen()
    {
        yield return new WaitForSecondsRealtime(6);
        gameCanvas.DOFade(0, 0.2f).SetEase(Ease.Linear).SetUpdate(true);
        yield return new WaitForSecondsRealtime(0.1f);
        finishCanvas.SetActive(true);
        finishCanvas.GetComponent<CanvasGroup>().DOFade(0, 0.5f).From().SetEase(Ease.Linear).SetUpdate(true).SetDelay(0.5f);
        foreach (Transform item in SpawnPoint.transform)
        {
            Destroy(item.gameObject);
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        cameraVelocity = 1;
        treeSpawn.Start();
        scoreManager.Restart();
        loseCanvas.GetComponent<CanvasGroup>().DOFade(0, 0.2f).OnComplete(() => loseCanvas.SetActive(false));
        finishCanvas.GetComponent<CanvasGroup>().DOFade(0, 0.2f).OnComplete(() => finishCanvas.SetActive(false));
        player.transform.position = new Vector3(-11, 0);
        player.transform.localScale = Vector3.one;
        player.GetComponent<Player>().enabled = true;
        player.GetComponent<Animator>().speed = 1;
        player.GetComponent<SpriteRenderer>().color = Color.white;
        player.transform.DOMoveX(-6.02f, 2).SetEase(Ease.OutQuint).SetDelay(0.3f);
        gameCanvas.DOFade(1, 0.2f).SetEase(Ease.Linear).SetDelay(1.5f).OnComplete(() =>
        {
            SpawnPoint.GetComponent<ItemSpawn>().Restart();
            SpawnPoint.GetComponent<EnemySpawn>().Start();
        });
    }
}
