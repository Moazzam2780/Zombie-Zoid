using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    Animator Anim;
    NavMeshAgent Nav;
    Target targetScript;
    [SerializeField] BoxCollider RightArm;
    [SerializeField] GameObject Player;

    public AudioClip Walk;
    public AudioSource audios;


    bool _reached;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Nav = GetComponent<NavMeshAgent>();
        targetScript = GetComponent<Target>();
        //Anim.SetBool("Walk", true);
       // audios.PlayOneShot(Walk, 0.2f);
        audios.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, Player.transform.position) > 2.2f && !targetScript._died)
        {
            
            Anim.SetBool("Attack", false);
            Anim.SetBool("Walk", true);
            _reached = false;
            Nav.destination = Player.transform.position;

        }

        else if (Vector3.Distance(this.transform.position, Player.transform.position) < 2.2 && !_reached)
        {
            _reached = true;
            //Debug.Log("Found");
            Anim.SetBool("Walk", false);
            Anim.SetBool("Attack",true);
            audios.Stop();




        }

        if (Anim.GetBool("Attack") == true)
        {
            RightArm.enabled = true;
        }
        else
        {
            RightArm.enabled = false;
        }
        
    }
}
