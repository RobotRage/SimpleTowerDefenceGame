using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGenTowerController : MonoBehaviour
{
    //how much money / tick
    int moneyBoost = 1;
    int tickrateSeconds = 1;

    public int level = 1;
    void Start()
    {
        
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
            if(!toggleCoreRoutine)
            {               
                toggleCoreRoutine = true;
                StartCoroutine(Moneytimer(moneyBoost, tickrateSeconds));
            }
        }
    }
}
