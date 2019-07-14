﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// Colby's Code

public class TowerProperties : MonoBehaviour
{

    //modifier = flat bonus

    public float range;
    public float rangeBase = 5;
    public float rangeModifier = 0;
    public float rangeMultiplier = 1;

    public float damage;
    public float damageBase = 10;
    public float damageModifier = 0;
    public float damageMultiplier = 1;

    public float speed; // shots per minute
    public float speedBase = 20;
    public float speedModifier = 0;
    public float speedMultiplier = 1;

    float shotCooldown = 1; // seconds until next shot

    bool coolDownToggle = false;

    List<GameObject> EnemiesInRange = new List<GameObject>();
    GameObject TargetEnemy;

    float TowerRotSpeed = 300;

    //offsets the rotation of the sprite to ensure sprite is facing right direction
    int rotationOffset = 270;

    public GameObject Bullet;

    GameObject parent;
    private Animator parentAnim;

    void Shoot()
    {


        parentAnim.SetTrigger("Shoot");

        GameObject InstantiatedBullet;
        InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
        InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
        InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(0,1,0);

        InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
        InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
        InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(0, -1, 0);

        InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
        InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
        InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(1, 0, 0);

        InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
        InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
        InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(-1, 0, 0);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            EnemiesInRange.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemiesInRange.Remove(collision.gameObject);
        }
    }

    private void FixedUpdate()
    {
        updateStats(); // only for testing pls remove later
    }

    void Update()
    {  
        if (transform.parent.tag == "Placed") // checks tag of parent object
        {

            //checks if more than 0 enemies in tower range
            if(EnemiesInRange.Count > 0)
            {
                //targets the first enemy in the list
                TargetEnemy = EnemiesInRange[0];

                //rotation code

                /*
                Vector3 targetRotation = TargetEnemy.transform.position - transform.position;
                GameObject parent = transform.parent.gameObject;
                float angle = Mathf.Atan2(targetRotation.y, targetRotation.x ) * Mathf.Rad2Deg;
                Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward) * (Quaternion.AngleAxis(rotationOffset, Vector3.forward));
                parent.transform.rotation = Quaternion.RotateTowards(transform.rotation , rot , Time.deltaTime * TowerRotSpeed);
                */

                //if previous corroutine is done, call another corroutine
                if (!coolDownToggle)
                {
                    coolDownToggle = true;
                    StartCoroutine(Wait(shotCooldown));
                }
            }
        }
    }

    void Start()
    {
        updateStats();
        parent = transform.parent.gameObject;
        parentAnim = parent.GetComponent<Animator>();


    }
}
