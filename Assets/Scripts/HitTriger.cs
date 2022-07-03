using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTriger : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().HurtEnemy(damage);
        }
        if (other.transform.tag == "Boss")
        {
            other.GetComponent<BossHealth>().HurtEnemy(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().HurtEnemy(damage);
        }
        if (other.transform.tag == "Boss")
        {
            other.GetComponent<BossHealth>().HurtEnemy(damage);
        }
    }
}
