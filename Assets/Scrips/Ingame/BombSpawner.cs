using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] GameObject bombPrefab;
    GameObject[] a = new GameObject[10];

    
    // Start is called before the first frame update
    void Start()
    {
        ////Observer
        this.RegisterListener(EventID.OnUseBomb, (param) => OnUseBomb());


        for (int i = 0; i < Player.instance.Bomb; i++)
        {
            a[i] = Instantiate(bombPrefab, transform);
            a[i].transform.position = transform.position + new Vector3(0.1f * i, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {                
    }

    void OnUseBomb()
    {        
        Player.instance.Bomb--;
        Destroy(a[Player.instance.Bomb]);       
    }

    
}
