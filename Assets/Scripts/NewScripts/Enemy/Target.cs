using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    //Text Score;
    public float health = 100f;
   // public Slider healthSlider;

  //  [SerializeField] GameObject InstantiateItem;

    Animator anim;
    NavMeshAgent Nav;
    [SerializeField] BoxCollider AttackHandCollider;

    bool _dieScore = true; // for score
    [HideInInspector] public bool _died = false; // true when zombie die

    public AudioSource DeathClip;
    // public AudioClip ZombieDeath;
    //  public AudioSource audios;
    Text ScoreText;

    void Start()
    {
        //if (this.gameObject.CompareTag("ZombieCreater"))
        //{
        //    healthSlider.value = health;
        //}
        anim = GetComponent<Animator>();
        Nav = GetComponent<NavMeshAgent>();
        ScoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        //CashText = GameObject.FindGameObjectWithTag("Cash").GetComponent<Text>();
        //  audios = GetComponent<AudioSource>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        //if (this.gameObject.CompareTag("ZombieCreater"))
        //{
        //    healthSlider.value = health;
        //}
        if (health <= 0f)
        {
            _died = true;
            AttackHandCollider.enabled = false;
            //if (this.gameObject.CompareTag("ZombieCreater"))
            //{

            //    GameObject Item = Instantiate(InstantiateItem, this.transform.position, InstantiateItem.transform.rotation) as GameObject;
            //    Item.SetActive(true);
            GlobalVariables.score += 1;
            //    //GlobalVariables.Cash += 20;
            ScoreText.text = "" + GlobalVariables.score;
            //    //CashText.text = "" + GlobalVariables.Cash;
            //    //GlobalVariables.HostageSaved--;
            //    //GlobalVariables.GenerationPoint++;
            //}
            //else
            //{
            //    //GlobalVariables.score += 2;
            //    //GlobalVariables.Cash += 2;
            //    //ScoreText.text = "" + GlobalVariables.score;
            //    //CashText.text = "" + GlobalVariables.Cash;
            //}
            Die();
        }


        if (health <= 50f && _dieScore)
        {
            _dieScore = false;
            anim.SetTrigger("Slow");
            Nav.speed = 0.2f;
        }

    }

    void Die()
    {
        DeathClip.Play();
       // EnemyGenerator.zombieCounter--;
        anim.SetTrigger("Death");
        Destroy(gameObject,3f);
    }
}
