using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private CanvasManager canvasManager;
    public float kingAffectionChangeValue = 0.05f;
    public float kingAffection = 0.5f;
    public int totalScore;
    public int combo;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        canvasManager.SetAffectionFill(kingAffection);
    }

    public void increaseCombo()
    {
        //0.5,1,2,4,8, prends * 2
    }

    public void AddPoint(int pointToAdd)
    {
        totalScore += pointToAdd * combo;
    }

    public void IncreaseKingAffection()
    {
        kingAffection += kingAffectionChangeValue;
        canvasManager.SetAffectionFill(kingAffection);

        if(kingAffection > 1)
        {
            Debug.LogWarning("THE QUEEN WILL BEAT UR ASS UP !!!!!!!!!!!!!!!!!!!!!!!!!");
        }
    }

    public void DeacreaseKingAffection()
    {
        kingAffection -= kingAffectionChangeValue;
        canvasManager.SetAffectionFill(kingAffection);

        if (kingAffection < 0)
        {
            Debug.LogWarning("U ARE DEAD !!");
        }
    }
}
