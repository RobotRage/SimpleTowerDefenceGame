using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGenTowerController : MonoBehaviour
{
    //how much money / tick
    int moneyBoost = 1;
    int tickrateSeconds = 1;
    private Animator Anim;
    public int level = 1;
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    bool toggleCoreRoutine = false;

    //add moneyBoost every tickrateSeconds to global money
    IEnumerator Moneytimer(int moneyBoost, int tick)
    {
        yield return new WaitForSeconds(tick);
        moneyBoost = level;
        GlobalVars.G_Money += moneyBoost;
        toggleCoreRoutine = false;

    }
    
    // Update is called once per frame
    void Update()
    {
        //if the object has been placed
        if(gameObject.tag == "Placed")
        {
            if (level == 2)
            {
                Anim.runtimeAnimatorController = Resources.Load("TreasureUp1") as RuntimeAnimatorController;
            }
            else if (level == 3)
            {
                Anim.runtimeAnimatorController = Resources.Load("TreasureUp2") as RuntimeAnimatorController;
            }

            if (!toggleCoreRoutine)
            {               
                toggleCoreRoutine = true;
                StartCoroutine(Moneytimer(moneyBoost, tickrateSeconds));
            }
        }
    }
}
