using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public int score;
    public int lvl = 1;
    public int wave = 1;
    public bool boss;
    public bool active;
    public bool gameOver;
    public bool lvlWon;
    public int enemiesToKill;
    public float lives;
    public float maxHealth;
    public Canvas endMenu;


    private void Awake()
    {
        maxHealth = 20;
    }

    // Start is called before the first frame update
    void Start()
    {
        wave = 1; 
        lives = maxHealth;
        enemiesToKill = (10 + (5 * (lvl - 1))) * wave;
        boss = false;
        gameOver = false;
        lvlWon = false;
        active = true;
        endMenu = GameObject.Find("EndMenu").GetComponent<Canvas>();
        endMenu.enabled = false;
    }

    public void ResetOnNewScene()
    {
        Start();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            active = true;
        }
    }

    //activating the next wave
    public void NewWave()
    {
        wave += 1;
        enemiesToKill = (10 + (5 * (lvl - 1))) * wave;
        if (wave == lvl + 2)
        {
            boss = true;
            enemiesToKill = 0;
        }
    }
    
    //enable the win menu
    public void LevelUp()
    {
        lvl++;
        wave = 0;
        score += 100 * lvl;
        active = false;
        endMenu.enabled = true;
        endMenu.GetComponent<EndLvlUIScript>().LvlWon();
    }

    //enable the gameover menu
    public void GameOver()
    {
        gameOver = true;
        active = false;
        lvlWon = false;
        endMenu.GetComponent <EndLvlUIScript>().LvlWon();
    }


    //add points to the score
    public void AddPoints(int points)
    {
        score += points;
    }

    

    //reduce player health
    public void ReduceHealth(float dmg)
    {
        lives -= dmg;
        if(lives <= 0)
        {
            active = false;
            GameOver();
        }
    }
    //increase player health
    public void IncreaseHealth(float hp)
    {
        Mathf.Clamp(lives,hp+lives, maxHealth);
    }

    public void IncreaseMaxHealth(float addHp)
    {
        maxHealth += addHp;
    }

    public void ActivateGame()
    {
        active = true;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetWave()
    {
        return wave;
    }
}
