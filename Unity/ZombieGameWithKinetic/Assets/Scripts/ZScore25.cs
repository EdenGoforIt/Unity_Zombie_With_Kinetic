using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZScore25 : MonoBehaviour
{
    public GameObject ObjectiveComplete;
    void DeductPoints(int DamageAmount)
    {
        GlobalScore.CurrentScore += 25; // must be declared static in Global Score
        ObjectiveComplete.SetActive(true);

    } // end DeductPoints()﻿
}
