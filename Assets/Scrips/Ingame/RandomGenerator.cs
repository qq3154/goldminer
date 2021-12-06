using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    [SerializeField] GameObject[] Pref;
    // Start is called before the first frame update
    void Start()
    {
        int rnd =Random.Range(0, Pref.Length);
        GameObject item = Instantiate(Pref[rnd], transform.position, Quaternion.identity);
        item.transform.parent = gameObject.transform;
        ItemConfig _itemConfig = gameObject.GetComponent<ItemConfig>();
        _itemConfig = item.GetComponent<ItemConfig>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
