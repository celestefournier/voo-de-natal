using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [HideInInspector]
    public int time;
    [HideInInspector]
    public UnityEvent<int> onChangeTime;

    Text clock;
    SceneManager sceneManager;

    void Start()
    {
        clock = GetComponent<Text>();
        time = 50;
        sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneManager>();
    }

    public void TimerStart()
    {
        StartCoroutine("TimeLoop");
    }

    IEnumerator TimeLoop()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            clock.text = time.ToString();
            onChangeTime.Invoke(time);

            if (time == 0)
            {
                sceneManager.Finish();
            }
        }
    }
}
