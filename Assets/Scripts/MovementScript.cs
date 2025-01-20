using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Transform[] path;
    void Start()
    {
            
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < path.Length; i++)
        {
            if (i < path.Length-1)
            {
                Gizmos.DrawLine(path[i].position, path[i+1].position);
                Gizmos.DrawSphere(path[i].position, 0.02f);
            }
            else
            {
                Gizmos.DrawLine(path[path.Length - 1].position, path[0].position);
                Gizmos.DrawSphere(path[i].position, 0.02f);
            }
        }
    }
}
