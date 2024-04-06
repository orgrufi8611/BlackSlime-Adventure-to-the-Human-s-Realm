using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpikesSummoner : Shoot
{
    public GameObject spikesPrefub;
    float lastX;

    // Start is called before the first frame update
    void Start()
    {
        damage = 0;
        lastX = transform.position.x;
    }

    // Update is called once per frame
    void lateUpdate()
    {
        float newX = transform.position.x;
        if(Mathf.Abs(newX - lastX) > 0.2f )
        {
            GameObject newSpike = Instantiate(spikesPrefub, transform.position, transform.rotation);
            newSpike.GetComponent<RockSpikes>().isEnemy = isEnemy;
            lastX = newX;
        }
    }
}
