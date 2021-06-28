using DG.Tweening;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Timer timer;
    public GameObject player;
    public HouseSpawn house;
    public ScoreManager score;
    public CanvasGroup gameInterface;

    SceneManager sceneManager;
    BackgroundController bgController;
    Transform foregroundTrees;

    void Start()
    {
        timer.onChangeTime.AddListener(IsGameOver);
        sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
        bgController = FindObjectOfType<BackgroundController>();
        foregroundTrees = bgController.gameObject.transform.Find("Montain Front/TreeSpawnPoint");
    }

    void IsGameOver(int time)
    {
        if (time == 0)
        {
            Destroy(foregroundTrees.GetComponent<TreeSpawn>());
            house.Spawn();
            DOTween.To(() => bgController.speed, x => bgController.SetSpeed(x), 0, 4).SetEase(Ease.Linear);
            
            player.GetComponent<Player>().enabled = false;
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(player.transform.DOMove(new Vector3(-3.5f, -3.9f, 1.5f), 3).SetEase(Ease.Linear).SetSpeedBased());
            sequence.Join(player.transform.DOScale(new Vector2(0.3f, 0.3f), 3).SetEase(Ease.Linear).SetSpeedBased());
            sequence.Join(player.GetComponent<SpriteRenderer>().DOColor(Color.gray, 3).SetEase(Ease.Linear));
            sequence.Append(player.transform.DOMove(new Vector3(0, -3.9f, 1.5f), 4).SetEase(Ease.OutQuad).SetSpeedBased());
            sequence.Join(DOTween.To(
                () => player.GetComponent<Animator>().speed,
                x => player.GetComponent<Animator>().speed = x, 0, 4
            ));
            sequence.Append(gameInterface.DOFade(0, 0.2f).SetEase(Ease.Linear));
            sequence.AppendCallback(() => sceneManager.Finish(
                score.candyScore, score.bellScore, score.ornamentScore, score.starScore
            ));
        }
    }
}
