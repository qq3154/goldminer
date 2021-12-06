using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer;

public class GameConfig : MonoBehaviour
{
    private void Awake()
    {
        EventDispatcher.instance.ClearAllListener();
        SoundManager.instance.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
