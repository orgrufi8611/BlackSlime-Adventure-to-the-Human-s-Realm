using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    public Canvas levelSelect;
    public Canvas menu;
    public void StartGame()
    {
        
        GameObject.Find("LevelLoader").GetComponent<SceneController>().SceneLoad(SceneController.sceneNames[1]);
    }

    public void LevelSelect()
    {
        levelSelect.gameObject.SetActive(true);
        menu.gameObject.SetActive(false);
    }

    public void BackToMenu()
    {
        levelSelect.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }

    public void LoadLevel(int scene)
    {
        GameObject.Find("LevelLoader").GetComponent<SceneController>().SceneLoad(SceneController.sceneNames[scene]);
    }

    public void ExitGame()
    {
        print("Quit Game");
        Application.Quit();
    }
}
