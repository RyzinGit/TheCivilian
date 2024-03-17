using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPlayerFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 Offset;
    void LateUpdate()
    {
        transform.position = player.transform.position - Offset;
    }
}
