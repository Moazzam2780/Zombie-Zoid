using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Gvr.Internal;
using UnityEngine.SceneManagement;

public static class GlobalVariables
{
    public static int score;
}
public class PlayerScript : MonoBehaviour
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

    public ParticleSystem muzzleFlash;
    public AudioSource GunFire;

    public GameObject HospitalBox, Zombie1, Yuku,Doll;
    public Animator BodyAnimator, ChairAnimator;
    public AudioSource BodyAudioSource;

    void Start()
    {
        PlayerHealthText.text = Health + "%";
        PlayerHealthSlider.value = Health;

        controller = GetComponent<CharacterController>();
        HospitalBox.SetActive(false);
        Zombie1.SetActive(false);
        Yuku.SetActive(false);
        Doll.SetActive(false);
        BodyAnimator.enabled = false;
        ChairAnimator.enabled = false;
    }

    void Update()
    {
        if(Health <= 0 && !_died)
        {
            _died = true;
            Debug.Log("GameOver");

        }
        
        ////Touch Button
        if (GvrControllerInput.ClickButtonDown)
        {
            //Debug.Log("Click Button");
            TestingText2.text = "Touch Button Down";
            muzzleFlash.Play();
           
        }
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
        if (other.gameObject.CompareTag("1")) // Player Health
        {
            Debug.Log("1");
            HospitalBox.SetActive(true);
            Zombie1.SetActive(true);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("2")) // Player Health
        {
            Debug.Log("2");
            BodyAnimator.enabled = true;
            BodyAudioSource.Play();
        }
        if (other.gameObject.CompareTag("3")) // Player Health
        {
            Debug.Log("3");
            Doll.SetActive(true);
            StartCoroutine(WaitForseconds());

        }
        if (other.gameObject.CompareTag("Finish")) // Player Health
        {
            Debug.Log("Finish");
            SceneManager.LoadScene(0);
            
        }
    }

    IEnumerator WaitForseconds()
    {
        yield return new WaitForSeconds(2f);
        ChairAnimator.enabled = true;
        yield return new WaitForSeconds(4f);
        Yuku.SetActive(true);
    }

   


}
