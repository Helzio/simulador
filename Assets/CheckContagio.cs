using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckContagio : MonoBehaviour
{
    public MonsterSpawner spawner;
    private PlayerController player;

    void Start()
    {
        player = GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!player.enfermo){
          player.enfermo = true;
          spawner.numeroContagios++;
        }
    }
}
