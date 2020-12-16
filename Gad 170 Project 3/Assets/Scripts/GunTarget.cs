using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTarget : MonoBehaviour
{
   public int enemyHealth = 50;

   public void TakeDamage(int damage)
   {
       enemyHealth -= damage;
       if(enemyHealth > 0)
       {
           Debug.Log("Alive ! current Health = " + enemyHealth);
       }
       else
       {
           Debug.Log("enemyHealth = " + enemyHealth);
           Debug.Log("damage = " + damage);
           Die();
       }
   }
    void Die()
    {
        Destroy(this.gameObject);
    }
}
