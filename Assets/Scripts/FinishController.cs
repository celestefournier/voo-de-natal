using UnityEngine;
using UnityEngine.UI;

public class FinishController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public Text candy, bell, ornament, star;

    void OnEnable()
    {
        candy.text = scoreManager.candy.text;
        bell.text = scoreManager.bell.text;
        ornament.text = scoreManager.ornament.text;
        star.text = scoreManager.star.text;
    }
}
