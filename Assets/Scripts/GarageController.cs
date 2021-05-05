using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GarageController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ToborController toborController = other.GetComponent<ToborController>();
        if (toborController != null) // i.e. not player, camera, etc.
        {
            toborController.onEnterGarage(ScoreController.Instance.Score); // i.e. 0th tobor gets parking spot index 0, and so on
            ScoreController.Instance.Score++;
            if (ScoreController.Instance.Score >= ScoreController.Instance.MaxTobors)
            {
                TimerController.Instance.Stopwatch.Stop();
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
