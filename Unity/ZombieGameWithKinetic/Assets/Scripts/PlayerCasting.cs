using UnityEngine;

public class PlayerCasting : MonoBehaviour
{

    public static float DistanceFromTarget;
    public float ToTarget;
   
    private void Start()
    {
        
    }

    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            ToTarget = hit.distance;
            DistanceFromTarget = ToTarget;
        }
    }
}

