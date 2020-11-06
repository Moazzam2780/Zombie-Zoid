using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieCreaterScript : MonoBehaviour
{
    Animator Anim;
    NavMeshAgent Nav;
    Target targetScript;
    [SerializeField] GameObject Human, Player;
    public float speed = 1.0f;

    public AudioClip ZombieBite;
    public AudioClip StartSound;
    public AudioSource audios;

    bool _reached, _human;
    void Start()
    {
        audios.PlayOneShot(StartSound, 0.2f);

        Anim = GetComponent<Animator>();
        Nav = GetComponent<NavMeshAgent>();
        targetScript = GetComponent<Target>();
        StartCoroutine(ActivateHumanAgain());
    }

    void Update()
    {
        if (Vector3.Distance(this.transform.position, Player.transform.position) < 7)
        {
            _human = true;
        }

        if (!_human)
        {
            Vector3 targetDirection = Human.transform.position - transform.position;
            float singleStep = speed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            Debug.DrawRay(transform.position, newDirection, Color.red);
            transform.rotation = Quaternion.LookRotation(newDirection);

            if (Vector3.Distance(this.transform.position, Human.transform.position) > 2.2f && !targetScript._died)
            {

                _reached = false;
                Anim.SetBool("Bite", false);

            }

            else if (Vector3.Distance(this.transform.position, Human.transform.position) < 2.2 && !_reached)
            {
                _reached = true;
                Debug.Log("Human");
                Anim.SetBool("Bite", true);
                audios.PlayOneShot(ZombieBite, 0.7f);

                StartCoroutine(OffBiting());

            }
        }
        else
        {
           // Human.AddComponent<Rigidbody>();
            Anim.SetBool("Bite", false);
            //Debug.Log("Near");
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
        }



    }
    IEnumerator OffBiting()
    {
        yield return new WaitForSeconds(3.8f);
        Anim.SetBool("Bite", false);
    }

    IEnumerator ActivateHumanAgain()
    {
        Debug.Log("Activate");
        yield return new WaitForSeconds(8f);
        Human.SetActive(true);
        if (!_human)
        {
            Debug.Log("Human false");
            StartCoroutine(ActivateHumanAgain());
        }
    }

}
