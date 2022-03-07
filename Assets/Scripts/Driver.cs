using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(0, 0.1f, 0);
        transform.Rotate(0, 0, 1);
    }
}
