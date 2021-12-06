using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Observer;

public class HookDisplay : MonoBehaviour
{
    [SerializeField] public Sprite HookEmpty;

    SpriteRenderer Sprite;

    

    // Start is called before the first frame update
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();

        this.RegisterListener(EventID.OnHookRotate, (param) => OnHookRotate());
        this.RegisterListener(EventID.OnGrabItem, (param) => OnGrabItem((Item)param));
        this.RegisterListener(EventID.OnUseBomb, (param) => OnUseBomb());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHookRotate()
    {
        Sprite.sprite = HookEmpty;
    }

    void OnGrabItem(Item item)
    {
        Sprite.sprite = item.Detail.hookedItemSprite;
    }

    void OnUseBomb()
    {
        Sprite.sprite = HookEmpty;
    }

    
}
