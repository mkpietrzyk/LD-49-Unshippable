using TMPro;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class EndText : MonoBehaviour
{
    public BoolVariable gameEnded;
    public IntVariable containersCount;
    public IntVariable containersGoal;
    public FloatVariable timeLeft;
    public FloatVariable shipAngle;
    private void Update()
    {
        if (gameEnded.Value && (timeLeft.Value < 0 || shipAngle.Value > 30))
        {
            string text = "";
            if (timeLeft.Value < 0)
            {
                text = "Time's up! You haven't shipped stuff in time... Try again!";
            } else if (shipAngle.Value > 30)
            {
                text = "Whoops! You tripped the ship! They're unstable beasts... Try again!";
            }
            TextMeshProUGUI ugui = GetComponent<TextMeshProUGUI>();
            TextMeshPro gameUI = GetComponent<TextMeshPro>();
            if (ugui)
            {
                GetComponent<TextMeshProUGUI>().text = text;
            
            }
            if (gameUI)
            {
                GetComponent<TextMeshPro>().text = text;    
            }
        }

        if (gameEnded.Value && containersCount.Value == containersGoal.Value && shipAngle.Value < 30 && timeLeft.Value > 0)
        {
            string text = "Hooray! You collected all containers and did not trip the ship in time! Well Done!";
            
            TextMeshProUGUI ugui = GetComponent<TextMeshProUGUI>();
            TextMeshPro gameUI = GetComponent<TextMeshPro>();
            if (ugui)
            {
                GetComponent<TextMeshProUGUI>().text = text;
            
            }
            if (gameUI)
            {
                GetComponent<TextMeshPro>().text = text;    
            }
        }
    }
}
