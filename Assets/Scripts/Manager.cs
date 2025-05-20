using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public float hp = 100f;
    public TextMeshProUGUI hptxt;
    public int keys = 0;
    public TextMeshProUGUI keystxt;
    public int coin = 0;
    public TextMeshProUGUI cointxt;
    public int dimond = 0;
    public TextMeshProUGUI dimondtxt;
    void Start()
    {

    }
    void Update()
    {
        if (hp <= 0)
        {
            ResetLVL();
        }
    }
    public void RecountHP(float deltahp)
    {
        hp += deltahp;
        hptxt.text = hp.ToString();
    }
    public void ResetLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void KeysRecount(int value)
    {
        keys += value;
        keystxt.text = keys.ToString();
    }
    public void CoinRecount(int value)
    {
        coin += value;
        cointxt.text = coin.ToString();
    }
    public void DimondRecount(int value)
    {
        dimond += value;
        dimondtxt.text = dimond.ToString();
    }

}
