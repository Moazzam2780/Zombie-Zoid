using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public List<GameObject> EnemyPrefebs = new List<GameObject>();
 
    float ZombieSpawnTime = 10f;
    public int GeneratedCounter = 15;

    public static int zombieCounter = 0;

    [HideInInspector] public bool _GameStart;

    public GameObject EndingGate;

    void Start()
    {
        GameStartBtn();
    }

    public void GameStartBtn()
    {
        _GameStart = true;
    }
    bool _GenerateZombiesOnce;
    private void Update()
    {
        if (!_GenerateZombiesOnce && _GameStart)
        {
            _GenerateZombiesOnce = true;
            StartCoroutine(GenerateOnce());
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
            zombieCounter = 0;
            //Ending Gate
            if(EndingGate != null)
            {
                EndingGate.SetActive(true);
            }

        }
        
    }
    
}
