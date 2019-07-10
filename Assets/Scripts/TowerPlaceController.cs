using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceController : MonoBehaviour
{
    bool placed = false;

    //true if tower is over a valid tower placement zone
    bool canBePlaced = false;

    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        //changed the tower's tag based on if its placed or unplaced
        if(placed)
        {
            gameObject.tag = "Placed";
        }
        else
        {
            gameObject.tag = "Unplaced";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!placed)
        {
            //gets the mouse position
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //sets the tower position to the mouse x and y position
            gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
}
