using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    GameObject slime;
    bool initiate;
    bool follow;
    public Vector3 lastLoction;
    // Start is called before the first frame update
    void Start()
    {
        follow = true;
        initiate = false;
        slime = GameObject.Find("Slime");
    }

    // Update is called once per frame
    void Update()
    {
        if (!initiate)
        {
            lastLoction = slime.transform.position;
            initiate = true;
        }
        else if(follow) 
        {
            transform.Translate((slime.transform.position.x - lastLoction.x),0,0);
            lastLoction = slime.transform.position;
        }
    }

    public void StopFollow()
    {
        follow = false;
    }
}
