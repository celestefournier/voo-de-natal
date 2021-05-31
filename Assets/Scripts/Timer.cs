using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [HideInInspector]
    public float time = 60;

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
        clock.text = "60";
        StopCoroutine(timeLoopController);
    }

    public void Restart()
    {
        time = 60;
        StartTimer();
    }

    IEnumerator TimeLoop()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            clock.text = time.ToString();
        }
    }
}
