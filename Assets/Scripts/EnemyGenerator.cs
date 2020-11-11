using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] spawnPoints, spawnPoints2;
    public List<GameObject> EnemyPrefebs = new List<GameObject>();
 
    float ZombieSpawnTime = 10f;
    public int GeneratedCounter = 15;

    public static int zombieCounter = 0;

    [HideInInspector] public bool _GameStart;

  //  public Text Timer, PauseScreenTimer, GameOverScreenTimer;
  //  float startTime = 0;

    //public AudioClip ZombieGeneration;
    // public AudioClip ZombieBossGeneration;
   // public AudioClip BackgroundZombieSound;
   // public AudioSource audios;

    void Start()
    {
        //shootPanel.SetActive(false);
        //Gun.SetActive(false);
        //GameStartButton.SetActive(false);

       // startTime = Time.time;

        //audios = GetComponent<AudioSource>();

       // audios.PlayOneShot(BackgroundZombieSound, 0.6f);

        GameStartBtn();
    }

    public void GameStartBtn()
    {
        _GameStart = true;
        //shootPanel.SetActive(true);
        //Gun.SetActive(true);
        //GameStartButton.SetActive(false);
    }
    bool _GenerateZombiesOnce;
    private void Update()
    {
        if (!_GenerateZombiesOnce && _GameStart)
        {
            _GenerateZombiesOnce = true;
           // customTrackable._generate = false;

            // StartCoroutine(EnemyGeneration());
            // StartCoroutine(EnemyGeneration());
            StartCoroutine(GenerateOnce());
           // check = true;
               

        }

      //  if (_GameStart)
      //  {
          //  startTime += Time.deltaTime;
           // float t = Time.time - startTime;

          //  string minutes = ((int)startTime / 60).ToString("00");
          //  string seconds = (startTime % 60).ToString("00");

            //Timer.text = "" + minutes + ":" + seconds;
            //PauseScreenTimer.text = "" + minutes + ":" + seconds;
            //GameOverScreenTimer.text = "" + minutes + ":" + seconds;
      //  }
    }

    IEnumerator GenerateOnce()
    {
        StartCoroutine(EnemyGeneration());
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(EnemyGeneration());
    }


    IEnumerator EnemyGeneration()
    {
        if (zombieCounter <= GeneratedCounter)
        {
            int RandomValue = Random.Range(0, spawnPoints.Length);
            int RandomZombie = Random.Range(0, EnemyPrefebs.Count);
            GameObject Enemy = Instantiate(EnemyPrefebs[RandomZombie], spawnPoints[RandomValue].transform.position, spawnPoints[RandomValue].transform.rotation) as GameObject;
            zombieCounter++;
            yield return new WaitForSeconds(ZombieSpawnTime);

            StartCoroutine(EnemyGeneration());
        }
        else
        {
            //Ending Gate
        }
        
    }
    
}
