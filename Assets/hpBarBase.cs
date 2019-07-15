using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpBarBase : MonoBehaviour
{
    float scale;
    // Start is called before the first frame update
    GameObject parent;
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.parent.name == "HpMid")
        {
            scale = GlobalVars.Hp_Mid;
        }
        else if(gameObject.transform.parent.name == "HpLeft")
        {
            scale = GlobalVars.Hp_Left;
        }
        else
        {
            scale = GlobalVars.Hp_Right;
        }
        if(scale <= 0)
        {
            Destroy(parent);
        }
        gameObject.transform.localScale = new Vector3(scale, 500, 0);
    }
}
