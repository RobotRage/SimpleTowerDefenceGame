using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //colby's code
    
    public GameObject enemy;
    float delay = 3.5f;

    

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        GameObject obj = Instantiate(enemy, transform.position, transform.rotation);

        if (gameObject.name == "SpawnerLeft")
        {
            obj.tag = "EnemyLeft";
        }
        if (gameObject.name == "SpawnerRight")
        {
            obj.tag = "EnemyRight";
        }

        StartCoroutine(Wait(delay));
    }

    //coreroutine
    IEnumerator Wait(float x)
    {
        yield return new WaitForSeconds(x);
        Spawn();
    }
}
