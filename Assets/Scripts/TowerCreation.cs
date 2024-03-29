﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//RobotRage's Code

public class TowerCreation : MonoBehaviour
{
    public AudioClip mouseClick;
    public AudioClip Error;
    AudioSource UIAudio;
    public GameObject AudioObjUI;


    public GameObject infoBox;
    
    public GameObject minimiseGUI;
    //an array of gameobjects which holds all the towers
    //new towers can be added in unity inspector on the "TowerSpawn" object
    public GameObject[] Towers;

    public class TowerStats
    {
        public string TowerName;
       public  GameObject TowerObj;
        public int TowerCost;
    }


    //list of all the tower class objects
    List<TowerStats> TowerClasses = new List<TowerStats>();

    // Start is called before the first frame update
    void Start()
    {
        //YOU MUST INITIALISE TOWERS HERE
        //TOWER NAME MUST BE THE SAME AS THE BUTTON NAME

        UIAudio = AudioObjUI.GetComponent<AudioSource>();

        TowerStats BaseTower = new TowerStats();
        BaseTower.TowerName = "btnCreateTower_1";
        BaseTower.TowerCost = 50;
        BaseTower.TowerObj = Towers[0];
        TowerClasses.Add(BaseTower);

        TowerStats MoneyGenTower = new TowerStats();
        MoneyGenTower.TowerName = "btnCreateTower_MoneyGen";
        MoneyGenTower.TowerCost = 100;
        MoneyGenTower.TowerObj = Towers[1];
        TowerClasses.Add(MoneyGenTower);

        TowerStats CannonTower = new TowerStats();
        CannonTower.TowerName = "btnCreateCannon";
        CannonTower.TowerCost = 200;
        CannonTower.TowerObj = Towers[2];
        TowerClasses.Add(CannonTower);

        TowerStats Flamer = new TowerStats();
        Flamer.TowerName = "btnCreateFlamer";
        Flamer.TowerCost = 1000;
        Flamer.TowerObj = Towers[3];
        TowerClasses.Add(Flamer);
        
        TowerStats LightningTower = new TowerStats();
        LightningTower.TowerName = "btnCreateLightning";
        LightningTower.TowerCost = 1500;
        LightningTower.TowerObj = Towers[4];
        TowerClasses.Add(LightningTower);

        TowerStats RaftTower = new TowerStats();
        RaftTower.TowerName = "RaftTower";
        RaftTower.TowerCost = 200;
        RaftTower.TowerObj = Towers[5];
        TowerClasses.Add(RaftTower);

        TowerStats HarpoonTower = new TowerStats();
        HarpoonTower.TowerName = "btnCreateHarpoon";
        HarpoonTower.TowerCost = 500;
        HarpoonTower.TowerObj = Towers[6];
        TowerClasses.Add(HarpoonTower);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject[] NotPlacedTowers;
            NotPlacedTowers = GameObject.FindGameObjectsWithTag("Unplaced");

            if(NotPlacedTowers.Length > 0)
            {
                minimiseGUI.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                //Debug.Log("Target: " + hit.collider.gameObject.name);
            }

        }
    }

    //function is called when any button is pressed (must be assigned when new button is created)
    public void CreateTower()
    {
        UIAudio.PlayOneShot(mouseClick, 0.25f);

        InfoControllertxt info = infoBox.GetComponent<InfoControllertxt>();

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

            //loops through the class objects and matches the button pressed with the specification in the initialisation
            foreach(TowerStats TempObj in TowerClasses)
            {
                if(TempObj.TowerName == btnPressed)
                {
                    //check if the cost of the tower is inferior to the current money
                    if(GlobalVars.G_Money >= TempObj.TowerCost)
                    {
                        minimiseGUI.SetActive(false);
                        //instatiate tower and pass cost to the tower place script
                        UIAudio.PlayOneShot(mouseClick, 0.25f);
                        GameObject tower = Instantiate(TempObj.TowerObj, new Vector3(0, 0, 0), Quaternion.identity);
                        tower.GetComponent<TowerPlaceController>().towerCost = TempObj.TowerCost;
                    }
                    else
                    {
                        UIAudio.PlayOneShot(Error, 0.25f);
                        info.txt.text = "NOT ENOUGH GOLD!";
                    }
                }
            }
        }
    }
}
