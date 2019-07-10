using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerProperties : MonoBehaviour
{
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

    public float shotCooldown = 100; // seconds until next shot
    CircleCollider2D circleHitbox;

    void Shoot()
    {
        print("pew");
        shotCooldown = 60 / speed;
    }

    void updateStats()
    {
        range = (rangeBase * rangeMultiplier) + rangeModifier;
        gameObject.transform.localScale = new Vector3(range + 1, range + 1, 1);
        damage = (damageBase * damageMultiplier) + damageModifier;
        speed = (speedBase * speedMultiplier) + speedModifier;
    }

    void Update()
    {
        updateStats(); // only for testing pls remove later
        if (transform.parent.tag == "Placed") // checks tag of parent object
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if (shotCooldown > 0)
            {
                shotCooldown -= Time.deltaTime;
            } else
            {
                Shoot();
            }
        }
    }

    void Start()
    {
        updateStats();
    }
}
