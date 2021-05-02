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



    public float turnSpeed = 1;
    public float moveSpeed = 0.5f;
    public float changeDirThreshold = 1f;

    //public Vector3 targetRotation = Vector3.zero;
    public float targetRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (Math.Abs(distance) <  Random.Range(30, 60))
        {
            Vector3 vectorToPlayer = (transform.position - player.transform.position);
            Vector3 playerPos = player.transform.position;
            float degree = (float)(Math.PI * 0.25);
            Vector3.RotateTowards(vectorToPlayer, playerPos, degree, 1);
            controller.SimpleMove(vectorToPlayer*moveSpeed);
            Debug.Log("near player");
        } else
        {
            // go to random vector
            Vector3 targetPosition = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
            transform.Translate(targetPosition);
            controller.SimpleMove(transform.forward * moveSpeed);
        }
    }
}
