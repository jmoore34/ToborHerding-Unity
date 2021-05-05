using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI durationText = GameObject.Find("DurationText").GetComponent<TextMeshProUGUI>();
        durationText.text = "Your time: " + TimerController.Instance.Stopwatch.Elapsed.ToString("mm':'ss'.'ff");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
