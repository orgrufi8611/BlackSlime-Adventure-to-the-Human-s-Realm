using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemiesPrefub = new GameObject[9];
    public Transform groundSpawner;
    public Transform skySpawner;
    
    float timepass;
    float spawnCooldown;
    
    
    GameLogic gameLogic;
    // Start is called before the first frame update
    
    void Start()
    {
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        SetCooldown(1);
    }

    public void ResetOnNewScene()
    {
        Start();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (gameLogic.active && !gameLogic.boss)
        {
             timepass += Time.deltaTime;

            //move the spawner with the camera
            transform.position = new Vector3(Camera.main.transform.position.x, transform.position.y, transform.position.z);

            //if killed all enemies in the wave
            if (gameLogic.enemiesToKill <= 0)
            {
                gameLogic.NewWave();
            }

            else if (timepass > spawnCooldown)
            {
                SpawnEnemy();
                timepass = 0;
            }
        }
    }

    //summon an enemy of the current lvl
    void SpawnEnemy()
    {
        GameObject enemyToSpawn;
        int r = 0;
        switch (gameLogic.lvl)
        {
            //on lvl 1 only goblins  and mushroom are allowed
            case 1:
                r = Random.Range(0, 2);
                enemyToSpawn = Instantiate(enemiesPrefub[r],groundSpawner.position,groundSpawner.rotation);
                break;
            //on lvl 2 only orcs ghul and bats are allowed
            case 2:
                r = Random.Range(2, 5);
                if(r == 2)
                {
                    enemyToSpawn = Instantiate(enemiesPrefub[r], skySpawner.position, skySpawner.rotation);
                }
                else
                {
                    enemyToSpawn = Instantiate(enemiesPrefub[r], groundSpawner.position, groundSpawner.rotation);
                }
                break;
            //on lvl 3 only skeleton flying eye and golem are allowed
            case 3:
                r = Random.Range(5, 8);
                if(r == 7)
                {
                    enemyToSpawn = Instantiate(enemiesPrefub[r], skySpawner.position,skySpawner.rotation);
                }
                else
                {
                    enemyToSpawn = Instantiate(enemiesPrefub[r], groundSpawner.position, groundSpawner.rotation);
                }
                break;
            //on lvl 4 only mushroom  wolf goblin and bats are allowed
            case 4:
                r = Random.Range(8, 11);
                enemyToSpawn = Instantiate(enemiesPrefub[r%enemiesPrefub.Length], groundSpawner);
                break;
            //on lvl 5 every thing is allowed
            case 5:
                r = Random.Range(0, 10);
                if(r == 2 || r == 7)
                {
                    enemyToSpawn = Instantiate(enemiesPrefub[r], skySpawner.position, skySpawner.rotation);
                }
                else
                {
                    enemyToSpawn = Instantiate(enemiesPrefub[r], groundSpawner.position, groundSpawner.rotation);
                }
                break;
        }
        SetCooldown(Random.Range(1 - (gameLogic.lvl-1)/10, 3 - (gameLogic.lvl - 1) / 10));
    }

    
    //set spawning cooldown
    void SetCooldown(float cooldown)
    {
        spawnCooldown = cooldown;
    }

    //indicate when an enemy died
    public void EnemyDown(int points)
    {
        gameLogic.enemiesToKill--;
        gameLogic.AddPoints(points);
    }
}
