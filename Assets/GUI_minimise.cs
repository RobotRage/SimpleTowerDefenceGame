using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_minimise : MonoBehaviour
{
    public GameObject minimiseButton;
    Text txt;
    // Start is called before the first frame update
    void Start()
    {
        txt = minimiseButton.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MinimiseGui()
    {
        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
          //  txt.text = "+";
        }
        else
        {
          //  txt.text = "-";
            gameObject.SetActive(true);
        }
    }
}
