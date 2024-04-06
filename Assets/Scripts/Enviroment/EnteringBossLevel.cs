using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringBossLevel : MonoBehaviour
{
    public Transform bossSpawnPoint;
    bool bossSpawned;
    // Start is called before the first frame update
    void Start()
    {
        bossSpawned = false;
        transform.position -= new Vector3(ScreenSize.screenUnitWidth * 0.25f, 0, 0);
        bossSpawnPoint.position = transform.position + new Vector3(ScreenSize.screenUnitWidth * 0.65f,ScreenSize.screenUnitHeight/3,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime") 
        {
            if(!bossSpawned)
            {
                bossSpawned=true;
                GameObject.Find("BossSpawner").GetComponent<BossSpawner>().SpawnBoss(bossSpawnPoint);
                Camera.main.GetComponent<CameraMovement>().StopFollow();
            }
        }
    }
}
