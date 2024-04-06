using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public int score;
    public float damageBuff = 0;
    public float healthBuff = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }
    private void LateUpdate()
    {
        GameLogic gameLogic = Object.FindObjectOfType<GameLogic>();
        if(gameLogic != null)
        {
            if(gameLogic.score == 0 && score != 0)
            {
                gameLogic.score = score;
            }
            else
            {
                score = gameLogic.score;
            }
        }
    }
}
