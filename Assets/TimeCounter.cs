using System;
using TMPro;
using UnityEngine;


public class TimeCounter : MonoBehaviour
{
    public void UpdateCount(float time)
    {
        string text = $"{time:D2} : 00";
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
