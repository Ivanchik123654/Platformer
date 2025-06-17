using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public enum Types { key, heart, dimond, goldenchest };
    public Types type;
    private Manager manager;
    public Dictionary<string, int> pricelist = new Dictionary<string, int>()
    {
        {"key", 4 },
        {"heart", 2 },
        {"dimond", 7 },
        {"goldenchest", 5 }
    };
    void Start()
    {
        manager = GameObject.Find("manager").GetComponent<Manager>();
        Debug.Log(pricelist["key"]);
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BuyBttnKey"))
        {
            if(manager.coin >= pricelist["key"])
            {
                manager.KeysRecount(1);
                manager.CoinRecount(-pricelist["key"]);
            } 
        }
        if(collision.gameObject.CompareTag("BuyBttnHeart"))
        {
            if (manager.coin >= pricelist["heart"])
            {
                manager.RecountHP(20);
                manager.CoinRecount(-pricelist["heart"]);
            }
        }
        if (collision.gameObject.CompareTag("BuyBttnChest"))
        {
            if (manager.coin >= pricelist["goldenchest"])
            {
                int rnd = Random.Range(1, 7);
                Debug.Log(rnd);
                if (rnd == 1)
                {
                    manager.DimondRecount(1);
                }
                else if (rnd == 2 || rnd == 3)
                {
                    manager.CoinRecount(3);
                }
                else if (rnd == 4 || rnd == 5)
                {
                    manager.RecountHP(30);
                }
                else if (rnd == 6)
                {
                    manager.KeysRecount(1);
                }
                manager.CoinRecount(-pricelist["goldenchest"]);
            }
        }
        if (collision.gameObject.CompareTag("BuyBttnDimond"))
        {
            if (manager.coin >= pricelist["dimond"])
            {
                manager.DimondRecount(1);
                manager.CoinRecount(-pricelist["dimond"]);
            }
        }

    }
}
