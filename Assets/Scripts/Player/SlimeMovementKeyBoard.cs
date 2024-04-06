using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeMovementKeyBoard : MonoBehaviour
{
    public AbilityButton button;
    SlimeController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<SlimeController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("GameLogic").GetComponent<GameLogic>().active)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                controller.MoveSlime(1);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                controller.MoveSlime(-1);
            }
            else
            {
                controller.MoveSlime(0);
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                controller.Jump();
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                controller.Glide();
            }

            else if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                controller.StopGliding();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                controller.Shot();
            }

            //input to activate and scroll through abilities
            if (Input.GetKeyUp(KeyCode.LeftBracket))
            {
                button.PrevAbility();
            }
            else if (Input.GetKeyDown(KeyCode.RightBracket))
            {
                button.NextAbility();
            }
            else if (Input.GetKeyUp(KeyCode.P))
            {
                button.ActivateAbility();
            }
        }
    }
}
