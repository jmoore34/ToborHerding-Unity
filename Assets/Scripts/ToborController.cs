using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ToborController : MonoBehaviour
{
    // settable fields
    public GameObject player;
    private CharacterController controller;



    float turnSpeed = 5;
    float avoidanceTurnSpeed = 1.5f; // speed to turn when avoid player
    float moveSpeed = 15f;
    float changeDirThreshold = 1f;
    private float toborMeetingPointRadius = 5;
    Vector3 targetDirection; // a normalized vector storing the direction the tobor wants to eventually face

    private bool inGarage = false;
    private GameObject parkingSpot; 

    public void onEnterGarage(int parkingSpotIndex)
    {
        inGarage = true;
        parkingSpot = GameObject.Find(parkingSpotIndex.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        targetDirection = transform.forward.normalized;
    }

    // Update is called once per frame
    void Update()
    {

        float maxRadiansDelta;
        
        Vector3 playerToTobor = (transform.position - player.transform.position);
        // if close, set target direction to away from player
        if (playerToTobor.magnitude <  40)
        {
            targetDirection = playerToTobor.normalized;
            maxRadiansDelta = Time.deltaTime * turnSpeed;

        } else if (inGarage)
        {
            Vector3 toborToMeetingPoint = parkingSpot.transform.position - transform.position;
            if (toborToMeetingPoint.magnitude < toborMeetingPointRadius)
                return;
            else
            {
                maxRadiansDelta = Time.deltaTime * turnSpeed;
                targetDirection = toborToMeetingPoint.normalized;
            }
        } else
        {
            // normal (non-chased) behavior
            maxRadiansDelta = Time.deltaTime * avoidanceTurnSpeed;
            
            if ((targetDirection - transform.forward).magnitude < changeDirThreshold)
            {
                // target direction met, time to choose a new direction
                targetDirection = Quaternion.Euler(0, Random.Range(-45, 45), 0) * targetDirection;
            }
        }
        
        
        // now rotate towards the targetDirection
        transform.forward = Vector3.RotateTowards(transform.forward, targetDirection, maxRadiansDelta, 0);

        // now that the rotation has been set, move forward
        controller.SimpleMove(transform.forward * moveSpeed);
    }
}
