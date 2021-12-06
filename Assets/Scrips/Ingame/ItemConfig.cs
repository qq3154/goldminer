using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConfig : MonoBehaviour
{
    public enum ItemID
    {
        Gold1,
        Gold2,
        Gold3,
        Gold4,        
        Rock1,
        Rock2,
        Rock3,
        Diamond,
        TNT,
        Hoodwink,
        DiamondHoodwink,
        LuckyBag,
        Skeleton1,
        Skeleton2
    }

    [SerializeField] ItemID ID;
    

    
    public ItemID GetID()
    {
        return ID;
    }

    
}
