using UnityEngine;

public class StartButton : MonoBehaviour
{
    [HideInInspector]
    public SceneManager sceneManager;
    public TweenFadeOut menu;

    void Start()
    {
        sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
    }

    public void GameStart()
    {
        menu.Play();
        menu.onComplete.AddListener(() => {
            Destroy(menu.gameObject);
            sceneManager.GameStart();
        });
    }
}
