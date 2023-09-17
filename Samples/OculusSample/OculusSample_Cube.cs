using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusSample_Cube : MonoBehaviour
{
    private Vector3 savedPos;

    private void Awake()
    {
        savedPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            transform.position = savedPos;
        }
    }
}
