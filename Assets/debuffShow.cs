using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuffShow : MonoBehaviour
{
    public GameObject Arrows2;
    public GameObject Arrows1;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    void Update()
    {
        if (GlobalVars.Hp_Left <= 0)
        {
            Arrows2.SetActive(true);
        }
       
        if (GlobalVars.Hp_Right <= 0)
        {
            Arrows1.SetActive(true);
        }
        
    }
}
