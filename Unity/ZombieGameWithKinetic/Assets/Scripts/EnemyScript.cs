using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public GameObject zombie;
    public int EnemyHealth = 10;

    void DeductPoints(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }

    void Update()
    {
        if (EnemyHealth <= 0)
        {
            this.GetComponent<ZombieFollow>().enabled = false;

            zombie.SetActive(true);

            Destroy(gameObject);

        }
    }

}
  