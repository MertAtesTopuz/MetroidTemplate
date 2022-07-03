using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    public Transform firstPos, secondPos;
    public float speed;
    private CharacterHealth chaHealth;
    private float waitToHurt = 2f;
    private bool isTouching;
    [SerializeField]

    Vector3 nextPos;

    private void Start()
    {
        nextPos = firstPos.position;
        chaHealth = FindObjectOfType<CharacterHealth>();
    }

    private void Update()
    {
        if (transform.position == firstPos.position)
        {
            nextPos = secondPos.position;
        }

        if (transform.position == secondPos.position)
        {
            nextPos = firstPos.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);

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
        if (other.transform.tag == "Player")
        {
            other.transform.GetComponent<CharacterHealth>().TakeDamage(1);

        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            isTouching = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            isTouching = false;
            waitToHurt = 2f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(firstPos.position, secondPos.position);
    }
}
