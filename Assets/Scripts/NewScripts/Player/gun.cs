using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class gun : MonoBehaviour
{
   // public float damage = 10f;
   // public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false, isShooting = false;
    //   public Text AmmoCounter;
    // public Slider AmmoCounterSlider;
    public Text TestingText;
    // public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    // public ParticleSystem MuzzleFlash2;
    // public GameObject impactEffect, impactEffectB;
    public Transform muzzleFlashPosition;

    private float nextTimeToFire = 0f;

    // public Animator animator;
    // public EnemyGenerator enemyGenerator;
    //  public HostageCollisionScript hostageScript;

    public AudioClip GunShoot;
    //  public AudioClip GunReloading;
    public AudioSource audios;

    // [SerializeField] Text ScoreText;

    //  [SerializeField] int DamageHead, DamageBody, DamageArms;

    void Start()
    {
        if(currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
           // AmmoCounter.text = currentAmmo + "/" + maxAmmo;
          //  AmmoCounterSlider.value = currentAmmo;
        }



        audios = GetComponent<AudioSource>();

        // muzzleFlash.transform.position = muzzleFlashPosition.transform.position;
    }

    void OnEnable()
    {
        isReloading = false;
      //  animator.SetBool("Reloading", false);
        ReloadingBtn();
    }

    void Update()
    {
        //if (Input.GetButton("Fire1"))
        //{
        //    ShootBtn();
        //}
        //if (isReloading)
        //    return;

        //if(currentAmmo <= 0)
        //{
        //    StartCoroutine(Reload());
        //    return;
        //}

        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && Time.time >= nextTimeToFire /*&& enemyGenerator._GameStart && !hostageScript.died*/)
        //{
        //    if (isShooting)
        //    {
        //        return;
        //    }
        //    nextTimeToFire = Time.time + 1f / fireRate;
        //    Shoot();
        //}
        if (GvrControllerInput.ClickButton)
        {
            Debug.Log("Button");
            TestingText.text = "Before Shoot";
            ShootBtn();
        }
        if (GvrControllerInput.AppButton)
        {
            ReloadingBtn();
        }
    }

    public void ShootBtn()
    {
        TestingText.text = "Shoot Btn Start";
        if (isReloading)
            return;

        muzzleFlash.Stop();
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Time.time >= nextTimeToFire)
        {
            if (isShooting)
            {
                return;
            }
            nextTimeToFire = Time.time + 1f / fireRate;
            //animator.SetTrigger("ShootOff");
            Shoot();
        }
    }

    public void ReloadingBtn()
    {
        if (isReloading)
        { return; } 
        
        StartCoroutine(Reload());
        
    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
       // animator.SetBool("Reloading", true);
      //  audios.PlayOneShot(GunReloading, 0.7f);
        yield return new WaitForSeconds(reloadTime - 0.25f);
       // animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(0.25f);

        currentAmmo = maxAmmo;
      //  AmmoCounter.text = currentAmmo + "/" + maxAmmo;
      //  AmmoCounterSlider.value = currentAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        TestingText.text = "Shoot Func Start";
        if (isShooting)
        {
            return;
        }
        isShooting = true;
        //  animator.SetTrigger("Shoot");
        //  audios.PlayOneShot(GunShoot, 0.6f);
       // muzzleFlash.transform.position = muzzleFlashPosition.transform.position; // testing for the position of muzzleflash
        //TestingText.text = "Shoot Func Mid";
        //Instantiate(muzzleFlash, muzzleFlashPosition.transform.position, Quaternion.identity);
        //muzzleFlash.Play();
        // MuzzleFlash2.Play();

        currentAmmo--;
        TestingText.text = "Shoot Func End";
        // AmmoCounter.text = currentAmmo + "/" + maxAmmo;
        //  AmmoCounterSlider.value = currentAmmo;

        //RaycastHit hit;
        //if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        //{
        //    Debug.Log("Name: " + hit.transform.name);

        //    Target target = hit.transform.GetComponentInParent<Target>();
        //    if(target != null)
        //    {
        //        Animator targetAnim = hit.transform.GetComponentInParent<Animator>();
        //        if (hit.transform.CompareTag("HighHealthObject"))
        //        {
        //            //GlobalVariables.score += 3;
        //            //ScoreText.text = "" + GlobalVariables.score;
        //            target.TakeDamage(DamageHead);
        //        }
        //        else if (hit.transform.CompareTag("MidHealthObject"))
        //        {
        //            target.TakeDamage(DamageBody);
        //            targetAnim.SetTrigger("Hit");
        //        }
        //        else if (hit.transform.CompareTag("LowHealthObject"))
        //        {
        //            target.TakeDamage(DamageArms);
        //            targetAnim.SetTrigger("Hit");
        //        }
        //        GameObject impactBGO = Instantiate(impactEffectB, hit.point, Quaternion.LookRotation(hit.normal));
        //        Destroy(impactBGO, 2f);
        //    }
        //    if (hit.rigidbody != null) // for force on shoot
        //    {
        //        hit.rigidbody.AddForce(-hit.normal * impactForce);
        //    }

        // GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        // Destroy(impactGO, 2f);

        //}
        // isShooting = false;

    }
}
