using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    // Colby's code

    public List<GameObject> targets = new List<GameObject>();
    public int targetIndex = 0;
    public int speed = 1;
    public bool done = false;
    // Start is called before the first frame update
    void Start()
    {
        bool searching = true;
        int index = 0;
        while (searching)
        {
            GameObject node = GameObject.Find("node" + index);
            if (node != null)
            {
                targets.Add(node);
                print("found one");
                index += 1;
            }
            else
            {
                searching = false;
                print("found none");
            }
        }

        print("finished searching, found " + targets.Count);

        if (targets.Count == 0)
        {
            done = true;
            print("done!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!done)
        {
            if (transform.position != targets[targetIndex].transform.position)
            {
                Vector3 moveDir = (targets[targetIndex].transform.position - transform.position).normalized;
                transform.position += moveDir * speed * Time.deltaTime;
            }
            else
            {
                targetIndex += 1;
                if (targetIndex + 1 > targets.Count)
                {
                    done = true;
                }
            }
        }

    }
}
