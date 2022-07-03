using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUpgrade : MonoBehaviour
{
    public int upgrade;
    [SerializeField] private GameObject pressE;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pressE.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
               // other.GetComponent<CharacterController>().extraJumpsValue += upgrade;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                //other.GetComponent<CharacterController>().extraJumpsValue += upgrade;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pressE.SetActive(false);
    }
}
