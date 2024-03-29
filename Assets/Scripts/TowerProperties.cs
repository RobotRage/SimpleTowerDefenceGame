﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// Colby's Code

public class TowerProperties : MonoBehaviour
{
    public int level = 1;
    //modifier = flat bonus

    int switches = 0;

    public Sprite Level1;
    public Sprite Level2;

    public float range;
    public float rangeBase = 5;
     float rangeModifier = 0;
     float rangeMultiplier = 1;

    public float damage;
    public float damageBase = 10;
     float damageModifier = 0;
     float damageMultiplier = 1;

    float shotCooldownBase = 1;
    public float shotCooldown = 1; // seconds until next shot

    bool coolDownToggle = false;

    List<GameObject> EnemiesInRange = new List<GameObject>();
    GameObject TargetEnemy;

    float TowerRotSpeed = 300;

    //offsets the rotation of the sprite to ensure sprite is facing right direction
    int rotationOffset = 270;

    public GameObject Bullet;

    GameObject parent;
    private Animator parentAnim;
    int Roundangle;
    public GameObject lightningCloud;
    public GameObject Lightningreal;

    SpriteRenderer parentSprender;
    void Shoot(int switches)
    {
        GameObject InstantiatedBullet;

        parentAnim.SetTrigger("Shoot");
        if(parent.name == "TowerBase(Clone)")
        {
            if(level>=2)
            {
                if(switches==1)
                {
                    InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
                    InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
                    InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(1, 1, 0);

                    InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
                    InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
                    InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(-1, -1, 0);

                    InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
                    InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
                    InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(1, -1, 0);

                    InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
                    InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
                    InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(-1, 1, 0);
                }
                else
                {
                    InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
                    InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
                    InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(0, 1, 0);

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

            }
            else
            {
                InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
                InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
                InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(0, 1, 0);

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
            
        }
        if(parent.name == "Cannons(Clone)")
        {
            InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
            InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(0, 1, 0);
        }
        if (parent.name == "Flame_Tower_1(Clone)")
        {
            //add loop here
            //for(int i=0; i<)

            InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
            InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(0, 1, 0);

            InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
            InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(0, -1, 0);

            InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
            InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(1, 0, 0);

            InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
            InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(-1, 0, 0);

            InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
            InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(1, 1, 0);

            InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
            InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(1, -1, 0);

            InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
            InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(-1, 1, 0);

            InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
            InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(-1, -1, 0);
        }
        if (parent.name == "Lightning_Tower(Clone)")
        {
            foreach (GameObject enemy in EnemiesInRange)
            {
                Instantiate(lightningCloud, new Vector3(enemy.transform.position.x, enemy.transform.position.y + 1, enemy.transform.position.z), Quaternion.identity);
                InstantiatedBullet = Instantiate(Lightningreal, new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z), Quaternion.identity);
                InstantiatedBullet.GetComponent<BulletController>().bulletDamage = 2* damageMultiplier;
            }
        }
        if(parent.name == "Harpoon_Launcher(Clone)")
        {
            InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            InstantiatedBullet.transform.eulerAngles = new Vector3(0, 0, Roundangle - 90);
            InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
            //InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(-1, 1, 0);
        }
    }

    //call this whenever there is a ingame buff or nerf that needs to change the properties of the tower
    void updateStats()
    {
        gameObject.transform.localScale = new Vector3(range + 1, range + 1, 1);

        if (parent != null)
        {
            if(parent.name == "TowerBase(Clone)")
            {
                damageMultiplier = (level + 1) / 2;
                if (level == 2)
                {
                    parentAnim.runtimeAnimatorController = Resources.Load("BaseUp1") as RuntimeAnimatorController;
                }
                else if (level==3)
                {
                    //Debug.Log("__hit upgrade");
                    parentAnim.runtimeAnimatorController = Resources.Load("BaseUp2") as RuntimeAnimatorController;
                }
            }
            if (parent.name == "Cannons(Clone)")
            {
                shotCooldownBase = 2;
                if (level == 2)
                {
                    parentAnim.runtimeAnimatorController = Resources.Load("CannonUp1") as RuntimeAnimatorController;
                }
                else if(level==3)
                {
                    parentAnim.runtimeAnimatorController = Resources.Load("CannonsUp2") as RuntimeAnimatorController;
                }
                damageMultiplier = (level + 4f) / 2;
                
            }
            if(parent.name == "Flame_Tower_1(Clone)")
            {
                if (level == 2)
                {
                    parentAnim.runtimeAnimatorController = Resources.Load("FlamerUp1") as RuntimeAnimatorController;
                }
                else if (level == 3)
                {
                    parentAnim.runtimeAnimatorController = Resources.Load("FlamerUp2") as RuntimeAnimatorController;
                }
                damageMultiplier = (level + 4) / 2;
                shotCooldownBase = 1;
            }
            if (parent.name == "Lightning_Tower(Clone)")
            {
                if (level == 2)
                {
                    parentAnim.runtimeAnimatorController = Resources.Load("LightningUp1") as RuntimeAnimatorController;
                }
                else if (level == 3)
                {
                    parentAnim.runtimeAnimatorController = Resources.Load("LightningUp2") as RuntimeAnimatorController;
                }
                damageMultiplier = (level + 10) / 2;
                shotCooldownBase = 1;
            }
            if(parent.name == "Harpoon_Launcher(Clone)")
            {
                damageMultiplier = (level + 2f) / 2;
                shotCooldownBase = 0.5f;
            }
        }

        //changes the radius of the range circle based on the range

        if(shotCooldown > 0.2)
        {
            shotCooldown = shotCooldownBase - (level / 10);
        }


        range = (rangeBase * rangeMultiplier) + rangeModifier;        
        damage = ((damageBase * damageMultiplier) + damageModifier) / GlobalVars.DebuffDamage;
    }

    //IEnumerator is another thread which delays the execution of code
    IEnumerator Wait(float x)
    {      
        Shoot(switches);      
        yield return new WaitForSeconds(x);
        coolDownToggle = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" | collision.tag == "EnemyLeft" | collision.tag == "EnemyRight")
        {
            EnemiesInRange.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" | collision.tag == "EnemyLeft" | collision.tag == "EnemyRight")
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
            if (parent.name == "Harpoon_Launcher(Clone)")
            {
                parent.GetComponent<Animator>().SetInteger("Level", level);
            }
                //checks if more than 0 enemies in tower range
                if (EnemiesInRange.Count > 0)
            {
                //targets the first enemy in the list
                TargetEnemy = EnemiesInRange[0];

                //rotation code
                if(parent.name == "Harpoon_Launcher(Clone)")
                {
                    Vector3 targetRotation = TargetEnemy.transform.position - transform.position;
                    GameObject parent = transform.parent.gameObject;
                    float angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;
                    Roundangle = (int)Mathf.Round(angle / 45) * 45;
                    //Roundangle *= -1;
                    if (TargetEnemy = null)
                    {
                        Roundangle = 90;
                    }
                    //i dont know ok just roll with it
                    if(Roundangle == -180)
                    {
                        Roundangle = 180;
                    }
                   // print(Roundangle);
                    parent.GetComponent<Animator>().SetInteger("Angle",Roundangle);
                    parent.GetComponent<Animator>().SetInteger("Level", level);
                    //Quaternion rot = Quaternion.AngleAxis(Roundangle, Vector3.forward) * (Quaternion.AngleAxis(rotationOffset, Vector3.forward));
                    //parent.transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, Time.deltaTime * TowerRotSpeed);
                }

                /*
                
               
                
                Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward) * (Quaternion.AngleAxis(rotationOffset, Vector3.forward));
                parent.transform.rotation = Quaternion.RotateTowards(transform.rotation , rot , Time.deltaTime * TowerRotSpeed);
                */

                //if previous corroutine is done, call another corroutine
               // if (parent.name != "TowerBase(Clone)" && level == 1)
                //{
                    if (!coolDownToggle)
                    {
                        coolDownToggle = true;
                        if (level >= 2)
                        {
                            StartCoroutine(Wait(shotCooldown / 2 * GlobalVars.DebuffShotSpeed));
                            if (switches == 0)
                            {
                                switches = 1;
                            }
                            else
                            {
                                switches = 0;
                            }
                        }
                        else
                        {
                            StartCoroutine(Wait(shotCooldown * GlobalVars.DebuffShotSpeed));
                        }
                    }
               }
            }
            if(level >= 2 && parent.name == "TowerBase(Clone)")
            {
                if (!coolDownToggle)
                {
                    coolDownToggle = true;
                    if (level >= 2)
                    {
                        StartCoroutine(Wait(shotCooldown / 2 * GlobalVars.DebuffShotSpeed));
                        if (switches == 0)
                        {
                            switches = 1;
                        }
                        else
                        {
                            switches = 0;
                        }
                    }
                    else
                    {
                        StartCoroutine(Wait(shotCooldown * GlobalVars.DebuffShotSpeed));
                    }
                }
            }
        
    }

    void Start()
    {
        updateStats();
        parent = transform.parent.gameObject;
        parentAnim = parent.GetComponent<Animator>();
        parentSprender = parent.GetComponent<SpriteRenderer>();
    }
}
