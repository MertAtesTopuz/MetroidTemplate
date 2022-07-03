using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    private CameraController cam;

    public Vector2 newMinPos;
    public Vector2 newMaxPos;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject bossUI;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            cam.maxPos = newMaxPos;
            cam.minPos = newMinPos;
            spawner.SetActive(true);
            block.SetActive(true);
            bossUI.SetActive(true);
            gameObject.SetActive(false);
            
        }
    }
}
