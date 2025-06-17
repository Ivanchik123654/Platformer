using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{
    public Transform cameraTransform;
    public float paralaxEffect = 0.7f;
    private float width;
    private float startPoseX;
    void Start()
    {
        startPoseX = transform.position.x;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    private void Update()
    {
        float temp = cameraTransform.position.x * (1 - paralaxEffect);
        float dist = cameraTransform.position.x * paralaxEffect;
        transform.position = new Vector3(startPoseX + dist,cameraTransform.position.y, transform.position.z);
        if (temp > startPoseX + width)
        {
            startPoseX += width;
        }
        else if (temp < startPoseX - width)
        {
            startPoseX -= width;
        }
    }
}
