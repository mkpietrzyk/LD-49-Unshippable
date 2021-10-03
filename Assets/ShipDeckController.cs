using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class ShipDeckController : MonoBehaviour
{
    public IntVariable containerCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Container"))
        {
            containerCount.Value += 1;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Container"))
        {
            containerCount.Value -= 1;
        }
    }
}
