using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private CharacterHealth chaHealth;
    private float waitToHurt = 2f;
    private bool isTouching;
    [SerializeField]

    void Start()
    {
        chaHealth = FindObjectOfType<CharacterHealth>();
    }

    private void Update()
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.GetComponent<CharacterHealth>().TakeDamage(1);

        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTouching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }
}
