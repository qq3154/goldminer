using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Observer;

public class ShopItem : MonoBehaviour
{
    [Header("ShareData")]
    [SerializeField] ShopItemConfigMap shopItemConfigMap;

    [Header("Input")]
    [SerializeField] Text showItemInfo;
    [SerializeField] GameObject textBox;
    int _price;
    //ShopItemConfig shopItemConfig;


    bool onMouseOver = true;

    
    // Start is called before the first frame update
    void Start()
    {        
        textBox.SetActive(false);

        ShopItemConfig shopItemConfig = gameObject.GetComponent<ShopItemConfig>();
        var shopItem = shopItemConfigMap.GetValueFromKey(shopItemConfig.GetID());

        Text price = gameObject.transform.GetChild(0).GetComponent<Text>();
        _price  = shopItem.price + Random.Range(-5, 10) * 10;
        price.text = _price.ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (onMouseOver)
        {
            textBox.SetActive(true);
            ShopItemConfig selectedItem = gameObject.GetComponent<ShopItemConfig>();
            var shopItem = shopItemConfigMap.GetValueFromKey(selectedItem.GetID());
            showItemInfo.text = shopItem.info;
            onMouseOver = false;
        }        
    }
    void OnMouseExit()
    {
        textBox.SetActive(false);
        showItemInfo.text = "";
        onMouseOver = true;
    }
    private void OnMouseDown()
    {
        ShopItemConfig selectedItem = gameObject.GetComponent<ShopItemConfig>();
        var shopItem = shopItemConfigMap.GetValueFromKey(selectedItem.GetID());        
        if(_price <= Player.instance.Score)
        {
            

            switch (selectedItem.GetID())
            {
                case ShopItemConfig.ShopItemID.Redbull:
                    Player.instance.Strenght = 3;
                    break;
                case ShopItemConfig.ShopItemID.Bomb:
                    Player.instance.Bomb++;
                    break;
                case ShopItemConfig.ShopItemID.RockCollection:
                    Player.instance.RockCollection = true;
                    break;
                case ShopItemConfig.ShopItemID.DiamondCollection:
                    Player.instance.DiamondCollection = true;
                    break;
                case ShopItemConfig.ShopItemID.Time:
                    Player.instance.Time += 30;
                    break;
                case ShopItemConfig.ShopItemID.Oil:
                    Player.instance.MoveSpeed =2;
                    break;
                case ShopItemConfig.ShopItemID.Weed:
                    Player.instance.Weed = true;
                    break;
                default:
                    break;

            }
            
            //SoundManager.instance.PlaySound(SoundManager.instance.Buy);
            Player.instance.Score -= _price;            
            Destroy(gameObject);
            textBox.SetActive(false);

            this.PostEvent(EventID.OnBuyItem);
        }       
    }
    
}
