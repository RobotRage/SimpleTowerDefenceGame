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
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.20f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
