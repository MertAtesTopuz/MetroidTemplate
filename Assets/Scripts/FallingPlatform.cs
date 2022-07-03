using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float SpawnDelay = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (gameObject.activeSelf == false)
        {
            StartCoroutine(CreateDelay());
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Player")
        {
            Invoke("DropPlatform", 1.0f);
        }
    }

    void DropPlatform()
    {
        gameObject.SetActive(false);
    }

    IEnumerator CreateDelay()
    {
        yield return new WaitForSeconds(SpawnDelay);
        gameObject.SetActive(true);
    }
}
