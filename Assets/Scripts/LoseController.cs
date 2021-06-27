using UnityEngine;
using UnityEngine.UI;

public class LoseController : MonoBehaviour
{
    public Text timer, candy, bell, ornament, star;

    public void Open(int time, int candies, int bells, int ornaments, int stars)
    {
        timer.text = time.ToString();
        candy.text = $"{candies}/3";
        bell.text = $"{bells}/3";
        ornament.text = $"{ornaments}/3";
        star.text = $"{stars}/1";
    }
}
