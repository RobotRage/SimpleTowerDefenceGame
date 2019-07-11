using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Colby's code

    List<GameObject> targets = new List<GameObject>();
    public int speed = 1;
    bool done = false;

    void Start()
    {
        bool searching = true;
        int i = 0;

        //finds all the objects of name node and their index 
        //warning can be infinite loop

        //numbers on node prefab specify order
        while (searching)
        {
            GameObject node = GameObject.Find("node" + i);
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
    }

    void Update()
    {
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
            Destroy(gameObject);
        }
    }
}
