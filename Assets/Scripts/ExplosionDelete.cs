using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDelete : MonoBehaviour
{
    // henlo whoever is reading this
    // im listening to this song > https://www.youtube.com/watch?v=PGNiXGX2nLU&list=PLaJkbLEOiRyt58R1mHt7Pnc2IFyc4jGR9&index=11
    // its pretty good lol love myself some old school classics 
    // anyway back to work 
    void Start()
    {
        if(gameObject.name == "Lightning_Cloud(Clone)")
        {
            StartCoroutine(Wait(0.3f));
        }
        else
        {
            StartCoroutine(Wait(0.2f));
        }

    }

    IEnumerator Wait(float x)
    {
        yield return new WaitForSeconds(x);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
