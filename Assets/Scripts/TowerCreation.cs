using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//RobotRage's Code

public class TowerCreation : MonoBehaviour
{
    //an array of gameobjects which holds all the towers
    //new towers can be added in unity inspector on the "TowerSpawn" object
    public GameObject[] Towers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    //function is called when any button is pressed (must be assigned when new button is created)
    public void CreateTower()
    {
        //array of towers that are not placed
        GameObject[] NotPlacedTowers;

        NotPlacedTowers = GameObject.FindGameObjectsWithTag("Unplaced");

        //if there is an unplaced tower
        if(NotPlacedTowers.Length > 0)
        {
            //delete all unplaced towers
            foreach (GameObject tower in NotPlacedTowers)
            {
                Destroy(tower);
            }
        }
        //if there are no unplaced towers
        else
        {
            //prints the current selected button
            string btnPressed = EventSystem.current.currentSelectedGameObject.name;
            //print(btnPressed);

            //check which button was pressed and spawns the appropriate tower
            if (btnPressed == "btnCreateTower_1")
            {
                Instantiate(Towers[0], new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
    }
}
