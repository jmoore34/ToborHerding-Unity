using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ToborController toborController = other.GetComponent<ToborController>();
        if (toborController != null) // i.e. not player, camera, etc.
        {
            toborController.onEnterGarage();
            ScoreController.Instance.Score++;
        }
    }
}
