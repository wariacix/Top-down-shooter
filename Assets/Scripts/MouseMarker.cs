using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMarker : MonoBehaviour
{
    void Update()
    {
        transform.position = Input.mousePosition + Vector3.back;
    }
}
