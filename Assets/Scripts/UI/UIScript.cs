using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIScript : MonoBehaviour
{
    public HealthBar healthBar;
    public Image slimeIcon;
    public TextMeshProUGUI scoreBox;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI enemiesLeft;
    public GameObject pauseMenu;
    public GameLogic gameLogic;
    public SlimeController slime;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        slime = GameObject.Find("Slime").GetComponent<SlimeController>();
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        healthBar.SetMaxHealth(gameLogic.maxHealth);
        slimeIcon.sprite = slime.slimeState.icon;
    }

    public void ResetOnNewScene()
    {
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(gameLogic.lives);
        scoreBox.text = "Score: " + gameLogic.GetScore();
        if (!gameLogic.boss)
        {
            enemiesLeft.text = gameLogic.enemiesToKill + " Enemies To Kill";
            waveText.text = "Wave " + gameLogic.GetWave();
        }
        else
        {
            waveText.text = "Boss Wave";
            enemiesLeft.text = "Kill THe Boss";
        }
    }

    public void OpenPauseMenu()
    {
        print("Open Pause Menu");
        gameLogic.active = false;
        gameObject.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
