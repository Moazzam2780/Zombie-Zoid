using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePopup : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Popup;

    [SerializeField] float DistanceToPlayer = 8.5f;

    bool Reached;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, Player.transform.position) < DistanceToPlayer)
        {
            if (!Reached)
            {
                Reached = true;
                Popup.SetActive(true);
                Time.timeScale = 0.2f;
            }
        }



    }
}
