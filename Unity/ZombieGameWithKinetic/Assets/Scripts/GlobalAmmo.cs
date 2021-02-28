using UnityEngine;
using UnityEngine.UI;


public class GlobalAmmo : MonoBehaviour
{
    public static int CurrentAmmo;
    public int InternalAmmo;
    public GameObject AmmoDisplay;

    public static int LoadedAmmo;
    public int InternalLoaded;
    public GameObject LoadedDisplay;

    void Update()
    {
        InternalAmmo = CurrentAmmo;
        InternalLoaded = LoadedAmmo;
        AmmoDisplay.GetComponent<Text>().text = "" + InternalAmmo;
        LoadedDisplay.GetComponent<Text>().text = "" + LoadedAmmo;
    }
}

