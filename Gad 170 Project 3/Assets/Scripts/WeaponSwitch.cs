using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    public GunInfo gunInfo;
    public int selectedWeapon = 0;
    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

     if (Input.GetAxis("Mouse ScrollWheel")> 0f) //mouse wheel up
     {
         if(selectedWeapon >= transform.childCount -1) //loop laodout around, it doesnt get stuck
            selectedWeapon = 0;
         else
            selectedWeapon++;
     }
     if (Input.GetAxis("Mouse ScrollWheel")< 0f) // mouse wheel down
     {
         if(selectedWeapon <= 0)
            selectedWeapon = transform.childCount -1; //loop laodout around, it doesnt get stuck
         else
            selectedWeapon--;
     }
    
     if(Input.GetKeyDown(KeyCode.Alpha1))
     {
         selectedWeapon = 0;

     }

     if(Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
     {
         selectedWeapon = 1;

     }

     if (previousSelectedWeapon != selectedWeapon)
     {
         SelectWeapon();
     }

        gunInfo.ShowGun(selectedWeapon);

    }
    void SelectWeapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
