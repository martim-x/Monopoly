using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TableSpin : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y+0.5f, 0f);
    }
}
