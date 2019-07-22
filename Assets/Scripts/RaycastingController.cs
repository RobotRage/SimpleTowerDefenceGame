using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingController : MonoBehaviour
{

    // Colby's Code
    public GameObject InfoBox;
    public GameObject lasttouched;
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

            if (Input.GetMouseButtonDown(0) && hit.collider != null && hit.collider.name != "RaftTower(Clone)" && hit.collider.tag != "OnRaft")
            {
                GlobalVars.CurrentlySelected = hit.collider.gameObject;
                InfoBox.GetComponent<InfoControllertxt>().OnClickTower();
            }
            if (Input.GetMouseButtonDown(0) && hit.collider == null && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                GlobalVars.CurrentlySelected = null;
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (lasttouched != null)
                {
                    if (lasttouched.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>() != null)
                    {
                        lasttouched.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    }

                }
                // Checks if ray hit something
                if (hit.collider != null && hit.collider.name != "RaftTower(Clone)")
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
    
}
