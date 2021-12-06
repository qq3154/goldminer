using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    Animator ButtonAnimaton;
    bool onMouseOver = true;

    private void Start()
    {
        ButtonAnimaton = GetComponent<Animator>();
        ButtonAnimaton.Play("Idle");
    }
    
    private void OnMouseOver()
    {
        if (onMouseOver)
        {
            ButtonAnimaton.Play("OnHover");
            onMouseOver = false;
        }
    }

    void OnMouseExit()
    {
        ButtonAnimaton.Play("Idle");
        onMouseOver = true;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(2);
    }


}
