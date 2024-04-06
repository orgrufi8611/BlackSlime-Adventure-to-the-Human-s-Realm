using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndLvlUIScript : MonoBehaviour
{
    public Button retry;
    public Button nextLevel;
    public Button prizeDmg;
    public Button prizeHP;
    public TextMeshProUGUI prizeDmgText;
    public TextMeshProUGUI prizeHPText;
    public TextMeshProUGUI Endtitle;
    public SlimeSO basicSlime;
    GameLogic gameLogic;
    bool lvlWon;
    int dmgInc, hpInc;
    // Start is called before the first frame update
    void Start()
    {
        lvlWon = false;
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        dmgInc = Random.Range(1, 10);
        prizeDmgText.text = "+" + dmgInc + " Damage";
        hpInc = Random.Range(5, 15);
        prizeHPText.text = "+" + hpInc + " HP";
    }

    public void ResetOnNewScene()
    {
        Start();
    }


    public void BackToMenu()
    {
        GameObject.Find("LevelLoader").GetComponent<SceneController>().SceneLoad(SceneController.sceneNames[0]);
    }

    public void Retry()
    {
        GameObject.Find("LevelLoader").GetComponent<SceneController>().ResetScene();
    }

    public void NextLevel()
    {
        GameObject.Find("LevelLoader").GetComponent<SceneController>().SceneLoad(SceneController.sceneNames[gameLogic.lvl]);
    }

    public void LvlWon()
    {
        lvlWon = true;
        basicSlime.damage += gameLogic.lvl;
        if (!lvlWon)
        {
            Endtitle.text = "Game Over";
            nextLevel.gameObject.SetActive(false);
            prizeDmg.gameObject.SetActive(false);
            prizeHP.gameObject.SetActive(false);
            retry.gameObject.SetActive(true);
        }
        else if (lvlWon)
        {
            Endtitle.text = "Level Up";
            nextLevel.gameObject.SetActive(true);
            prizeDmg.gameObject.SetActive(true);
            prizeHP.gameObject.SetActive(true);
            retry.gameObject.SetActive(false);
        }
    }

    public void HPIncrease()
    {
        gameLogic.IncreaseMaxHealth(hpInc);
        prizeHP.gameObject.SetActive(false);
        prizeDmg.gameObject.SetActive(false);
    }

    public void DmgIncrease()
    {
        basicSlime.damage += dmgInc;
        prizeDmg.gameObject.SetActive(false);
        prizeDmg.gameObject.SetActive(false);
    }
}
