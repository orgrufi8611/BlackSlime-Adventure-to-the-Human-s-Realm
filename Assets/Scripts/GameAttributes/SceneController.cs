using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static string[] sceneNames = new string[] {"MainMenu","Lvl1Scene","Lvl2Scene","Lvl3Scene","Lvl4Scene","Lvl5Scene"};
    public static string currScene;
    public Animator animator;

    //load a scene by name
    public void SceneLoad(string sceneName)
    {
        StartCoroutine(SceneLoadWithTransition(sceneName));
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //load scene with cut in and out animation
    IEnumerator SceneLoadWithTransition(string sceneName)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneName);
    }

}
