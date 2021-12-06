using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemConfigMap : ScriptableObject
{
    #region Data
    public List<KeyValue> list;

    [System.Serializable]
    public class Item
    {       
        [SerializeField] public int ItemValue;
        [SerializeField] public float ItemWeight;
        [SerializeField] public Sprite hookedItemSprite;
    }

    [System.Serializable]
    public class KeyValue
    {
        public ItemConfig.ItemID id;
        public Item grabbableItem;
    }
    #endregion//Data


    #region Public - get data
    Dictionary<ItemConfig.ItemID, Item> _fromListTomap =
        new Dictionary<ItemConfig.ItemID, Item>();
    Dictionary<ItemConfig.ItemID, Item> FromListToMap
    {
        get
        {
            // not convert from list to map yet
            if(_fromListTomap.Count == 0)
            {
                for (int n = 0; n < list.Count; n++)
                {
                    var item = list[n];                    
                    _fromListTomap.Add(item.id, item.grabbableItem);
                    
                }
            }
            return _fromListTomap;
        }
    }

    public Item GetValueFromKey(ItemConfig.ItemID id)
    {
        var result = FromListToMap[id];
        // validate data
        if(result == null)
        {
            Debug.LogError($"Not add item for ID [{id}] yet");
            return null;
        }
        return result;
    }
    #endregion //Public - get data
}
