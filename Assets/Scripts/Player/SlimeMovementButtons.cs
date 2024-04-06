using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovementButtons : MonoBehaviour
{
    public int direction;
    SlimeController controller;
    bool glide;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<SlimeController>();
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        controller.MoveSlime(direction);
        if (glide)
        {
            controller.Glide();
        }
        else
        {
            controller.StopGliding();
        }
    }

    public void ButtonAction(string button)
    {
        if (GameObject.Find("GameLogic").GetComponent<GameLogic>().active)
        {
            switch (button)
            {
                case "Right":
                    direction = 1;
                    break;
                case "Left":
                    direction = -1;
                    break;
                case "Stop":
                    direction = 0;
                    break;
                case "Jump":
                    controller.Jump();
                    break;
                case "Glide":
                    glide = true;
                    break;
                case "StopGlide":
                    glide = false;
                    break;
                case "Shot":
                    controller.Shot();
                    break;
            }
        }
    }
}
