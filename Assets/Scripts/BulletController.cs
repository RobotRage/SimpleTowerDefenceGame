using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletDamage;
    public Vector3 Direction;
    float thrust = 9f;
    SpriteRenderer sprender;
    // Start is called before the first frame update
    void Start()
    {
        sprender = gameObject.GetComponent<SpriteRenderer>();
        if(gameObject.name != "lightningreal(Clone)")
        {
            if (Direction == new Vector3(0, 1, 0))
            {
                sprender.flipY = true;
            }
            else if (Direction == new Vector3(1, 0, 0))
            {
                transform.eulerAngles = new Vector3(0, 0, -90);
                Direction = new Vector3(0, -1, 0);
            }
            else if (Direction == new Vector3(-1, 0, 0))
            {
                transform.eulerAngles = new Vector3(0, 0, 90);
                Direction = new Vector3(0, -1, 0);
            }

            else if (Direction == new Vector3(1, 1, 0))
            {
                transform.eulerAngles = new Vector3(0, 0, 45);
                Direction = new Vector3(0, -1, 0);
            }
            else if (Direction == new Vector3(1, -1, 0))
            {
                transform.eulerAngles = new Vector3(0, 0, 135);
                Direction = new Vector3(0, -1, 0);
            }
            else if (Direction == new Vector3(-1, 1, 0))
            {
                transform.eulerAngles = new Vector3(0, 0, 225);
                Direction = new Vector3(0, -1, 0);
            }
            else if (Direction == new Vector3(-1, -1, 0))
            {
                transform.eulerAngles = new Vector3(0, 0, -45);
                Direction = new Vector3(0, -1, 0);
            }
        }
        else
        {

        }
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       transform.Translate(Direction * thrust * Time.deltaTime);
    }
}
