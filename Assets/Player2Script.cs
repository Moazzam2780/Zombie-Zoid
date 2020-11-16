using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2Script : MonoBehaviour
{
    public Text TestingText2;

    [Header("Player Items")]
    int Health = 100;
    bool _died, _walk;
    [SerializeField] Text PlayerHealthText;
    [SerializeField] Slider PlayerHealthSlider;

    public float speed = 3.5f;

    private float gravity = 10f;

    private CharacterController controller;

   // public ParticleSystem muzzleFlash;
    public AudioSource GunFire;

    
    public Animator BodyAnimator, QaAnimator, DesignAnimator;
    public AudioSource QaAudioSource, Qa2AudioSource, BodyAudioSource, ZombieSound;

    public GameObject GVRController, EnemyGenerator;

    void Start()
    {
        PlayerHealthText.text = Health + "%";
        PlayerHealthSlider.value = Health;

        controller = GetComponent<CharacterController>();
       // HospitalBox.SetActive(false);
        
      
       
        BodyAnimator.enabled = false;
        
        QaAnimator.enabled = false;
        DesignAnimator.enabled = false;
        EnemyGenerator.SetActive(false);
    }

    void Update()
    {
        if (Health <= 0 && !_died)
        {
            _died = true;
            Debug.Log("GameOver");
            GVRController.SetActive(false);
            SceneManager.LoadScene(0);
        }

        ////Touch Button
        //if (GvrControllerInput.ClickButtonDown)
        //{
        //    //Debug.Log("Click Button");
        //    TestingText2.text = "Touch Button Down";
        //    muzzleFlash.Play();
        //}
        #region Touch Walk
        //if (GvrControllerInput.ClickButtonDown)
        //{
        // Top and bottom movement
        //if (GvrControllerInput.TouchPos.x > 0.3 && GvrControllerInput.TouchPos.x < 0.7)
        //    {
        //        if(GvrControllerInput.TouchPos.y < 0.3)
        //        {
        //            Debug.Log("Controller Top");
        //            this.transform.position += this.transform.forward * 0.2f;
        //        }
        //        if(GvrControllerInput.TouchPos.y > 0.7)
        //        {
        //            Debug.Log("Controller Down");
        //            this.transform.position -= this.transform.forward * 0.2f;
        //        }
        //    }
        //    // Left And Right movement
        //    if(GvrControllerInput.TouchPos.y > 0.3 && GvrControllerInput.TouchPos.y < 0.7)
        //    {
        //        if(GvrControllerInput.TouchPos.x < 0.3)
        //        {
        //            Debug.Log("Controller Left");
        //            this.transform.Rotate(0, -45,0);
        //            //this.transform.position += this.transform.forward * 0.1f;
        //        }
        //        if(GvrControllerInput.TouchPos.x > 0.7)
        //        {
        //            Debug.Log("Controller Right");
        //            this.transform.Rotate(0, 45, 0);
        //            //this.transform.position -= this.transform.forward * 0.1f;
        //        }
        //    }
        // }
        #endregion

        #region Button Walk
        if (GvrControllerInput.AppButtonDown)
        {
            Debug.Log("Controller Top");
            _walk = true;

        }
        if (GvrControllerInput.AppButtonUp)
        {
            _walk = false;
        }

        if (_walk)
        {
            Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }

        PlayerMovement();


        #endregion

    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightArm")) // Player Health
        {
            Debug.Log(Health);
            Health -= 5;
            // BloodEffectAnim.SetTrigger("Hit");
            PlayerHealthText.text = Health + "%";
            PlayerHealthSlider.value = Health;
            //audios.PlayOneShot(Hit, 0.7f);

        }
        if (other.gameObject.CompareTag("1")) 
        {
            Debug.Log("1");
            QaAnimator.enabled = true;
            Qa2AudioSource.Play();
            StartCoroutine(WaitForseconds());
           // Zombie1.SetActive(true);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("2")) 
        {
            Debug.Log("2");
            DesignAnimator.enabled = true;
            QaAudioSource.Play();
        }
        if (other.gameObject.CompareTag("3")) 
        {
            Debug.Log("3");
            BodyAnimator.enabled = true;
            EnemyGenerator.SetActive(true);
            BodyAudioSource.Play();
            ZombieSound.Play();
        }
        if (other.gameObject.CompareTag("Finish")) 
        {
            Debug.Log("Finish");
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator WaitForseconds()
    {
        yield return new WaitForSeconds(1f);
        QaAudioSource.Play();
        //ChairAnimator.enabled = true;
        //yield return new WaitForSeconds(4f);
        //Yuku.SetActive(true);
    }
}
