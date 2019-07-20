using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Colby's code

    List<GameObject> targets = new List<GameObject>();
    public int speed = 1;
    bool done = false;

    public float baseHp = 50;

    public GameObject GreenHP;
    public GameObject RedHP;

    public GameObject explosionObj;
    public GameObject FlameExplosion;
    string WhichRow;
    void Start()
    {
        //sets the hp bars lengths to the baseHp value
        GreenHP.transform.localScale = new Vector3(baseHp / 100, 3f, 0);
        RedHP.transform.localScale = new Vector3(baseHp / 100, 3f, 0);

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
        if (collision.gameObject.tag == "node")
        {
            if (targets.Count > 0)
            {
                targets.RemoveAt(0);
            }
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
