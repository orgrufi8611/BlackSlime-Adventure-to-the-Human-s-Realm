using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject.Find("Slime").GetComponent<SlimeController>().startPos = transform;
    }
}
