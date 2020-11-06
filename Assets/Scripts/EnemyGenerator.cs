using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] spawnPoints;

   // public List<GameObject> AllEnemy = new List<GameObject>();
    public List<GameObject> EnemyPrefebs = new List<GameObject>();
  //  public List<GameObject> BossEnemyPrefebs = new List<GameObject>();

   // public CustomTrackableEventHandler customTrackable;

   // bool L2, L3, L4, L5, L6, L7, L8, L9, L10, L11;
    //public float TimeLessFromZombieSpawnTime = 1f;
    float ZombieSpawnTime = 10f;
    //  float BossZombieSpawnTime = 15f;

    //public Text testingPoints;
    //[SerializeField] GameObject shootPanel;
    //[SerializeField] GameObject Gun;
    //[SerializeField] GameObject GameStartButton;

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

    void LateUpdate()
    {
        //if (GlobalVariables.score == 20 && !L2) // Layer 2
        //{
        //    L2 = true;
        //    EnemyPrefebs.Add(AllEnemy[1]); //Adding second enemy type
        //    ZombieSpawnTime -= 1f; //Recuding time for normal zombie generation layer (4)
        //}
        //else if (GlobalVariables.score == 40 && !L3) // Layer 3
        //{
        //    L3 = true;
        //    EnemyPrefebs.Add(AllEnemy[2]); //Adding 3rd enemy type
        //    ZombieSpawnTime -= 1f; //Recuding time for normal zombie generation layer (3)
        //}
        //else if (GlobalVariables.score == 60 && !L4) // Layer 4
        //{
        //    L4 = true;
        //    StartCoroutine(BossEnemyGeneration()); // calling boss zombie function
        //    ZombieSpawnTime += 3f; //Recuding time for normal zombie generation layer (6)
        //}
        //else if (GlobalVariables.score == 80 && !L5) // Layer 4
        //{
        //    L5 = true;
        //    ZombieSpawnTime -= 1f; //Recuding time for normal zombie generation layer (5)
        //    BossZombieSpawnTime -= TimeLessFromZombieSpawnTime; //Recuding time for Boss zombie generation layer (14)
        //}
        //else if (GlobalVariables.score == 100 && !L6) // Layer 5
        //{
        //    L6 = true;
        //    BossEnemyPrefebs.Add(AllEnemy[4]); //Adding second boss type
        //}
        //else if (GlobalVariables.score == 120 && !L7) // Layer 6
        //{
        //    L7 = true;
        //    BossZombieSpawnTime -= 2f; //Recuding time for Boss zombie generation layer (12)
        //}
        //else if (GlobalVariables.score == 140 && !L8) // Layer 7
        //{
        //    L8 = true;
        //    BossZombieSpawnTime -= 2f; //Recuding time for Boss zombie generation layer (10)
        //}
        //else if (GlobalVariables.score == 160 && !L9) // Layer 8
        //{
        //    L9 = true;
        //    ZombieSpawnTime -= 0.5f; //Recuding time for normal zombie generation layer (4.5)
        //   // BossZombieSpawnTime -= 1f; //Recuding time for Boss zombie generation layer (9)
        //}
        //else if (GlobalVariables.score == 180 && !L10) // Layer 9
        //{
        //    L10 = true;
        //    BossZombieSpawnTime -= 1f; //Recuding time for Boss zombie generation layer (9)
        //}
        //else if (GlobalVariables.score == 200 && !L11) // Layer 9
        //{
        //    L11 = true;
        //    ZombieSpawnTime -= 0.5f; //Recuding time for normal zombie generation layer (4)
        //    BossZombieSpawnTime -= 2f; //Recuding time for Boss zombie generation layer (7)
        //}
    }
    IEnumerator EnemyGeneration()
    {
        if (zombieCounter <= 20)
        {
            int RandomValue = Random.Range(0, spawnPoints.Length);
            int RandomZombie = Random.Range(0, EnemyPrefebs.Count);
            GameObject Enemy = Instantiate(EnemyPrefebs[RandomZombie], spawnPoints[RandomValue].transform.position, spawnPoints[RandomValue].transform.rotation) as GameObject;
            zombieCounter++;
            // audios.PlayOneShot(ZombieGeneration, 0.7f);
            yield return new WaitForSeconds(ZombieSpawnTime);

            StartCoroutine(EnemyGeneration());
        }
    }

    //IEnumerator BossEnemyGeneration()
    //{
        
    //    int RandomValue = Random.Range(0, spawnPoints.Length);
    //    int RandomZombie = Random.Range(0, BossEnemyPrefebs.Count);
    //    GameObject Enemy = Instantiate(BossEnemyPrefebs[RandomZombie], spawnPoints[RandomValue].transform.position, spawnPoints[RandomValue].transform.rotation) as GameObject;
    //  //  audios.PlayOneShot(ZombieBossGeneration, 0.7f);
    //    yield return new WaitForSeconds(BossZombieSpawnTime);
    //    StartCoroutine(BossEnemyGeneration());
    //}

}
