using UnityEngine;
using UnityEngine.UI;

public class LoseController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Timer timer;
    public Text time, candy, bell, ornament, star;

    void OnEnable()
    {
        time.text = timer.time.ToString();
        candy.text = scoreManager.candy.text;
        bell.text = scoreManager.bell.text;
        ornament.text = scoreManager.ornament.text;
        star.text = scoreManager.star.text;
    }
}
