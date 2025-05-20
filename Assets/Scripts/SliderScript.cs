using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScript : MonoBehaviour
{
    public Transform boss;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = new Vector3(boss.position.x, transform.position.y, transform.position.z);
    }
}
