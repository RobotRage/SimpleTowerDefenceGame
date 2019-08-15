using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InfoControllertxt : MonoBehaviour
{
    public Text txt;
    int levelAttack;
    int levelPasive;
    public GameObject infoBox;
    public GameObject upgradeButton;
    public GameObject SellBtn;

    public AudioClip mouseClick;
    public AudioClip hoverMouse;
    public AudioClip errorSound;
    public AudioClip cashRegister;
    public AudioClip upgrade;

    AudioSource UIAudio;
    AudioSource Music;
    AudioSource endSource;

    public GameObject AudioObjUI;
    public GameObject AudioMusic;
    public GameObject endSound;

    public static float MuicVol = 0.1f;
    public static float SoundFx = 1f;

    public GameObject SliderMusic;
    public GameObject SliderSound;
    
    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        upgradeButton.SetActive(false);
        SellBtn.SetActive(false);
        UIAudio = AudioObjUI.GetComponent<AudioSource>();
        Music= AudioMusic.GetComponent<AudioSource>();
        endSource = endSound.GetComponent<AudioSource>();

        SliderMusic.GetComponent<Slider>().value = MuicVol;
        SliderSound.GetComponent<Slider>().value = SoundFx;
    }
    public void MusicVol(Slider slider)
    {
        MuicVol = slider.value;
        Music.GetComponent<AudioSource>().volume = MuicVol;
    }
    public void SoundFX(Slider slider)
    {
        SoundFx = slider.value;
        UIAudio.GetComponent<AudioSource>().volume = SoundFx;
        endSource.GetComponent<AudioSource>().volume = SoundFx;
    }
    public void OnClickUpgrade(Button btn)
    {
        //GlobalVars.CurrentlySelected = btn.gameObject;

        if(GlobalVars.CurrentlySelected != null)
        {
            UIAudio.PlayOneShot(mouseClick, 0.25f);
            if (GlobalVars.CurrentlySelected.name == "TowerBase(Clone)" | GlobalVars.CurrentlySelected.name == "TowerBase" )
            {
               
                if (GlobalVars.G_Money >= levelAttack * 500)
                {
                    UIAudio.PlayOneShot(upgrade, 0.25f);
                    GlobalVars.G_Money -= levelAttack * 500;
                    GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level++;
                    txt.text = GlobalVars.CurrentlySelected.name + " has been upgraded to level " + (GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level);
                }
                else
                {
                    UIAudio.PlayOneShot(errorSound, 0.5f);
                    txt.text = "NOT ENOUGH GOLD!";
                }
            }

            if (GlobalVars.CurrentlySelected.name == "MoneyGen(Clone)" | GlobalVars.CurrentlySelected.name == "MoneyGen" )
            {
                if(GlobalVars.G_Money >= levelPasive * 600)
                {
                    UIAudio.PlayOneShot(upgrade, 0.25f);
                    GlobalVars.G_Money -= levelPasive * 600;
                    GlobalVars.CurrentlySelected.GetComponent<MoneyGenTowerController>().level++;
                    txt.text = GlobalVars.CurrentlySelected.name + " has been upgraded to level " + (GlobalVars.CurrentlySelected.GetComponent<MoneyGenTowerController>().level);
                }
                else
                {
                    UIAudio.PlayOneShot(errorSound, 0.5f);
                    txt.text = "NOT ENOUGH GOLD!";
                }

            }
            if (GlobalVars.CurrentlySelected.name == "Cannons(Clone)" | GlobalVars.CurrentlySelected.name == "Cannons")
            {
                if(GlobalVars.G_Money >= levelAttack * 700)
                {
                    UIAudio.PlayOneShot(upgrade, 0.25f);
                    GlobalVars.G_Money -= levelAttack * 700;
                    GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level++;
                    txt.text = GlobalVars.CurrentlySelected.name + " has been upgraded to level " + (GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level);
                }
                else
                {
                    UIAudio.PlayOneShot(errorSound, 0.5f);
                    txt.text = "NOT ENOUGH GOLD!";
                }
            }

            if (GlobalVars.CurrentlySelected.name == "Flame_Tower_1(Clone)" | GlobalVars.CurrentlySelected.name == "Flame_Tower_1" )
            {
                if(GlobalVars.G_Money >= levelAttack * 1000)
                {
                    UIAudio.PlayOneShot(upgrade, 0.25f);
                    GlobalVars.G_Money -= levelAttack * 1000;
                    GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level++;
                    txt.text = GlobalVars.CurrentlySelected.name + " has been upgraded to level " + (GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level);
                }
                else
                {
                    UIAudio.PlayOneShot(errorSound, 0.5f);
                    txt.text = "NOT ENOUGH GOLD!";
                }
            }
            if (GlobalVars.CurrentlySelected.name == "Lightning_Tower(Clone)" | GlobalVars.CurrentlySelected.name == "Lightning_Tower" )
            {
                if(GlobalVars.G_Money >= levelAttack * 2000)
                {
                    UIAudio.PlayOneShot(upgrade, 0.25f);
                    GlobalVars.G_Money -= levelAttack * 2000;
                    GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level++;
                    txt.text = GlobalVars.CurrentlySelected.name + " has been upgraded to level " + (GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level);
                }
                else
                {
                    UIAudio.PlayOneShot(errorSound, 0.5f);
                    txt.text = "NOT ENOUGH GOLD!";
                }
            }
            if (GlobalVars.CurrentlySelected.name == "Harpoon_Launcher(Clone)" | GlobalVars.CurrentlySelected.name == "Harpoon_Launcher")
            {
                if (GlobalVars.G_Money >= levelAttack * 500)
                {
                    UIAudio.PlayOneShot(upgrade, 0.25f);
                    GlobalVars.G_Money -= levelAttack * 500;
                    GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level++;
                    txt.text = GlobalVars.CurrentlySelected.name + " has been upgraded to level " + (GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level);
                }
                else
                {
                    UIAudio.PlayOneShot(errorSound, 0.5f);
                    txt.text = "NOT ENOUGH GOLD!";
                }
            }
            if (GlobalVars.CurrentlySelected.name == "RaftTower(Clone)")
            {
                GlobalVars.CurrentlySelected = null;
                upgradeButton.SetActive(false);
                SellBtn.SetActive(false);
                txt.text = "";
            }
        }
        //GlobalVars.CurrentlySelected = btn.gameObject;
        upgradeButton.SetActive(false);
        SellBtn.SetActive(false);
    }
    public void OnClickTower()
    {
        if (GlobalVars.CurrentlySelected != null)
        {
            if (GlobalVars.CurrentlySelected.tag == "Placed")
            {
                UIAudio.PlayOneShot(mouseClick, 0.25f);
                upgradeButton.SetActive(true);
                SellBtn.SetActive(true);
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
                if (GlobalVars.CurrentlySelected.name == "Lightning_Tower(Clone)")
                {
                    levelAttack = GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level;
                    txt.text = "Upgrade Witch to level " + (levelAttack + 1) + " for " + levelAttack * 2000 + "$? click hammer button";
                }
                if (GlobalVars.CurrentlySelected.name == "Harpoon_Launcher(Clone)")
                {
                    levelAttack = GlobalVars.CurrentlySelected.GetComponentInChildren<TowerProperties>().level;
                    txt.text = "Upgrade Harpoon to level " + (levelAttack + 1) + " for " + levelAttack * 500 + "$? click hammer button";
                }
            }
        }
        else
        {
            txt.text = "Click tower for info";
        }
    }
    public void PointerEnter()
    {
        UIAudio.PlayOneShot(hoverMouse, 0.5f);
    }
    public void OnMouseHoverButton(Button btn)
    {
        UIAudio.PlayOneShot(hoverMouse, 0.5f);
        GameObject rangeOff = Camera.main.GetComponent<RaycastingController>().lasttouched;
        Camera.main.GetComponent<RaycastingController>().lasttouched = null;
        if (rangeOff !=null)
        {
            rangeOff.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }

        upgradeButton.SetActive(false);
        SellBtn.SetActive(false);
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
        if (btn.name == "btnCreateLightning")
        {
            txt.text = "Zapps all enemies in range";
        }
        if (btn.name == "RaftTower")
        {
            txt.text = "Allows placement of towers on Raft in water";
        }
        if (btn.name == "btnCreateHarpoon")
        {
            txt.text = "8 directional targetting tower";
        }
    }
    
    public void SellTower(Button btn)
    {
        //GlobalVars.CurrentlySelected = btn.gameObject;
        if(GlobalVars.CurrentlySelected != null)
        {
            UIAudio.PlayOneShot(cashRegister, 0.25f);
            UIAudio.PlayOneShot(mouseClick, 0.25f);
            GlobalVars.G_Money += GlobalVars.CurrentlySelected.GetComponent<TowerPlaceController>().towerCost / 2;
            Destroy(GlobalVars.CurrentlySelected);
            GlobalVars.CurrentlySelected = null;
            upgradeButton.SetActive(false);
            SellBtn.SetActive(false);
        }
        GlobalVars.CurrentlySelected = btn.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVars.CurrentlySelected == null)
        {
            upgradeButton.SetActive(false);
            SellBtn.SetActive(false);
        }
    }

}
