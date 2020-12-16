using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : MonoBehaviour
{
    public int biteDamage = 5;

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Collison");

        if(collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Health>() == true)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(biteDamage);
            }
        }
        
    }

}


