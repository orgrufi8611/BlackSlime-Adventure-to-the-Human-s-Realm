using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject boss;

    public void SpawnBoss(Transform spawnpoint)
    {
        Instantiate(boss,spawnpoint.position,spawnpoint.rotation);
    }
}
