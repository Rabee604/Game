using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damageAmount = 1;

    void Start()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "EnemyHand")
        {
            playerHealth.TakeDamage(damageAmount);

            Debug.Log("Jeg er i hit");
        }


    }
}
