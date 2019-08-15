using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentRemove : MonoBehaviour
{
    SpriteRenderer sprender;
    // Start is called before the first frame update
    void Start()
    {
        sprender = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Unplaced" )
        {
            sprender.enabled = false;
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Placed")
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Unplaced")
        {
            sprender.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
