using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveBetweenScenes : MonoBehaviour
{
    public float objectID;

    private void Awake()
    {
        objectID = Time.time;
    }

    void Start()
    {
        for (int i = 0; i < Object.FindObjectsOfType<SaveBetweenScenes>().Length; i++)
        {
            if (Object.FindObjectsOfType<SaveBetweenScenes>()[i] != this)
            {
                if (Object.FindObjectsOfType<SaveBetweenScenes>()[i].objectID > objectID)
                {
                    Destroy(gameObject);
                }
            }
        }
        DontDestroyOnLoad(gameObject);
    }
}
