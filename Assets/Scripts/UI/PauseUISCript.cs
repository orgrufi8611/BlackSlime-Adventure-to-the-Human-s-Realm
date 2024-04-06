using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUISCript : MonoBehaviour
{
    public GameObject UI;
    public SceneController sceneController;
    
    public void ExitButton()
    {
        sceneController.SceneLoad(SceneController.sceneNames[0]);
    }

    public void ResumeButton() 
    {
        GameObject.Find("GameLogic").GetComponent<GameLogic>().active = true;
        UI.SetActive(true);
        gameObject.SetActive(false);
    }
}
