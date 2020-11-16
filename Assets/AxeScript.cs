using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    public GameObject bulletHole;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BulletHole()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
       // if(collision.gameObject != null)
       // {
            Debug.Log("Bullet Hole");
            GameObject t_newHole = Instantiate(bulletHole, collision.gameObject.transform.position, Quaternion.identity);
          //  t_newHole.transform.LookAt(Player.transform);
            Destroy(t_newHole, 5f);
       // }
    }
}
