using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollEffectMultiplayer;
    Transform cameraTransform;
    Vector3 lastCameraPosition;
    float textureUnitSizeX;
    bool init;
    
    // Start is called before the first frame update
    void Start()
    {
        init = false;
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!init)
        {
            SetSize();
            init = true;
        }

        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * scrollEffectMultiplayer,0,0);
        lastCameraPosition = cameraTransform.position;

        if(Mathf.Abs(cameraTransform.position.x - transform.position.x) >= 2* textureUnitSizeX) 
        {
            float offsetX = (cameraTransform.position.x - transform.position.x)%textureUnitSizeX*transform.localScale.x;
            transform.position = new Vector3(cameraTransform.position.x + offsetX, transform.position.y,transform.position.z);
        }

    }

    void SetSize()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        //size the background to 5 times the screen
        float width = sprite.bounds.size.x;
        float height = sprite.bounds.size.y;
        transform.localScale = new Vector2(ScreenSize.screenUnitWidth / width, ScreenSize.screenUnitHeight / height);
        GetComponent<SpriteRenderer>().drawMode = SpriteDrawMode.Tiled;
        GetComponent<SpriteRenderer>().size = new Vector2(5 * GetComponent<SpriteRenderer>().size.x, GetComponent<SpriteRenderer>().size.y);
    }
}
