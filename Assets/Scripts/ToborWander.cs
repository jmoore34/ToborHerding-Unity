using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ToborWander : MonoBehaviour
{

    public float turnSpeed = 1;
    public float moveSpeed = 0.5f;
    public float changeDirThreshold = 1f;
    
    
    //public Vector3 targetRotation = Vector3.zero;
    public float targetRotation = 0f;
    private CharacterController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(transform.eulerAngles.y - targetRotation) < changeDirThreshold)
        {
            targetRotation += Random.Range(-90, 90);
            targetRotation = Mathf.Repeat(targetRotation, 360); // wrap around to to 0..360
        }

        float newRotation = Mathf.LerpAngle(transform.eulerAngles.y, targetRotation, Time.deltaTime * turnSpeed);
        transform.eulerAngles = new Vector3(0, newRotation, 0);
        
        controller.SimpleMove(transform.forward * moveSpeed);
    }
}
