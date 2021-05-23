using UnityEngine;
using UnityEngine.UI;

public class CollectablesManager : MonoBehaviour
{
    public Text candy, bell, ornament, star;

    int candyScore, bellScore, ornamentScore, starScore;

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
}
