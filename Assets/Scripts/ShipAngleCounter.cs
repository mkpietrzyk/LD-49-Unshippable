using System;
using TMPro;
using UnityEngine;

public class ShipAngleCounter : MonoBehaviour
{
    public void UpdateAngle(float angle)
    {
        string text = $"{angle.ToString("F2")}";
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
