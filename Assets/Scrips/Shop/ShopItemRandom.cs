using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemRandom : MonoBehaviour
{
    //[SerializeField] GameObject[] shopitem;

    // Start is called before the first frame update
    void Start()
    {
        

        int x = Random.Range(0, transform.childCount - 1);
        Destroy(gameObject.transform.GetChild(x).gameObject);
        

        int y = Random.Range(0, transform.childCount - 1);
        while( y == x)
        {
            y = Random.Range(0, transform.childCount - 1);
        }
        Destroy(gameObject.transform.GetChild(y).gameObject);
        
        
        GameObject child;
        int distance = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i != x && i != y)
            {
                child = gameObject.transform.GetChild(i).gameObject;
                child.transform.position = transform.position + new Vector3(distance * 2.5f, 0, 0);
                distance++;                
            }
        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
