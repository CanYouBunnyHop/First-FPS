using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmgGun : MonoBehaviour
{
    public int damage = 10;
    public float range = 100f;
    public float fireRate = 10f;

    public int maxAmmo = 10;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    private float nextTimeToFire = 0f;
    public ParticleSystem muzzleFlash;
    public Camera fpscamera;

    public Animator animator;
    public AudioSource bang;

    public GunInfo gunInfo;
    void Start()
    {
         bang = GetComponent<AudioSource>();
        if (currentAmmo == -1)
                currentAmmo = maxAmmo;

    }
    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo) //press r when current ammo is not max ammo to reload
        {
            StartCoroutine(Reload());
        }
        if (Input.GetButtonUp("Fire1")) // make sure muzzle flash dont play when not firing
        {
            muzzleFlash.Clear();
            muzzleFlash.Stop();
        }
        if (currentAmmo <= 0)
        {
            muzzleFlash.Clear(); // no muzzle flash when gun have no ammo.
            muzzleFlash.Stop();
        }

        if(isReloading)
            return;
        if(currentAmmo <= 0)
        {
           StartCoroutine(Reload()); //can't call IEnumerator functions normally
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
            Debug.Log("Shoot");
        }
        gunInfo.ShowAmmo(currentAmmo, maxAmmo);
    }
   IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");
        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;

    }

    void Shoot()
    {
        currentAmmo --;
        animator.Play("Recoil");

        muzzleFlash.Play();
        
        RaycastHit hit;
        if (Physics.Raycast(fpscamera.transform.position, fpscamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            GunTarget gunTarget = hit.transform.GetComponent<GunTarget>();
            if (gunTarget != null)
            {
                gunTarget.TakeDamage(damage);
            }

        }
        bang.Play(0);
    }
}
