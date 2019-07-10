using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//colby's code

public class TowerProperties : MonoBehaviour
{

    //modifier = flat bonus

    public float range;
    public float rangeBase = 5;
    public float rangeModifier = 0;
    public float rangeMultiplier = 1;

    public float damage;
    public float damageBase = 100;
    public float damageModifier = 0;
    public float damageMultiplier = 1;

    public float speed; // shots per minute
    public float speedBase = 20;
    public float speedModifier = 0;
    public float speedMultiplier = 1;

    float shotCooldown = 3; // seconds until next shot

    bool coolDownToggle = false;

    void Shoot()
    {
        //instantiate bullet here
        print("pew");
    }

    //call this whenever there is a ingame buff or nerf that needs to change the properties of the tower
    void updateStats()
    {
        //changes the radius of the range circle based on the range
        gameObject.transform.localScale = new Vector3(range + 1, range + 1, 1);

        range = (rangeBase * rangeMultiplier) + rangeModifier;        
        damage = (damageBase * damageMultiplier) + damageModifier;
        speed = (speedBase * speedMultiplier) + speedModifier;
    }

    //IEnumerator is another thread which delays the execution of code
    IEnumerator Wait(float x)
    {
        Shoot();
        yield return new WaitForSeconds(x);
        coolDownToggle = false;
    }

    private void FixedUpdate()
    {
        updateStats(); // only for testing pls remove later
    }

    void Update()
    {  
        if (transform.parent.tag == "Placed") // checks tag of parent object
        {
            //turn off the circle sprite when tower is placed
            gameObject.GetComponent<SpriteRenderer>().enabled = false;

            //if previous corroutine is done, call another corroutine
            if (!coolDownToggle)
            {   
                coolDownToggle = true;
                StartCoroutine(Wait(shotCooldown));
            }
        }
    }

    void Start()
    {
        updateStats();
    }
}
