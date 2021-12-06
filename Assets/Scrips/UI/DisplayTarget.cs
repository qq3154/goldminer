using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = Player.instance.Target.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
}
