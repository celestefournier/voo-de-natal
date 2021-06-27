using UnityEngine;

public class GameController : MonoBehaviour
{
    public Timer timer;
    public GameObject player;
    public HouseSpawn house;

    SceneManager sceneManager;
    BackgroundController backgroundController;

    void Start()
    {
        timer.onChangeTime.AddListener(IsGameOver);
        sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
        backgroundController = FindObjectOfType<BackgroundController>();
    }

    void IsGameOver(int time)
    {
        if (time <= 0)
        {
            // bota o jogador no chão
            // chama a casa
            // para o cenário
            // chama o sceneManager.Finish();
        }
    }
}
