using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    //1) Make sure to comment EVERY piece of code you write unless it is self explanatory
    //2) Try and modularise your code into Functions so that we can reuse them over the course of development
    //3) Add a comment to code with your name so we know who to ask if we need explanation
    //4) Ask before fucking around too much with sombody's code for problem shooting
    //5) Try not to push to github with active errors even if it runs, if you have to make sure to document the error

    //This file contains the global variables for the game.

    //Only add a global var if the var is going to be used alot throught the game development.
    //If the var is not used alot, use direct variable passing between scripts.

    /// <TODO>
    /// Add stuff that needs to be Fixed/Done here
    /// 
    /// </TODO>

    public static int G_Money = 200;

    public static float Hp_Left = 500;
    public static float Hp_Right = 500;
    public static float Hp_Mid = 1000;

    public static float DebuffDamage = 1;
    public static float DebuffShotSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp_Mid <= 0)
        {
            print("Game over man, game over");
        }
        if(Hp_Left <= 0)
        {
            DebuffDamage = 2;
        }
        if (Hp_Right <= 0)
        {
            DebuffShotSpeed = 2;
        }
    }
}
