using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSettings : MonoBehaviour
{
    AudioSource UIAudio;
    public GameObject AudioObjUI;
     public AudioClip mouseClick;
    // Start is called before the first frame update
    void Start()
    {

       
    }

    public void Settings()
    {
        UIAudio = AudioObjUI.GetComponent<AudioSource>();
        if (gameObject.activeSelf)
        {
            UIAudio.PlayOneShot(mouseClick, 0.25f);
            gameObject.SetActive(false);
        }
        else
        {
            UIAudio.PlayOneShot(mouseClick, 0.25f);
            gameObject.SetActive(true);
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
