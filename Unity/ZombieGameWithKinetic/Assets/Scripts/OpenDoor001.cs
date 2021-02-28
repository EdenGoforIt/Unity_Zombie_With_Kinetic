using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor001 : MonoBehaviour
{
    public GameObject TextDisplay;
    public GameObject TheDoor;
    public float TheDistance = PlayerCasting.DistanceFromTarget;
    public GameObject ObjectiveComplete;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
       
    }

    void OnMouseOver()
    {
        if (TheDistance <= 3)
        {
            //TextDisplay.GetComponent<Text>().text = "Press 'E' Button to open the door";
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 3)
            {
                StartCoroutine(OpenTheDoor());
                ObjectiveComplete.SetActive(true);
            }
        }
    }

    void OnMouseExit()
    {
        //TextDisplay.GetComponent<Text>().text = "";
    }

    IEnumerator OpenTheDoor()
    {
        TheDoor.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        TheDoor.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(5);
        TheDoor.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        TheDoor.GetComponent<Animator>().enabled = false;
    }

}