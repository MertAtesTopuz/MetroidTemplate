using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBeheviourT2 : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed;
    public Transform homePos;
    [SerializeField] private float maxRange;
    [SerializeField] private float minRange;
    SpriteRenderer sprite;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if (transform.position.x < target.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    public void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
    }


}
