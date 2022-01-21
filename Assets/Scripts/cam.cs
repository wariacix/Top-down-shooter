using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public Transform pos;

    // Update is called once per frame
    void Update()
    {
        transform.position = pos.position + Vector3.back * 10f;
    }
}
