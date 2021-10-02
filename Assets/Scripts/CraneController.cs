using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject crane;
    [SerializeField] private GameObject craneTop;
    [SerializeField] private GameObject craneMagnetRail;
    [SerializeField] private GameObject craneMagnet;

    public float movementSpeed = 2f;
    public float rotationSpeed = 10f;
    public float horizontalSpeed = 10f;
    public float elevationSpeed = 6f;

    public float movementLimitLeft = -3f;
    public float movementLimitRight = 6.5f;

    public float rotationAngleLimitLeft = -35f;
    public float rotationAngleLimitRight = 35f;

    public float movementLimitForward = -2.96f;
    public float movementLimitBackward = -1.25F;

    public float elevationLimitMin = 6f;
    public float elevationLimitMax = 11.5f;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveCrane("left");
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveCrane("right");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RotateCrane("left");
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            RotateCrane("right");
        }
        //
        // if (Input.GetKey(KeyCode.UpArrow))
        // {
        //     // Move magnet up
        // }
        //
        // if (Input.GetKey(KeyCode.DownArrow))
        // {
        //     // Move magnet down
        // }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveMagnetHorizontally("forward");
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveMagnetHorizontally("back");
        }
    }

    private void MoveCrane(string direction)
    {
        Vector3 currentPosition = crane.transform.localPosition;

        if (direction == "left" && currentPosition.x > movementLimitLeft)
        {
            Vector3 newPosition = new Vector3(-Time.deltaTime * movementSpeed, 0f, 0f);
            crane.transform.Translate(newPosition);
        }

        if (direction == "right" && currentPosition.x < movementLimitRight)
        {
            Vector3 newPosition = new Vector3(Time.deltaTime * movementSpeed, 0f, 0f);
            crane.transform.Translate(newPosition);
        }
    }

    private void RotateCrane(string direction)
    {
        Vector3 currentRotation = craneTop.transform.rotation.eulerAngles;

        if (direction == "left")
        {
            float newAngle = currentRotation.y - (Time.deltaTime * rotationSpeed);
            Quaternion newRotation = Quaternion.Euler(0, newAngle, 0);
            craneTop.transform.rotation = newRotation;
        }

        if (direction == "right")
        {
            float newAngle = currentRotation.y + (Time.deltaTime * rotationSpeed);
            Quaternion newRotation = Quaternion.Euler(0, newAngle, 0);
            craneTop.transform.rotation = newRotation;
        }
    }

    private void MoveMagnetHorizontally(string direction)
    {
        Vector3 currentPosition = craneMagnetRail.transform.localPosition;

        if (direction == "forward" && currentPosition.z > movementLimitForward)
        {
            Vector3 newPosition = new Vector3(0f, 0f, -Time.deltaTime * horizontalSpeed);
            craneMagnetRail.transform.Translate(newPosition);
        }

        if (direction == "back" && currentPosition.z < movementLimitBackward)
        {
            Vector3 newPosition = new Vector3(0f, 0f, Time.deltaTime * horizontalSpeed);
            craneMagnetRail.transform.Translate(newPosition);
        }
    }

    private void MoveMagnetVertically()
    {
    }
}