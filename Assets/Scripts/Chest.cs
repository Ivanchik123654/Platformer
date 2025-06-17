using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public enum ChestTypes {keyChest, goldenChest, woodenChest};
    public ChestTypes type;
    public GameObject[] prizesPrefabs;
    public Manager manager;
    void Start()
    {
        manager = GameObject.Find("manager").GetComponent<Manager>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Было касаниние");
            if (type == ChestTypes.keyChest && manager.keys > 0)
            {
                int rnd = Random.Range(1, 4);
                Debug.Log(rnd);
                if (rnd == 1)
                {
                    manager.DimondRecount(1);
                }
                else if (rnd == 2)
                {
                    manager.CoinRecount(3);
                }
                else if (rnd == 3)
                {
                    manager.RecountHP(40);
                }
                manager.KeysRecount(-1);
                Destroy(gameObject);
            }
            else if(type == ChestTypes.goldenChest)
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
                Destroy(gameObject);
            }
            else if (type == ChestTypes.woodenChest)
            {
                int rnd = Random.Range(1, 9);
                Debug.Log(rnd);
                if (rnd == 1)
                {
                    manager.DimondRecount(1);
                }
                else if (rnd == 2 || rnd == 3 || rnd == 4)
                {
                    manager.CoinRecount(1);
                }
                else if (rnd == 5 || rnd == 6 || rnd == 7)
                {
                    manager.RecountHP(20);
                }
                else if (rnd == 8)
                {
                    manager.KeysRecount(1);
                }
                Destroy(gameObject);
            }
        }
    }
}
