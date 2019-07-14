using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingController : MonoBehaviour
{

    // Colby's Code

    GameObject lasttouched;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        // Create a new ray
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


        // Checks if ray hit something
        if (hit.collider != null)
        {
            // Logic concerning placed buildings
            if (hit.collider.gameObject.tag == "Placed")
            {
                // Checks if this object is not what the mouse was on last frame
                if (lasttouched != hit.collider.gameObject)
                {
                    if (hit.collider.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>() != null)
                    {
                        // Enable the spriterenderer for range circle
                        hit.collider.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                    }
                }

                // Save the obejct the mouse is currently on
                lasttouched = hit.collider.gameObject;

                // Right mouse button
                if (Input.GetMouseButtonDown(1))
                {
                    // Give back half of the original cost
                   
                    GlobalVars.G_Money += hit.collider.gameObject.GetComponent<TowerPlaceController>().towerCost / 2;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        else // Mouse is not on an object
        {
            // Logic concerning placed buildings (where the mouse was on an object last frame)
            if (lasttouched != null && lasttouched.tag == "Placed")
            {
                if (lasttouched.transform.GetChild(0).GetComponent<SpriteRenderer>() != null)
                {
                    // Disable the spriterenderer for range circle
                    lasttouched.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                }
            }

            // Reset the last touched object
            lasttouched = null;
        }

    }
    
}
