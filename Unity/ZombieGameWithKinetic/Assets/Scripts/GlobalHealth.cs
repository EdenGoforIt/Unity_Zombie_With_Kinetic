using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GlobalHealth : MonoBehaviour
{

    public static int PlayerHealth = 5;
    public int InternalHealth;
    public GameObject HealthDisplay;

    void Update()
    {
        InternalHealth = PlayerHealth;
        HealthDisplay.GetComponent<Text>().text = "Health: " + PlayerHealth;
        if (PlayerHealth == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}