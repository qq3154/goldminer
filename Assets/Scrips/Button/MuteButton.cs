using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButton : MonoBehaviour
{
    [SerializeField] Sprite SpriteOnHover;
    [SerializeField] Sprite SpriteNormal;

    SpriteRenderer Sr;
    //bool onMouseOver = true;
    bool isMute = false;
    private void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
    }

    //private void OnMouseOver()
    //{
    //    if (onMouseOver)
    //    {
    //        Sr.sprite = SpriteOnHover;
    //        onMouseOver = false;
    //    }
    //}

    //void OnMouseExit()
    //{
    //    Sr.sprite = SpriteNormal;
    //    onMouseOver = true;
    //}

    private void OnMouseDown()
    {
        if (isMute)
        {
            AudioListener.volume = 1f;
            Sr.sprite = SpriteNormal;
            isMute = false;
        }
        else
        {
            AudioListener.volume = 0f;
            Sr.sprite = SpriteOnHover;
            isMute = true;
        }
    }
}
