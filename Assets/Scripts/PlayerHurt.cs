using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    private CharacterHealth chaHealth;
    private float waitToHurt = 2f;
    private bool isTouching;
    [SerializeField]
    private int damageToGive = 10;

    void Start()
    {
        chaHealth = FindObjectOfType<CharacterHealth>();
    }


    void Update()
    {

        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                chaHealth.TakeDamage(1);
                waitToHurt = 2f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<CharacterHealth>().TakeDamage(damageToGive);

        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }
}
