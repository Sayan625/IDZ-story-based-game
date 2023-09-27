using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    void Update()
    {
        transform.forward = transform.parent.forward;
    }
}
