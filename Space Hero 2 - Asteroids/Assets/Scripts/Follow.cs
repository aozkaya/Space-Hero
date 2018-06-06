﻿

using UnityEngine;
using System.Collections;


public class Follow : MonoBehaviour
{
    // The target we are following
    [SerializeField] private Transform target;
    // The distance in the x-z plane to the target
    private float distance = 10;
    private float initalDistance;
    // the height we want the camera to be above the target
     private float height = 0.05f;

    private float heightDamping = 2;
     private float rotationDamping = 3;
        void Start()
    {
        initalDistance = distance;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!target)
            return;

        // Calculate the current rotation angles
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedRotationAnglex = target.eulerAngles.x;

         float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentRotationAnglex = transform.eulerAngles.x;

         float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        currentRotationAnglex = Mathf.LerpAngle(currentRotationAnglex, wantedRotationAnglex, rotationDamping * Time.deltaTime);


        // Damp the height

          currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // Convert the angle into a rotation
        Quaternion currentRotation = Quaternion.Euler(currentRotationAnglex, currentRotationAngle, 0);


        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= currentRotation* Vector3.forward * distance;


        // Set the height of the camera
         transform.position = new Vector3(transform.position.x, transform.position.y+height, transform.position.z);

        // Always look at the target
        transform.LookAt(target);
        
    }

   
}