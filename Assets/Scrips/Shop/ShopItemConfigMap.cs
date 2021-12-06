using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShopItemConfigMap : ScriptableObject
{
    #region Data
    public List<KeyValue> list;

    [System.Serializable]
    public class ShopItem
    {
        [SerializeField] public int price;
        [SerializeField] public string info;
    }

    [System.Serializable]
    public class KeyValue
    {
        public ShopItemConfig.ShopItemID id;
        public ShopItem shopItem;       
    }
    #endregion//Data

    #region Public - get data
    Dictionary<ShopItemConfig.ShopItemID, ShopItem> _fromListTomap
            = new Dictionary<ShopItemConfig.ShopItemID, ShopItem>();
    Dictionary<ShopItemConfig.ShopItemID, ShopItem> FromListToMap
    {
        get
        {
            // not convert from list to map yet
            if (_fromListTomap.Count == 0)
            {
                for (int n = 0; n < list.Count; n++)
                {
                    var item = list[n];
                    _fromListTomap.Add(item.id, item.shopItem);
                }
            }
            return _fromListTomap;
        }
    }

    public ShopItem GetValueFromKey(ShopItemConfig.ShopItemID id)
    {
        var result = FromListToMap[id];
        // validate data
        if (result == null)
        {
            Debug.LogError($"Not add item for ID [{id}] yet");
            return null;
        }
        return result;
    }

    #endregion //Public - get data

}
