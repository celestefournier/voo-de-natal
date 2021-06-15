using System.Collections;
using System.Threading.Tasks;
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
    public TreeSpawn treeSpawn;

    [HideInInspector]
    public float cameraVelocity = 1;

    void Start()
    {
        menuCanvas.DOFade(0, 1.2f).From().SetEase(Ease.Linear);
        timer.onChangeTime.AddListener(EndGame);
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

    void EndGame(int time)
    {
        if (time == 5)
        {
            SpawnPoint.GetComponent<EnemySpawn>().Stop();
        }
        if (time == 0)
        {
            treeSpawn.Stop();
            DOTween.To(() => cameraVelocity, x => cameraVelocity = x, 0, 4).SetEase(Ease.Linear);
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
            // Task.Delay(10000).ContinueWith(t=> print("testeeeeeeeeeeeeee"));
        }
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
        player.transform.position = new Vector3(-11, 0);
        player.transform.DOMoveX(-6.02f, 2).SetEase(Ease.OutQuint).SetDelay(0.3f);
        player.GetComponent<SpriteRenderer>().color = Color.white;
        gameCanvas.DOFade(1, 0.2f).SetEase(Ease.Linear).SetDelay(1.5f).OnComplete(() =>
        {
            timer.Restart();
            SpawnPoint.GetComponent<ItemSpawn>().Restart();
        });
    }
}
