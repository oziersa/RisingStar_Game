﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynoCam : MonoBehaviour
{
    PlayerMotion player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMotion>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newCamPos = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = new Vector3(newCamPos.x, newCamPos.y, transform.position.z);
    }
}
