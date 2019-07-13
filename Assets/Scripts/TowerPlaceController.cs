using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine.EventSystems;

//RobotRage's Code

public class TowerPlaceController : MonoBehaviour
{
    
    bool placed = false;
    bool flagset = false;
    public int towerCost;

    //true if tower is over a valid tower placement zone
    bool canBePlaced = true;

    int NonvalidHitboxCount = 0;

    private Vector3 mousePos;

    SpriteRenderer m_SpriteRenderer;
    Color col = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NonValidPlaceLocation")
        {
            NonvalidHitboxCount++;
        }
        if (collision.gameObject.tag == "Placed")
        {           
            NonvalidHitboxCount++;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NonValidPlaceLocation")
        {
            NonvalidHitboxCount--;
        }
        if (collision.gameObject.tag == "Placed")
        {        
            NonvalidHitboxCount--;
        }
    }
    IEnumerator EndFrame()
    {
        yield return new WaitForEndOfFrame();
        if (canBePlaced)
        {
            //if mouse 1 clicked and not clicking a UI button
            placed = true;
            GlobalVars.G_Money -= towerCost;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!placed)
        {
            if (NonvalidHitboxCount == 0)
            {
                canBePlaced = true;
                m_SpriteRenderer.color = Color.white;
            }
            else
            {
                canBePlaced = false;
                m_SpriteRenderer.color = col;
            }
        }

        if (!flagset)
        {
            //changed the tower's tag based on if its placed or unplaced
            if (placed)
            {
                if (gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>() != null)
                {
                    //turn off the circle sprite when tower is placed
                    gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                }

                gameObject.tag = "Placed";
                // Stop the tag from being updated or checked again
                // This also serves to allow the circle to be enabled in the future
                flagset = true;
            }
            else
            {
                gameObject.tag = "Unplaced";
            }
        }

        if (!placed)
        {
            //gets the mouse position
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //sets the tower position to the mouse x and y position
            gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                StartCoroutine(EndFrame());
            }
        }
    }
}
