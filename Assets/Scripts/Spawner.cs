using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private GameObject enemy;
    private bool bossEnter = false;

    void Start()
    {
       
            StartCoroutine(Spawn());
        
    }

    IEnumerator Spawn()
    {
        
        Instantiate(enemy, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        StartCoroutine(Spawn());
     }
}
