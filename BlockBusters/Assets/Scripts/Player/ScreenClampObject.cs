using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Clamps the Attached GameObject to the Bounds of a Perspective Camera
 * Credit: https://pressstart.vip/tutorials/2018/06/28/41/keep-object-in-bounds.html 
 * Note: Got Tired of Coding this when there is perfectly good code out there to make my life easier.
 */

public class ScreenClampObject : MonoBehaviour
{
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    private SpriteRenderer _spriteRender;


    // Use this for initialization
    void Start()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        objectWidth = _spriteRender.bounds.extents.x; //extents = size of width / 2
        objectHeight = _spriteRender.bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
        transform.position = viewPos;
    }
}

