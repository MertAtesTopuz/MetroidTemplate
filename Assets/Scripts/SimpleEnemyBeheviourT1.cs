using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBeheviourT1 : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private int turnDelay;
    private Animator animator;
    private bool faceRight = false;
    private Rigidbody2D rb;
    private Transform target;

    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        StartCoroutine(SwitchDirection());
    }

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void Switch()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

        speed *= -1;

        StartCoroutine(SwitchDirection());
    }

    IEnumerator SwitchDirection()
    {
        yield return new WaitForSeconds(turnDelay);
        Switch();
    }
}
