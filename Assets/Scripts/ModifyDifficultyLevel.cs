using TMPro;
using UnityEngine;

public class ModifyDifficultyLevel : MonoBehaviour
{
    public ScriptableObjectDifficulty difficultyLevel;
    public TextMeshProUGUI scoreText;

    public void Increase()
    {
        difficultyLevel.DifficultyLevel++;

        if(difficultyLevel.DifficultyLevel >= 4)
        {
            difficultyLevel.DifficultyLevel = 4;
        }
        scoreText.text = difficultyLevel.DifficultyLevel.ToString();
    }

    public void Decrease()
    {
        difficultyLevel.DifficultyLevel--;

        if (difficultyLevel.DifficultyLevel <= 1)
        {
            difficultyLevel.DifficultyLevel = 1;
        }
        scoreText.text = difficultyLevel.DifficultyLevel.ToString();
    }
}
