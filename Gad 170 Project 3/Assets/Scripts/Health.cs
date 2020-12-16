using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//This script component will give health behavior to any object it is applied to. 
//Use the inspector to set the object starting health. 
//Call the TakeDamage function to take damage from the health.
//When the object dies it will call the objectHasDied Event.
//Use the inspector to have this event call other function on other scripts. 

public class Health : MonoBehaviour
{
    public int currentHealth;
    public UnityEvent objectHasDied;

    public HealthBar healthBar; // drag healbar from hierachy into inspector to reference

    public int maxHealth = 50;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int DamageToTake)
    {
        currentHealth -= DamageToTake;
        healthBar.SetHealth(currentHealth);
        
    }

    public void Heal(int HealingToTake)
    {
        currentHealth += HealingToTake;
        healthBar.SetHealth(currentHealth);
    }
    
    void Update() // I moved the following script from TakeDamage to update, or the gameobject wont be destroyed
    {
        if (currentHealth < 0)
        {
            objectHasDied.Invoke();
            Destroy(this.gameObject);
        }
    }
}

