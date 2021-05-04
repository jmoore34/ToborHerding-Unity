using System;
using System.Collections;
using System.Collections.Generic;
using Google.Protobuf.WellKnownTypes;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    // singleton design pattern
    public static ScoreController Instance { get; private set; }


    public int MaxTobors;

    private TextMeshProUGUI textMesh;
    private int _score;

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            textMesh.text = $"{_score}/{MaxTobors} collected!!!";
        }
    }

    private void Awake()
    {
        Instance = this;
        textMesh = GetComponent<TextMeshProUGUI>();

        Score = 0;
    }
    
}
