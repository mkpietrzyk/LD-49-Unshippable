using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public FloatVariable shipAngle;
    // Start is called before the first frame update
    void Start()
    {
        shipAngle.Value = Mathf.Abs(transform.rotation.eulerAngles.z - 180);
    }

    // Update is called once per frame
    void Update()
    {
        shipAngle.Value = Mathf.Abs(transform.rotation.eulerAngles.z - 180);
    }
}
