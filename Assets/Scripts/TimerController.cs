using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Google.Protobuf.WellKnownTypes;
using TMPro;
using UnityEngine;  

public class TimerController : MonoBehaviour
{
    // Singleton pattern
    public static TimerController Instance { get; private set; }


    public Stopwatch Stopwatch;

    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        Instance = this;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        Stopwatch = new Stopwatch();
        Stopwatch.Restart();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = Stopwatch.Elapsed.ToString("mm':'ss'.'ff");
    }
}
