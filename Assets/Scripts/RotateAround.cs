using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.left, 20 * Time.deltaTime);
    }
}
