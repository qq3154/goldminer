using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodwinkMove : MonoBehaviour
{
    [SerializeField] float LeftPos;
    [SerializeField] float RightPos;

    float _leftPos;
    float _rightPos;

    bool isFaceLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        _leftPos = LeftPos;
        _rightPos = RightPos;
    }

    // Update is called once per frame
    void Update()
    {        
        if (transform.position.x < _leftPos && isFaceLeft)
        {
            isFaceLeft = false;          
            transform.eulerAngles = new Vector3(0, 180, 0);
            _rightPos = RightPos + Random.Range(-1f, 2f);            
        }
        if (transform.position.x > _rightPos && !(isFaceLeft))
        {            
            isFaceLeft = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
            _leftPos = LeftPos + Random.Range(-2f, 1f);            
        }
        transform.position -= transform.right * Time.deltaTime;    

    }

   
}
