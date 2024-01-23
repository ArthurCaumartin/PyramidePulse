using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [Header("In Game :")]
    [SerializeField] private TextMeshProUGUI _scoreTexte;
    [SerializeField] private GameObject actualScoreText;
    [SerializeField] private Transform positionThatScoreGoesTo;

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

    public void SetScoreTexte(int score, int toAdd, Vector3 chordPos)
    {
        GameObject actualPoppingScore = Instantiate(actualScoreText, Camera.main.WorldToScreenPoint(chordPos), Quaternion.identity, transform);
        actualPoppingScore.GetComponent<TextMeshProUGUI>().text = toAdd.ToString();
        actualPoppingScore.transform.DOMove(new Vector2(Camera.main.WorldToScreenPoint(chordPos).x + 100, Camera.main.WorldToScreenPoint(chordPos).y + Random.Range(-50, 50)), 0.25f)
            .OnComplete(() => actualPoppingScore.transform.DOMove(positionThatScoreGoesTo.position, 0.25f)
            .OnComplete(() =>
            {
                Destroy(actualPoppingScore);
                _scoreTexte.text = score.ToString();
            }));
        
    }
}
