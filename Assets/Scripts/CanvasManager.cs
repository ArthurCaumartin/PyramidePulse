using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Rendering;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [Header("In Game :")]
    [SerializeField] private TextMeshProUGUI _scoreTexte;

    [Header("Win / Death Panel :")]
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private TextMeshProUGUI _endScoreTexte;

    [Header("Affection Ref :")]
    [SerializeField] private Image _affectionFillImage;

    void Awake()
    {
        instance = this;
    }

    public void SetEndPanel(int scoreToSet)
    {
        _endGamePanel.SetActive(true);
        _endScoreTexte.text = scoreToSet.ToString();
    }

    public void SetAffectionFill(float value)
    {
        _affectionFillImage.fillAmount = value;
    }

    public void SetScoreTexte(int value)
    {
        _scoreTexte.text = value.ToString();
    }
}
