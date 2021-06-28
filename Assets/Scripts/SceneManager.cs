using System.Collections;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject gamePrefab, backgroundPrefab, menuPrefab, losePrefab, finishPrefab;

    GameObject gameScene, backgroundScene, menuScene, loseScene, finishScene;

    void Start()
    {
        Instantiate(menuPrefab);
        backgroundScene = Instantiate(backgroundPrefab);
    }

    public void GameStart()
    {
        gameScene = Instantiate(gamePrefab);
    }

    public void Lose(int time, int candies, int bells, int ornaments, int stars)
    {
        StartCoroutine(LoseScene(time, candies, bells, ornaments, stars));
    }

    IEnumerator LoseScene(int time, int candies, int bells, int ornaments, int stars)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        Destroy(gameScene);
        loseScene = Instantiate(losePrefab);
        loseScene.GetComponent<LoseController>().Open(time, candies, bells, ornaments, stars);
    }

    public void Finish(int candies, int bells, int ornaments, int stars)
    {
        finishScene = Instantiate(finishPrefab);
        finishScene.GetComponent<FinishController>().SetScore(candies, bells, ornaments, stars);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        gameScene = Instantiate(gamePrefab);
    }

    public void Retry()
    {
        Destroy(backgroundScene);
        Destroy(gameScene);
        backgroundScene = Instantiate(backgroundPrefab);
        gameScene = Instantiate(gamePrefab);
    }
}
