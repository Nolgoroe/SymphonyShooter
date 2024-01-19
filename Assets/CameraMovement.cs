using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform followTarget;
    [SerializeField] Vector3 offset;
    [SerializeField] float followSpeed;

    void Start()
    {
        transform.position = followTarget.position + offset;
    }

    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, followTarget.position + offset, followSpeed);

        transform.position = followTarget.position + offset;
    }
}
