using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugScript : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, pointA.position) < 0.1f)
        {
            Transform temp = pointA;
            pointA = pointB;
            pointB = temp;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }       
    }
    
}
