using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreTxt;

    private void Start()
    {
        _scoreTxt.text = "Score : 00";

        GLOBALEVENTS.ScoreChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        GLOBALEVENTS.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreTxt.text = "Score : " + score;
    }
}
