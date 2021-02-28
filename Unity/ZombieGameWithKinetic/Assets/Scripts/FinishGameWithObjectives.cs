using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGameWithObjectives : MonoBehaviour
{
    public GameObject objective1;
    public GameObject objective2;
    public GameObject objective3;
    public GameObject objective4;
    public GameObject objective5;

    private void Update()
    {
        if (objective1.activeSelf && objective2.activeSelf && objective3.activeSelf && objective4.activeSelf && objective5.activeSelf )
        {
            SceneManager.LoadScene(3);
        }
    }
}
