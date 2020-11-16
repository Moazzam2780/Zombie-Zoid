using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript1 : MonoBehaviour
{
    [SerializeField] GameObject impactEffect, TableImpact;
    public AudioSource AxeHit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LowHealthObject"))
        {
            AxeHit.Play();
            Debug.Log("Low Health Object");

            Target target = other.transform.GetComponentInParent<Target>();
            Animator targetAnim = other.transform.GetComponentInParent<Animator>();
            if (target != null)
            {
                target.TakeDamage(20f);
                targetAnim.SetTrigger("Hit");
            }
            GameObject impactGO = Instantiate(impactEffect, other.transform.position, other.transform.rotation);
            Destroy(impactGO, 2f);
        }
        else if (other.gameObject.CompareTag("MidHealthObject"))
        {
            AxeHit.Play();
            Debug.Log("Mid Health Object");
            Target target = other.transform.GetComponentInParent<Target>();
            Animator targetAnim = other.transform.GetComponentInParent<Animator>();

            if (target != null)
            {
                target.TakeDamage(50f);
                targetAnim.SetTrigger("Hit");
            }
            GameObject impactGO = Instantiate(impactEffect, other.transform.position, other.transform.rotation);
            Destroy(impactGO, 2f);
        }
        else if (other.gameObject.CompareTag("HighHealthObject"))
        {
            AxeHit.Play();
            Debug.Log("High Health Object");

            Target target = other.transform.GetComponentInParent<Target>();
            Animator targetAnim = other.transform.GetComponentInParent<Animator>();

            if (target != null)
            {
                target.TakeDamage(100f);
                targetAnim.SetTrigger("Hit");
            }
            GameObject impactGO = Instantiate(impactEffect, other.transform.position, other.transform.rotation);
            Destroy(impactGO, 2f);
        }
        if (other.gameObject.CompareTag("Table"))
        {
            Debug.Log("Table");

           // Target target = other.transform.GetComponentInParent<Target>();
           // Animator targetAnim = other.transform.GetComponentInParent<Animator>();
            //if (target != null)
            //{
            //    target.TakeDamage(20f);
            //    targetAnim.SetTrigger("Hit");
            //}
            GameObject impactGO = Instantiate(TableImpact, other.transform.position, other.transform.rotation);
            Destroy(impactGO, 2f);
        }

    }
}
