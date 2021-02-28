using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

 
    public void DoQuit()
    {
        EditorApplication.isPlaying = false;
        
        Application.Quit();
    }


}

