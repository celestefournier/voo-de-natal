using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [HideInInspector]
    public float time = 60;

    Text clock;

    void Start()
    {
        clock = GetComponent<Text>();
        StartCoroutine("TimeLoop");
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
