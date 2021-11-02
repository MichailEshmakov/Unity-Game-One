using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private Score _score;

    private void OnEnable()
    {
        _valueText.text = _score.Value.ToString();
        _score.Changed += OnScoreChanged;

    }

    private void OnDisable()
    {
        _score.Changed -= OnScoreChanged;
    }

    private void OnScoreChanged()
    {
        _valueText.text = _score.Value.ToString();
    }
}
