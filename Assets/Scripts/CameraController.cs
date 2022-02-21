using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    public float yOffSet;
    public float zOffSet;
    void Start()
    {
        player = GameObject.Find("Limo").transform;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y + yOffSet, player.position.z + zOffSet);
    }
}

