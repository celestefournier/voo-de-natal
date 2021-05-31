using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text candy, bell, ornament, star;

    [HideInInspector]
    public int candyScore, bellScore, ornamentScore, starScore;

    public void PickItem(string name)
    {
        if (name == "Candy Item")
        {
            candyScore++;
            candy.text = $"{candyScore}/3";
        }
        if (name == "Bell Item")
        {
            bellScore++;
            bell.text = $"{bellScore}/3";
        }
        if (name == "Ornament Item")
        {
            ornamentScore++;
            ornament.text = $"{ornamentScore}/3";
        }
        if (name == "Star Item")
        {
            starScore++;
            star.text = $"{starScore}/1";
        }
    }

    public void Restart()
    {
        candyScore = 0;
        bellScore = 0;
        ornamentScore = 0;
        starScore = 0;

        candy.text = $"{candyScore}/3";
        bell.text = $"{bellScore}/3";
        ornament.text = $"{ornamentScore}/3";
        star.text = $"{starScore}/1";
    }
}
