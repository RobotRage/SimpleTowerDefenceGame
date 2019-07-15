using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_minimise : MonoBehaviour
{
    public GameObject minimiseButton;
    Text txt;
    public Sprite redBtn;
    public Sprite yellowBtn;

    Image sprenderBtn;
    // Start is called before the first frame update
    void Start()
    {
        txt = minimiseButton.GetComponent<Text>();
        sprenderBtn = minimiseButton.GetComponent<Image>();
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
            sprenderBtn.sprite = redBtn;
          //  txt.text = "+";
        }
        else
        {
            //  txt.text = "-";
            sprenderBtn.sprite = yellowBtn;
            gameObject.SetActive(true);
        }
    }
}
