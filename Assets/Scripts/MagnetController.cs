using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;
using UnityEngine;

public class MagnetController : MonoBehaviour
{
    [SerializeField] private bool isGoingDown = false;
    [SerializeField] private bool isHoldingContainer = false;
    [SerializeField] private bool droppedContainer = false;
    [SerializeField] private GameObject containerCaught;

    private void Update()
    {
        RaycastHit hit;
        Vector3 containerPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
        Vector3 returnVector = new Vector3(transform.localPosition.x, 11.5f, transform.localPosition.z);


        if (Physics.SphereCast(transform.position, 0.1f, transform.TransformDirection(Vector3.down), out hit))
        {
            if (hit.transform.CompareTag("Container") && !isHoldingContainer)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    containerPosition.y = hit.transform.position.y;
                    isGoingDown = true;
                    droppedContainer = false;
                }
            }
        }

        if (isGoingDown)
        {
            Vector3 magnetY = new Vector3(0, transform.localPosition.y, 0);
            if (Vector3.Distance(magnetY, containerPosition) > 5.5f)
            {
                transform.localPosition =
                    Vector3.MoveTowards(transform.localPosition, containerPosition, Time.deltaTime * 6f);
            }
            else
            {
                isGoingDown = false;
                isHoldingContainer = true;
            }
        }

        if (isHoldingContainer)
        {
            transform.localPosition =
                Vector3.MoveTowards(transform.localPosition, returnVector, Time.deltaTime * 6f);
        }

        if (isHoldingContainer && !droppedContainer && Input.GetKeyDown(KeyCode.Space))
        {
            droppedContainer = true;
            isHoldingContainer = false;
            containerCaught.transform.parent = null;
            containerCaught.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!droppedContainer && other.CompareTag("Container"))
        {
            other.transform.parent = transform;
            containerCaught = other.gameObject;
            containerCaught.transform.localPosition = new Vector3(0f, -0.9f, 0f);
            containerCaught.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
