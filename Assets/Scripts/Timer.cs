using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [HideInInspector]
    public int time = 50;
    [HideInInspector]
    public UnityEvent<int> onChangeTime;

    Text clock;
    IEnumerator timeLoopController;

    void Start()
    {
        clock = GetComponent<Text>();
    }

    public void StartTimer()
    {
        timeLoopController = TimeLoop();
        StartCoroutine(timeLoopController);
    }

    public void Stop()
    {
        clock.text = "50";
        StopCoroutine(timeLoopController);
    }

    public void Restart()
    {
        time = 50;
        StartTimer();
    }

    IEnumerator TimeLoop()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            clock.text = time.ToString();
            onChangeTime.Invoke(time);
        }
    }
}
