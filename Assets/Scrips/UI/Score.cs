using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Observer;

public class Score : MonoBehaviour
{
    Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText= GetComponent<Text>();
        ScoreText.text = Player.instance.Score.ToString();

        this.RegisterListener(EventID.OnScore, (param) => OnScore((Item) param));
        this.RegisterListener(EventID.OnBuyItem, (param) => OnBuyItem());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnBuyItem()
    {
        //Player.instance.Score -= price;        
        ScoreText.text = Player.instance.Score.ToString();
    }

    void OnScore(Item item)
    {
        Player.instance.Score += item.Detail.ItemValue;
        ScoreText.text = Player.instance.Score.ToString();
        LuckyBag(item);
        if (Player.instance.RockCollection) RockCollection(item);
        if (Player.instance.DiamondCollection) DiamondCollection(item);        

    }

    void RockCollection(Item item)
    {        
        if (item.ID == ItemConfig.ItemID.Rock1
                    || item.ID == ItemConfig.ItemID.Rock2
                    || item.ID == ItemConfig.ItemID.Rock3)
        {
            Player.instance.Score += item.Detail.ItemValue * 2;
        }        
    }

    void DiamondCollection(Item item)
    {        
        if (item.ID == ItemConfig.ItemID.Diamond
                    || item.ID == ItemConfig.ItemID.DiamondHoodwink)
        {
            Player.instance.Score += item.Detail.ItemValue;
        }        
    }

    void LuckyBag(Item item)
    {
        if (item.ID == ItemConfig.ItemID.LuckyBag)
        {
            if (Player.instance.Weed)
            {
                Player.instance.Score += Random.Range(2, 4) * 100;
            }
            else
            {
                Player.instance.Score += Random.Range(0, 3) * 50;
            }
        }

    }
}
