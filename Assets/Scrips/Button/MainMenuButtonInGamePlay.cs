using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonInGamePlay : MonoBehaviour
{
    [SerializeField] Sprite SpriteOnHover;
    [SerializeField] Sprite SpriteNormal;
    [SerializeField] Button ConfirmYesButton;
    [SerializeField] Button ConfirmNoButton;    
    [SerializeField] GameObject Message;
    [SerializeField] Text Txt;

    [SerializeField] Button PauseButton;

    SpriteRenderer Sr;
    bool onMouseOver = true;

    private void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
        Message.SetActive(false);
        PauseButton.GetComponent<Button>();
        
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
        Message.SetActive(true);
        Txt.text = "Back to Main Menu?";
        this.enabled = false;
        PauseButton.enabled = false;

    }

    public void OnConfirmYesButton()
    {
        Player.instance.PlayAgain();
        SceneManager.LoadScene(0);
    }

    public void OnConfirmNoButton()
    {
        this.enabled = true;
        Message.SetActive(false);

        //PauseButton.enabled = true;

    }
}
