using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreatedZombieScript : MonoBehaviour
{
    Animator Anim;
    NavMeshAgent Nav;
    Target targetScript;
    [SerializeField] BoxCollider RightArm;
    GameObject Player;


    bool _reached,_waitToGetUp;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Anim = GetComponent<Animator>();
        Nav = GetComponent<NavMeshAgent>();
        targetScript = GetComponent<Target>();
        //Anim.SetBool("Walk", true);
        StartCoroutine(WaitToGetUp());
    }

    // Update is called once per frame
    void Update()
    {
        if (_waitToGetUp)
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
                Anim.SetBool("Attack", true);



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

    IEnumerator WaitToGetUp()
    {
        yield return new WaitForSeconds(8f);

        _waitToGetUp = true;
    }
}
