using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //colby's code
    
    public GameObject enemy;
    public GameObject enemyTank;
    public GameObject enemySpeed;
    public GameObject enemyHeckingChonker;

    bool switches = false;
    GameObject[] enemies;

    float delayMid = 3f;
    float delay = 3f;

    GameObject obj;
    int spawnCount = GlobalVars.WaveNum + 1;

    void Start()
    {
        Spawn();
    }
    IEnumerator endRound(float rounddelay)
    {

        yield return new WaitForSeconds(rounddelay);
        switches = false;
        if(gameObject.name == "Spawner")
        {
            spawnCount = (GlobalVars.WaveNum * 2) + 1;
        }
        else
        {
            spawnCount = (GlobalVars.WaveNum) + 1;
        }

        Spawn();




        //spawnCount = 1 + (GlobalVars.WaveNum);

    }
    private void FixedUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    void Spawn()
    {
        if (spawnCount <=0 && enemies.Length <= 0)
        {
            if(switches == false)
            {
                switches = true;
                StartCoroutine(endRound(5));

                if (gameObject.name == "Spawner")
                {
                    GlobalVars.WaveNum++;
                    print(GlobalVars.WaveNum);
                }
            }

        }
        else
        {
            if (spawnCount > 0)
            {
                spawnCount--;


                if ((gameObject.name == "SpawnerLeft" | gameObject.name == "SpawnerRight") && GlobalVars.WaveNum == 0)
                {

                }
                else
                {
                    obj = Instantiate(enemy, transform.position, transform.rotation);
                }



                if (gameObject.name == "SpawnerLeft")
                {
                    if (obj != null)
                    {
                        obj.tag = "EnemyLeft";
                    }


                }
                if (gameObject.name == "SpawnerRight")
                {
                    if (obj != null)
                    {
                        obj.tag = "EnemyRight";
                    }

                }
                if (gameObject.name == "Spawner")
                {
                    if (delay >= 1)
                    {
                        delayMid = delay - 1;

                    }
                }

            }
            StartCoroutine(Wait(delayMid));
        }    
    }

    //coreroutine
    IEnumerator Wait(float x)
    {
        yield return new WaitForSeconds(x);
        Spawn();
    }
}
