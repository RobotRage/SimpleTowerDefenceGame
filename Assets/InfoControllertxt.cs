using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoControllertxt : MonoBehaviour
{
    Text txt;
    int levelAttack;
    int levelPasive;
    public GameObject infoBox;
    public GameObject upgradeButton;
    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        upgradeButton.SetActive(false);
    }
    public void OnClickUpgrade()
    {
        
        if(GlobalVars.CurrentlySelected != null)
        {
            if (GlobalVars.CurrentlySelected.name == "TowerBase(Clone)" | GlobalVars.CurrentlySelected.name == "TowerBase" && GlobalVars.G_Money >= levelAttack * 500)
            {            
                GlobalVars.G_Money -= levelAttack * 500;
                GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level++;
                txt.text = GlobalVars.CurrentlySelected.name + " has been upgraded to level " + (GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level);
            }

            if (GlobalVars.CurrentlySelected.name == "MoneyGen(Clone)" | GlobalVars.CurrentlySelected.name == "MoneyGen" && GlobalVars.G_Money >= levelPasive * 600)
            {
                GlobalVars.G_Money -= levelPasive * 600;
                GlobalVars.CurrentlySelected.GetComponent<MoneyGenTowerController>().level++;
                txt.text = GlobalVars.CurrentlySelected.name + " has been upgraded to level " + (GlobalVars.CurrentlySelected.GetComponent<MoneyGenTowerController>().level);
            }
            if (GlobalVars.CurrentlySelected.name == "Cannons(Clone)" | GlobalVars.CurrentlySelected.name == "Cannons" && GlobalVars.G_Money >= levelAttack * 700)
            {
                GlobalVars.G_Money -= levelAttack * 700;
                GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level++;
                txt.text = GlobalVars.CurrentlySelected.name + " has been upgraded to level " + (GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level);
            }
            if (GlobalVars.CurrentlySelected.name == "Flame_Tower_1(Clone)" | GlobalVars.CurrentlySelected.name == "Flame_Tower_1" && GlobalVars.G_Money >= levelAttack * 1000)
            {
                GlobalVars.G_Money -= levelAttack * 1000;
                GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level++;
                txt.text = GlobalVars.CurrentlySelected.name + " has been upgraded to level " + (GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level);
            }
        }

        upgradeButton.SetActive(false);
    }
    public void OnClickTower()
    {
        if (GlobalVars.CurrentlySelected != null)
        {
            if (GlobalVars.CurrentlySelected.tag == "Placed")
            {
                upgradeButton.SetActive(true);
                if (GlobalVars.CurrentlySelected.name == "TowerBase(Clone)")
                {
                    levelAttack = GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level;
                    txt.text = "Upgrade basic shoot to level "+(levelAttack+1)+" for " + levelAttack * 500 + "$? click hammer button";
                }
                if (GlobalVars.CurrentlySelected.name == "MoneyGen(Clone)")
                {
                    levelPasive = GlobalVars.CurrentlySelected.GetComponent<MoneyGenTowerController>().level;
                    txt.text = "Upgrade Gold generator to level "+(levelPasive+1)+" for "+ levelPasive * 600 +"$? click hammer button";
                }
                if (GlobalVars.CurrentlySelected.name == "Cannons(Clone)")
                {
                    levelAttack = GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level;
                    txt.text = "Upgrade Cannons to level " + (levelAttack + 1) + " for " + levelAttack * 700 + "$? click hammer button";
                }
                if (GlobalVars.CurrentlySelected.name == "Flame_Tower_1(Clone)")
                {
                    levelAttack = GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level;
                    txt.text = "Upgrade Flamer to level " + (levelAttack + 1) + " for " + levelAttack * 1000 + "$? click hammer button";
                }
            }
        }
        else
        {
            txt.text = "Click tower for info";
        }
    }
    
    public void OnMouseHoverButton(Button btn)
    {

        GameObject rangeOff = Camera.main.GetComponent<RaycastingController>().lasttouched;
        Camera.main.GetComponent<RaycastingController>().lasttouched = null;
        if (rangeOff !=null)
        {
            rangeOff.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }

        upgradeButton.SetActive(false);
        if (btn.name == "btnCreateTower_1")
        {
             txt.text = "turrent that shoots in 4 directions";          
        }
        if (btn.name == "btnCreateTower_MoneyGen")
        {
           txt.text = "generates income every second";
        }
        if (btn.name == "btnCreateCannon")
        {
            txt.text = "only shoots forward, high range and damage";
        }
        if (btn.name == "btnCreateFlamer")
        {
            txt.text = "High damage 8 directional fire";
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

}
