using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HostageCollisionScript : MonoBehaviour
{
    public float speed = 0.5f; // Movement Speed
    public float RotateSpeed = 0.5f; // Rotation Speed
    int HostageHealth = 100; // Health
    int RandomPos = 4; // Position

    public Slider HostageHealthSlider; // Health Slider
    public Slider HostageScreenHealthSlider; // Health Slider
  //  public CustomTrackableEventHandler customTrackable; // Getting Trakable Script
    public Transform[] movementPoints; // for Hostage Movement Points
    public EnemyGenerator enemyGeneratorScript;

    public GameObject GameOverScreen;
    public Text HScore, GameOverScreenScore, GameOverScreenZombieKilled;

    Animator anim,GunAnimator;

    [HideInInspector] public bool died;
    bool hostageDied;


    public AudioClip HostageDeath;
    public AudioClip HostageScreaming;
    public AudioSource audios;

    void Start()
    {
        HostageHealthSlider.value = HostageHealth; // for health
        HostageScreenHealthSlider.value = HostageHealth; // for health
        anim = GetComponent<Animator>(); // Hostage Animator Controller

        //GlobalVariables.Hscore = PlayerPrefs.GetInt("HScore",0);
        //HScore.text = "" + GlobalVariables.Hscore;

        audios = GetComponent<AudioSource>();

    }

    void Update()
    {
        //if (/*customTrackable._HostageMove*/) // After Generation start movement
        //{
       //     HostageMovement();
       //// }
       // else
       // {
       //     anim.SetTrigger("Idle");
       // }

        //if (HostageHealth <= 0) // For GameOver
        //{
        //    died = true;
        //    HostageDied();
        //}

        if (HostageHealth <= 0 && !hostageDied) // For GameOver
        {
            hostageDied = true; // call this only once
            died = true;
            enemyGeneratorScript._GameStart = false;
            HostageDied();
            GunAnimator = GameObject.FindGameObjectWithTag("Gun").GetComponent<Animator>();
            GunAnimator.SetTrigger("Gameover");
        }
    }
    void LateUpdate()
    {
        //if (HostageHealth == 0 && !hostageDied) // For GameOver
        //{
        //    hostageDied = true; // call this only once
        //    died = true;
        //    enemyGeneratorScript._GameStart = false;
        //    HostageDied();
        //    GunAnimator = GameObject.FindGameObjectWithTag("Gun").GetComponent<Animator>();
        //    GunAnimator.SetTrigger("Gameover");
        //}
    }

    void HostageDied() // when died
    {
        audios.PlayOneShot(HostageDeath, 1f);
        anim.SetTrigger("Died");
        StartCoroutine(GameOver());
       // AdManager.instance.ShowFullScreenAd();
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(5f);
        //GameOverScreenScore.text = "" + GlobalVariables.score;
        //GameOverScreenZombieKilled.text = "" + GlobalVariables.zombieKilled;
        //GameOverScreen.SetActive(true);
        //if(GlobalVariables.score > GlobalVariables.Hscore)
        //{
        //    GlobalVariables.Hscore = GlobalVariables.score;
        //}
        //HScore.text = "" + GlobalVariables.Hscore;
        //PlayerPrefs.SetInt("HScore", GlobalVariables.Hscore);
        // AdScript.instance.ShowAd();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightArm")) // for damage exactly when attempts attack
        {
            //audios.PlayOneShot(HostageScreaming, 0.7f);
            anim.SetTrigger("Damage");
            HostageHealth -= 5;
            HostageHealthSlider.value = HostageHealth;
            HostageScreenHealthSlider.value = HostageHealth;

        }

        if (other.gameObject.CompareTag("MovementPoint")) // when reaches to the point
        {
           // anim.SetTrigger("Idle");
            StartCoroutine(SelectNewPosition());
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MovementPoint")) // when reaches to the point
        {
        }
    }

    IEnumerator SelectNewPosition() // For Random selection of new Position
    {
       // customTrackable._HostageMove = false;
        //anim.SetTrigger("Idle");
        yield return new WaitForSeconds(10f);
        RandomChooser();
        //RandomPos = Random.Range(0, movementPoints.Length);
     //   customTrackable._HostageMove = true;
        // anim.SetTrigger("Walking");
        //yield return new WaitForSeconds(0.5f);
        //anim.SetTrigger("Walking");

    }

    public Text TestingPosValue;
    void RandomChooser()
    {
        int temp;
        temp = RandomPos;
        RandomPos = Random.Range(0, movementPoints.Length);
        TestingPosValue.text = "" + RandomPos;
        if(RandomPos == temp)
        {
            RandomChooser();
        }
        else
        {
            return;
        }
    }

    void HostageMovement() // For movement and rotation
    {
        if (!died)
        {           
            float step = speed * Time.deltaTime; // calculate distance to move

            Vector3 targetDirection = movementPoints[RandomPos].position - transform.position;
            // The step size is equal to speed times frame time.
            float singleStep = RotateSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);

            transform.position = Vector3.MoveTowards(transform.position, movementPoints[RandomPos].position, step);
            anim.SetTrigger("Walking");
            //StartCoroutine(HostageMovement());
        }
        
    }
}
