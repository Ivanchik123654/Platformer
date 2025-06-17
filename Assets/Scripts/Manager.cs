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
    public AudioSource audioSourceDimonds;
    public AudioSource audioSourceCoins;
    public AudioSource audioSourceHeal;
    public AudioSource audioSourceDamage;
    public AudioSource audioSourceKey;
    public ParticleSystem liveeffect;
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
        if (deltahp > 0)
        {
            audioSourceHeal.Play();
            liveeffect.Play();
        }
        else
        {
            audioSourceDamage.Play();
        }
        
    }
    public void ResetLVL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void KeysRecount(int value)
    {
        keys += value;
        keystxt.text = keys.ToString();
        audioSourceKey.Play();
    }
    public void CoinRecount(int value)
    {
        coin += value;
        cointxt.text = coin.ToString();
        audioSourceCoins.Play();
    }
    public void DimondRecount(int value)
    {
        dimond += value;
        dimondtxt.text = dimond.ToString();
        audioSourceDimonds.Play();
    }

}
