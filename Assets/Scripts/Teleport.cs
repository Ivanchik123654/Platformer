using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform otherPortal;
    private float waitTime1 = 0.6f;
    private float waitTime2 = 10f;
    [SerializeField] private bool canTeleport = true;
    public Vector3 offset;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("CanTP", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canTeleport)
        {
            StartCoroutine(TeleportPlayer(collision));
        }
    }
    IEnumerator TeleportPlayer(Collider2D player)
    {
        canTeleport = false;
        animator.SetBool("CanTP", false);
        yield return new WaitForSeconds(waitTime1);
        player.transform.position = otherPortal.transform.position + offset;
        yield return new WaitForSeconds(waitTime2);
        canTeleport = true;
        animator.SetBool("CanTP", true);
    }
}