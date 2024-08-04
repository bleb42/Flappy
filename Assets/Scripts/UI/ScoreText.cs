using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ScoreText : MonoBehaviour
{
    [SerializeField] private ScoreCounter _score;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _score.ScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        _score.ScoreChanged -= UpdateScore;
    }

    private void UpdateScore(int value)
    {
        _text.text = value.ToString();
    }
}