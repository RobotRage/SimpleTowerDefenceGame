using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// Colby's Code

public class TowerProperties : MonoBehaviour
{
    public int level = 1;
    //modifier = flat bonus

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

    void Shoot()
    {
        GameObject InstantiatedBullet;

        parentAnim.SetTrigger("Shoot");
        if(parent.name == "TowerBase(Clone)")
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
        if(parent.name == "Cannons(Clone)")
        {
            InstantiatedBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            InstantiatedBullet.GetComponent<BulletController>().bulletDamage = damage;
            InstantiatedBullet.GetComponent<BulletController>().Direction = new Vector3(0, 1, 0);
        }
        if (parent.name == "Flame_Tower_1(Clone)")
        {
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
            }
            if (parent.name == "Cannons(Clone)")
            {
                damageMultiplier = (level + 3f) / 2;
                shotCooldownBase = 3;
            }
            if(parent.name == "Flame_Tower_1(Clone)")
            {
                damageMultiplier = (level + 4) / 2;
                shotCooldownBase = 1;
            }
        }

        //changes the radius of the range circle based on the range




        if(shotCooldown > 0.5)
        {
            shotCooldown = shotCooldownBase - (level / 10);
        }


        range = (rangeBase * rangeMultiplier) + rangeModifier;        
        damage = ((damageBase * damageMultiplier) + damageModifier) / GlobalVars.DebuffDamage;
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


    }
}
