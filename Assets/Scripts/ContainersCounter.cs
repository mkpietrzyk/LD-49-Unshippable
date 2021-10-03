using System;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class ContainersCounter : MonoBehaviour
{
    public IntVariable containersGoal;
    public void UpdateCount(int count)
    {
        string text = $"{count:D2}/{containersGoal.Value:D2}";
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