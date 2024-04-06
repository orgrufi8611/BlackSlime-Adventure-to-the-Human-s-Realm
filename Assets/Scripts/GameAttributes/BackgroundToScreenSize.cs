using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundToScreenSize : MonoBehaviour
{
    bool init;
    // Start is called before the first frame update
    void Start()
    {
        init = false;
    }
    private void Update()
    {
        if (!init)
        {
            Sprite sprite = GetComponent<SpriteRenderer>().sprite;
            float width = sprite.bounds.size.x;
            float height = sprite.bounds.size.y;
            transform.localScale = new Vector2(ScreenSize.screenUnitWidth / width, ScreenSize.screenUnitHeight / height);
            transform.position = new Vector3(0, - ScreenSize.screenUnitHeight  / 2, 0);
        }
    }
}
