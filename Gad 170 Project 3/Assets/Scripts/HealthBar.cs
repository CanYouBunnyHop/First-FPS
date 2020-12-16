using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // need to uses this to reference that this is UI

public class HealthBar : MonoBehaviour
{
    public Gradient gradient;
    public Slider slider; // Need to drag the slider component in here
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health; //slider starts with max health
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue); // normalized made the value 0 to 1
    }
}
