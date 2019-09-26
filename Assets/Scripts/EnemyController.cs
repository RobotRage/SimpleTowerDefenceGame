using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Colby's code
    string Dir = "Down";
    int Direction = 0; // Down = 0, Left = -1, Right = 1
    List<GameObject> targets = new List<GameObject>();
    float speed = 1;
    bool done = false;

    float baseHp = 50;

    public GameObject GreenHP;
    public GameObject RedHP;

     GameObject SpawnerLeft;
     GameObject SpawnerRight;

    public GameObject explosionObj;
    public GameObject FlameExplosion;
    public GameObject ArrowExplosion;

    string WhichRow;
    Animator anim;
    void Start()
    {
        baseHp += GlobalVars.WaveNum * 1.1f;
        anim = GetComponent<Animator>();
        if(gameObject.name == "Yellow_Sun_Ship(Clone)")
        {
            baseHp = 250 + GlobalVars.WaveNum * GlobalVars.WaveNum/2;
        }
        else if (gameObject.name == "Red_Skull_Ship(Clone)")
        {
            baseHp = 100 + GlobalVars.WaveNum * GlobalVars.WaveNum / 2;
        }
        else if (gameObject.name == "Green_Cross_Ship(Clone)")
        {
            baseHp = 200 + GlobalVars.WaveNum * GlobalVars.WaveNum / 2;
        }
        else if(gameObject.name == "SharkEnemy(Clone)")
        {
            baseHp = 100 + GlobalVars.WaveNum * GlobalVars.WaveNum / 2;
        }

        //sets the hp bars lengths to the baseHp value
        GreenHP.transform.localScale = new Vector3(baseHp / 100, 2.5f, 0);
        GreenHP.transform.position = new Vector3(gameObject.transform.position.x - (baseHp / 100)/2, gameObject.transform.position.y + 1, 0);
        RedHP.transform.localScale = new Vector3(baseHp / 100, 2.5f, 0);
        RedHP.transform.position   = new Vector3(gameObject.transform.position.x - (baseHp / 100)/2, gameObject.transform.position.y + 1, 0);

        bool searching = true;
        int i = 0;

        //finds all the objects of name node and their index 
        //warning can be infinite loop


        //numbers on node prefab specify order
        while (searching)
        {
            GameObject node;
            if (gameObject.tag == "Enemy")
            {
                 node = GameObject.Find("node" + i);
                WhichRow = "Mid";
            }
            else if (gameObject.tag == "EnemyRight")
            {
                 node = GameObject.Find("node_right" + i);
                WhichRow = "Right";
            }
            else
            {
                 node = GameObject.Find("node_left" + i);
                WhichRow = "Left";
            }
            
            if (node != null)
            {
                //adds node to list
                targets.Add(node);
                i += 1;
            }
            else
            {
                searching = false;
            }
        }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if object collides with node, remove it from the list
        if (collision.gameObject.tag == "node" )
        {
            Dir = "Down";
            if (targets.Count > 0)
            {
                targets.RemoveAt(0);
            }
           // Debug.Log(Dir);
        }
        else if(collision.gameObject.tag == "Left")
        {
            Dir = "Left";
            if (targets.Count > 0)
            {
                targets.RemoveAt(0);
            }
            //Debug.Log(Dir);
        }
        else if (collision.gameObject.tag == "Right")
        {
            Dir = "Right";
            if (targets.Count > 0)
            {
                targets.RemoveAt(0);
            }
            //Debug.Log(Dir);
        }



        else if(collision.gameObject.tag == "Down")
        {
            
            Dir = "Down";
            if (targets.Count > 0)
            {
                targets.RemoveAt(0);
            }
           // Debug.Log(Dir);
        }

        if(collision.gameObject.tag == "Bullet")
        {
            if(collision.gameObject.name == "Bullet(Clone)" | collision.gameObject.name ==  "Cannons_9(Clone)")
            {
                Instantiate(explosionObj, gameObject.transform.position, gameObject.transform.rotation);
            }
            if(collision.gameObject.name == "FlameBullet(Clone)")
            {
                Instantiate(FlameExplosion, gameObject.transform.position, gameObject.transform.rotation);
            }
            if(collision.gameObject.name == "HarpoonBullet(Clone)")
            {
                Instantiate(ArrowExplosion, gameObject.transform.position, gameObject.transform.rotation);
            }


            //reduces hp based on the bullet damage on the BulletController
            baseHp -= collision.GetComponent<BulletController>().bulletDamage;
            //reduces the HpBar length based on damage taken
            GreenHP.transform.localScale = new Vector3(baseHp /100, 3f, 0);
            //destroys the bullet
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if(Dir == "Down")
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            Direction = 0;
            anim.SetInteger("Direction", Direction);
        }
        else if(Dir == "Left")
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            Direction = -1;
            anim.SetInteger("Direction", Direction);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            Direction = 1;
            anim.SetInteger("Direction", Direction);
        }


        if (GlobalVars.Hp_Mid <= 0)
        {
            Destroy(gameObject);
        }
        if (gameObject.name == "Red_Skull_Ship(Clone)")
        {
            speed = ((GlobalVars.WaveNum / 15) + 1) * (GlobalVars.WaveNum / 20 + 1);
        }
        else if(gameObject.name == "Yellow_Sun_Ship(Clone)")
        {
            speed = ((GlobalVars.WaveNum / 20) + 1) * (GlobalVars.WaveNum / 20 + 1);
        }
        else if (gameObject.name == "Green_Cross_Ship(Clone)")
        {
            speed = ((GlobalVars.WaveNum / 9) + 1) * (GlobalVars.WaveNum / 20 + 1);
        }
        else if(gameObject.name == "SharkEnemy(Clone)")
        {
            speed = ((GlobalVars.WaveNum / 6) + 1)* (GlobalVars.WaveNum / 20 + 1);
        }
        else
        {
            speed = ((GlobalVars.WaveNum / 10) + 1)* (GlobalVars.WaveNum / 20 + 1);
        }


        GlobalVars.enemyAlive = true;
        if(baseHp <=0)
        {
            GlobalVars.G_Money += 20;
            Destroy(gameObject);
        }

        if (!done)
        {
            if (targets.Count == 0)
            {
                done = true;
            }
            else
            {
                //move towards first element int the list
                //TODO add rotation
                Vector3 moveDir = (targets[0].transform.position - transform.position).normalized;
                transform.position += moveDir * speed * Time.deltaTime;
            }
        }
        else
        {
            //destroy enemy if reachest the end
            //TODO add check for player loosing hp
            if(WhichRow == "Mid")
            {
                GlobalVars.Hp_Mid -= 100;
            }
            else if(WhichRow == "Right")
            {

                GlobalVars.Hp_Right -= 100;
            }
            else
            {
                GlobalVars.Hp_Left -= 100;

            }
            Destroy(gameObject);
        }
    }
}
