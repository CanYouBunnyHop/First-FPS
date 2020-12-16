using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPickUp : MonoBehaviour
{
    public float spinSpeed = 100f;
    public int healingValue = 25;

    void Update()
    {
        this.transform.Rotate(0f, 0f, Time.deltaTime * this.spinSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().Heal(healingValue);
            Destroy(this.gameObject);
        }


    }
}