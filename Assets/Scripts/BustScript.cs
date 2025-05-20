using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BustScript : MonoBehaviour
{
    public Movement movement;
    public Manager manager;
    private float waitBust = 20f;
    private float normalSpeed;
    private float normalJumpForce;
    private float bustSpeed = 30f;
    private float bustJumpForce = 30f;
    public TextMeshProUGUI bustText;
    void Start()
    {
        normalSpeed = movement.speed;
        normalJumpForce = movement.jumpforce;
        bustText.text = "Bust: none";
    }

    public void ButtonMouseClick()
    {
        if(manager.dimond > 0)
        {
            manager.dimond--;
            int rnd = Random.Range(1, 3);
            if (rnd == 1)
            {
                SpeedUp();
                bustText.text = "Bust: SpeedUp".ToString();
            }
            else if (rnd == 2)
            {
                JumpUp();
                bustText.text = "Bust: JumpForceUp".ToString();
            }
            else if(rnd == 3)
            {
                movement.canGetDamage = false;
                bustText.text = "Bust: Block damage".ToString();
            }
        }
        
    }
    public void SpeedUp()
    {
        movement.speed = bustSpeed;
        StartCoroutine(BustTime());
    }
    public void JumpUp()
    {
        movement.jumpforce = bustJumpForce;
        StartCoroutine(BustTime());
    }
    IEnumerator BustTime()
    {
        yield return new WaitForSeconds(waitBust);
        movement.speed = normalSpeed;
        movement.jumpforce = normalJumpForce;
        movement.canGetDamage = true;
        bustText.text = "Bust: none";
    }
}
