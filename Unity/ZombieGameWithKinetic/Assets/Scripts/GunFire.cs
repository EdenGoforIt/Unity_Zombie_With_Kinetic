using UnityEngine;

public class GunFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalAmmo.LoadedAmmo >= 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                AudioSource gunsound = GetComponent<AudioSource>();
                gunsound.Play();
                GetComponent<Animation>().Play("GunShot");
                GlobalAmmo.LoadedAmmo -= 1;
            }
        }
       

    }
}
