using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemConfig : MonoBehaviour
{
    public enum ShopItemID
    {
        Redbull,
        Bomb,
        RockCollection,
        Time,
        DiamondCollection,
        Weed,
        Oil
    }

    [SerializeField] ShopItemID ID;

    public ShopItemID GetID()
    {
        return ID;
    }
    
}
