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
        Instantiate(enemy, transform.position, transform.rotation);
        StartCoroutine(Wait(delay));
    }

    //coreroutine
    IEnumerator Wait(float x)
    {
        yield return new WaitForSeconds(x);
        Spawn();
    }
}
