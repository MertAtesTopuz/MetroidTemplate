using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    [SerializeField] private float smoothing;
    [SerializeField] private Transform target;
    public CharacterController chaController;
    public Vector2 minPos;
    public Vector2 maxPos;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if (chaController.moveInput1 == 0)
        {
            target.position = target1.position;
        }

        else
        {
            target.position = target2.position;
        }

        if (transform.position != target.position)
        {
            Vector3 targetPos = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, smoothing) + offset;   
        }
    }
}
