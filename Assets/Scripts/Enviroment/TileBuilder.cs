using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileBuilder : MonoBehaviour
{
    public Transform endIndicator,currTransfor,LastTransform;
    public GameObject[] mapPrefub = new GameObject[5];
    public Grid grid;
    public Vector3 lastTileLocation;
    public Vector3 currLocation;
    GameObject slime;
    GameLogic gameLogic;
    int spawnIndex;
    bool spawnedBoss;

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        slime = GameObject.Find("Slime");
        spawnIndex = 0;
        currLocation = transform.position;
        lastTileLocation = transform.position;
        spawnedBoss = false;
        SpawnNewMap();
        SpawnNewMap();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameLogic.boss)
        {
            //indicator to cross to indicate spawn new tiles
            endIndicator.position = new Vector3(lastTileLocation.x + mapPrefub[spawnIndex % mapPrefub.Length].GetComponent<Tilemap>().cellBounds.x / 6, lastTileLocation.y,lastTileLocation.z);
            
            //build a new tile set on the screen
            if(slime.transform.position.x > endIndicator.position.x) 
            {
                SpawnNewMap();
            }
        }
        else if(gameLogic.boss && !spawnedBoss)
        {
            //spawn the boss tileset
            if (slime.transform.position.x > endIndicator.position.x)
            {
                SpawnBossMap();
                spawnedBoss = true;
            }
        }
        currTransfor.position = currLocation;
        LastTransform.position = lastTileLocation;
    }

    //spawn a new premade tilemap
    public void SpawnNewMap()
    {
        lastTileLocation = currLocation;
        GameObject newTilemap = Instantiate(mapPrefub[spawnIndex % 4], currLocation, transform.rotation);
        newTilemap.transform.SetParent(grid.transform);
        currLocation -= Vector3.right * newTilemap.GetComponent<Tilemap>().cellBounds.x * 1.75f * newTilemap.GetComponent<Tilemap>().cellSize.x;
        spawnIndex++;
    }

    //spawn the boss stage tilemap at the end of the level
    public void SpawnBossMap()
    {
        GameObject newTilemap = Instantiate(mapPrefub[4], currLocation,transform.rotation);
        newTilemap.transform.SetParent(grid.transform);
        currLocation -= Vector3.right * newTilemap.GetComponent<Tilemap>().cellBounds.x * 2 * newTilemap.GetComponent<Tilemap>().cellSize.x;
    }
}
