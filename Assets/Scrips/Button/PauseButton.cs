using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] Sprite SpriteOnHover;
    [SerializeField] Sprite SpriteNormal;
    [SerializeField] GameObject Message;
    [SerializeField] Text Txt;

    SpriteRenderer Sr;
    bool onMouseOver = true;
    static bool isPause = false;
    private void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
        Message.SetActive(false);
        //Message.transform.position = new Vector3(0, -1000, 0);
        
    }

    private void OnMouseOver()
    {
        if (onMouseOver)
        {
            Sr.sprite = SpriteOnHover;
            onMouseOver = false;
        }
    }

    void OnMouseExit()
    {
        Sr.sprite = SpriteNormal;
        onMouseOver = true;
    }

    private void OnMouseDown()
    {
        if (isPause)
        {
            Time.timeScale = 1;
            AudioListener.volume = 1f;
            isPause = false;
            Message.SetActive(false);

        }
        else
        {
            Time.timeScale = 0;
            AudioListener.volume = 0f;
            isPause = true;
            Txt.text = "Game is Paused";
            Message.SetActive(true);

        }
    }
    
}
