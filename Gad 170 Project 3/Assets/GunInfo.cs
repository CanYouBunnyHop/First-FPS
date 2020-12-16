using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunInfo : MonoBehaviour
{
    public Text gunName;
    public Text ammoCount;

    //public int selectedWeapon;

    //public GunSelection weaponSwitch;


    void Start()
    {
        
    }

    void Update()
    {
        var currentAmmoPistol = GameObject.Find("Pistol").GetComponent<Pistol>().currentAmmo; //Find game object name pistol, get pistol script . variable from script
        var maxAmmoPistol = GameObject.Find("Pistol").GetComponent<Pistol>().maxAmmo;
        ShowAmmo(currentAmmoPistol, maxAmmoPistol);


        var currentAmmoSMG = GameObject.Find("SMG").GetComponent<SmgGun>().currentAmmo;
        var maxAmmoSMG = GameObject.Find("SMG").GetComponent<SmgGun>().maxAmmo;
        ShowAmmo(currentAmmoSMG, maxAmmoSMG);

        var gunNames = GameObject.Find("Gun selection").GetComponent<WeaponSwitch>().selectedWeapon;
        ShowGun(gunNames);
    }

     public void ShowGun (int selectedWeapon)
    {

       if (selectedWeapon == 0)
        {
            gunName.text = "SMG";
        }
        if (selectedWeapon == 1)
        {
            gunName.text = "Pistol";
        }
    } 

    public void ShowAmmo (int currentAmmo, int maxAmmo)
    {
        //smg
       // {
            ammoCount.text = currentAmmo + " / " + maxAmmo;
        //}
        /*if (selectedWeapon == 1) //pistol
        {

        }*/

    }
}
