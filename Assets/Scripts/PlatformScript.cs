using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    private Collider2D cldr;
    private PlatformEffector2D effector;
    private float waitTime = 0.5f;
    [SerializeField] private bool isDropping = false;

    void Start()
    {
        cldr = GetComponent<Collider2D>();
        effector = GetComponent<PlatformEffector2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !isDropping)
        {
            StartCoroutine(DropDownPlatform());
        }
    }
    void ResetEffector()
    {
        effector.rotationalOffset = 0f;
    }
    IEnumerator DropDownPlatform()
    {
        isDropping = true;
        cldr.enabled = false;
        yield return new WaitForSeconds(waitTime);
        isDropping = false;
        cldr.enabled = true;
    }
}