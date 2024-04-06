using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    public SlimeSO[] slimeStates = new SlimeSO[6];
    public Image abilityIcon;
    public TextMeshProUGUI time;
    public int currAbility;
    public int availableAbilities;
    float[] timepass = new float[6];
    float[] cooldown = new float[6] {Mathf.Infinity,10,30,120,120,180};
    float abilityTime;
    public GameObject  slime;
    public GameLogic gameLogic;
    bool abilityACtive;
    // Start is called before the first frame update
    void Start()
    {
        abilityACtive = false;
        abilityTime = 0;
        availableAbilities = 0;
        slime = GameObject.Find("Slime");
        gameLogic = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        currAbility = 0;
        for(int i = 0; i < timepass.Length; i++)
        {
            timepass[i] = 0;
        }
        abilityIcon.sprite = slimeStates[0].icon;
    }
    private void Update()
    {
        availableAbilities = gameLogic.lvl - 1;
        if(abilityACtive)
        {
            abilityTime += Time.deltaTime;
        }
        if(abilityTime > cooldown[currAbility])
        {
            slime.GetComponent<SlimeController>().slimeState = slimeStates[0];
            currAbility = 0;
        }
        for (int i = 0; i < timepass.Length; i++)
        {
            if (cooldown[i] < 1000)
            {
                timepass[i] = cooldown[i];
            }
            else
            {
                timepass[i] = 0;
            }
        }
        timepass[currAbility] = cooldown[currAbility] - abilityTime;
        
        if (slimeStates[0] == null)
        {
            print("Couldnt load slime state");
        }
        if(currAbility != 0)
        {
            time.text = timepass[currAbility].ToString();
        }
        else
        {
            time.text = "";
        }
    }

    public void ActivateAbility()
    {
        if(currAbility != 0)
        {
            slime.GetComponent<SlimeController>().ChangeSlimeState(slimeStates[currAbility]);
            abilityTime = 0;
        }

    }
    
    public void NextAbility()
    {
        if(availableAbilities != 0)
        {
            if(currAbility + 1 > availableAbilities)
            {
                currAbility = 0;
            }
            else
            {
                currAbility += 1;
            }
            abilityIcon.sprite = slimeStates[currAbility].icon;
        }
    }

    public void PrevAbility()
    {
        if (availableAbilities != 0)
        {
            if (currAbility - 1 < 0)
            {
                currAbility = availableAbilities;
            }
            else
            {
                currAbility -= 1;
            }
        }
    }

}
