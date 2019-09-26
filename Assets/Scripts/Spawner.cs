using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //colby's code
    
    public GameObject enemy;
    public GameObject yellowSunShip;
    public GameObject redSkullShip;
    public GameObject greenCrossShip;
    public GameObject SharkShip;


    bool switches = false;
    GameObject[] enemies;

    float delayMid = 2f;
    float delay = 2f;

    GameObject obj;
    int spawnCount = GlobalVars.WaveNum + 1;

    int spawnCountYellow = (int)Mathf.Floor(GlobalVars.WaveNum / 5);
    int spawnCountRed = (int)Mathf.Floor(GlobalVars.WaveNum/3);
    int spawnCountGreen = (int)Mathf.Floor(GlobalVars.WaveNum / 8);
    int spawnCountShark = (int)Mathf.Floor(GlobalVars.WaveNum / 15);

    void Start()
    {
        Spawn();
    }
    IEnumerator endRound(float rounddelay)
    {
        yield return new WaitForSeconds(rounddelay);
        if(delay > 0.2)
        {
            delay -= 0.05f;
        }
        if (delayMid > 0.2)
        {
            delayMid -= 0.07f;
        }


        switches = false;
        if(gameObject.name == "Spawner")
        {
            spawnCount = (GlobalVars.WaveNum);
        }
        else
        {
            spawnCount = (GlobalVars.WaveNum);
        }
        spawnCountYellow = (int)Mathf.Floor(GlobalVars.WaveNum / 6);
        spawnCountRed = (int)Mathf.Floor(GlobalVars.WaveNum / 3);
        spawnCountGreen = (int)Mathf.Floor(GlobalVars.WaveNum / 8);
        spawnCountShark = (int)Mathf.Floor(GlobalVars.WaveNum / 15);
        Spawn();


        

        //spawnCount = 1 + (GlobalVars.WaveNum);

    }
    private void FixedUpdate()
    {
        if (GlobalVars.Hp_Mid <= 0)
        {
            Destroy(gameObject);
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
    void Spawn()
    {
        if (spawnCount <=0 && enemies.Length <= 0 && spawnCountRed<=0 && spawnCountYellow<=0 && spawnCountGreen<=0 && spawnCountShark <= 0)
        {
            if(switches == false && GlobalVars.Hp_Mid > 0)
            {
                switches = true;
                StartCoroutine(endRound(2.5f));

                if (gameObject.name == "Spawner")
                {
                    GlobalVars.WaveNum++;
                    //print(GlobalVars.WaveNum);
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
            }
            else if(spawnCountRed > 0)
            {
                spawnCountRed--;
                if ((gameObject.name == "SpawnerLeft" | gameObject.name == "SpawnerRight") && GlobalVars.WaveNum == 0)
                {

                }
                else
                {
                    obj = Instantiate(redSkullShip, transform.position, transform.rotation);
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
            }
            else if(spawnCountYellow >0)
            {
                spawnCountYellow--;
                if ((gameObject.name == "SpawnerLeft" | gameObject.name == "SpawnerRight") && GlobalVars.WaveNum == 0)
                {

                }
                else
                {
                    obj = Instantiate(yellowSunShip, transform.position, transform.rotation);
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
            }
            else if (spawnCountGreen > 0)
            {
                spawnCountGreen--;
                if ((gameObject.name == "SpawnerLeft" | gameObject.name == "SpawnerRight") && GlobalVars.WaveNum == 0)
                {

                }
                else
                {
                    obj = Instantiate(greenCrossShip, transform.position, transform.rotation);
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
            }
            else if (spawnCountShark > 0)
            {
                spawnCountShark--;
                if ((gameObject.name == "SpawnerLeft" | gameObject.name == "SpawnerRight") && GlobalVars.WaveNum == 0)
                {

                }
                else
                {
                    obj = Instantiate(SharkShip, transform.position, transform.rotation);
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
            }
            if (gameObject.name != "Spawner")
            {
                StartCoroutine(Wait(delay));
            }
            else
            {
                StartCoroutine(Wait(delayMid));
            }
        }    
    }

    //coreroutine
    IEnumerator Wait(float x)
    {
        yield return new WaitForSeconds(x);
        Spawn();
    }
}
