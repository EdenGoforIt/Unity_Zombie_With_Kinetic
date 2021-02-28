using UnityEngine;
using UnityEngine.UI;

public class GlobalScore : MonoBehaviour
{

    public static int CurrentScore;
    public int InternalScore;
    public GameObject ScoreText;
    public GameObject objectiveCompleteWithScore;

    void Update()
    {
        InternalScore = CurrentScore;
        if (InternalScore > 1000)
        {
            objectiveCompleteWithScore.SetActive(true);
        }
        ScoreText.GetComponent<Text>().text = "" + InternalScore;
    }
}
 