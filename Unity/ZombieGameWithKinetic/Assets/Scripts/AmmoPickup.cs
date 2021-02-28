using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AmmoPickup : MonoBehaviour
{
    public AudioSource AmmoPickupSound;
    void OnTriggerEnter(Collider other)
    {
        AmmoPickupSound.Play();
        if (GlobalAmmo.LoadedAmmo == 0)
        {
            GlobalAmmo.LoadedAmmo += 10;
            this.gameObject.SetActive(false);
        }
        GlobalAmmo.CurrentAmmo += 10;
        this.gameObject.SetActive(false);
    }
}


