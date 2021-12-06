using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    [SerializeField] Sprite SpriteOnHover;
    [SerializeField] Sprite SpriteNormal;

    SpriteRenderer Sr;
    bool onMouseOver = true;

    private void Start()
    {
        Sr = GetComponent<SpriteRenderer>();
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
        Player.instance.PlayAgain();
        SceneManager.LoadScene(2); // Load Level Start Scene
    }
}
