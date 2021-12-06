using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Observer;

public class Timer : MonoBehaviour
{
    float _timer;
    int timeInt;

    // Start is called before the first frame update
    void Start()
    {
        _timer = Player.instance.Time;        
    }

    // Update is called once per frame
    void Update()
    {
        //timeInt = Mathf.FloorToInt(_timer);        
        gameObject.GetComponent<Text>().text = Mathf.FloorToInt(_timer) + "";

        if (_timer > 0.1f)
        {
            _timer -= Time.deltaTime;
        }
        else
        {            
            SceneManager.LoadScene(3);
        }
    }
}