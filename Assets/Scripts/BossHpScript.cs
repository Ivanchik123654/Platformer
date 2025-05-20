using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossHpScript : MonoBehaviour
{
    private int bosshp = 4;
    public GameObject groundCheacker;
    public Slider slider;
    public Manager manager;
    public GameObject canvas;
    public Transform bossBase;
    public Transform pointA;
    public Transform pointB;
    public Movement movement;
    public float speed = 0.3f;

    void Start()
    {
        slider.value = bosshp;
    }
    void Update()
    {
        if (bosshp == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, bossBase.position, 2.5f * speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
        }       
        if (Vector3.Distance(transform.position, pointA.position) < 0.1f)
        {
            Transform temp = pointA;
            pointA = pointB;
            pointB = temp;
            Animator animator = GetComponent<Animator>();
            animator.SetBool("Forward", !animator.GetBool("Forward"));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (groundCheacker.transform.position.y > transform.position.y)
            {
                bosshp--;
                Movement movement = collision.gameObject.GetComponent<Movement>();
                movement.Jump();
                slider.value = bosshp;
            }
            else if(movement.canGetDamage)
            {
                manager.RecountHP(-40);
                movement.Jump();
            }
            if (bosshp <= 0)
            {
                GameObject boss = gameObject;
                Rigidbody2D bossrb = boss.GetComponent<Rigidbody2D>();
                Collider2D bosscl = boss.GetComponent<Collider2D>();
                bossrb.bodyType = RigidbodyType2D.Dynamic;
                bosscl.enabled = false;
                GameObject bosssystem = boss.gameObject.transform.parent.gameObject;
                canvas.SetActive(false);
                StartCoroutine(DestroyObject(bosssystem, 2));
                manager.RecountHP(1);
            }
        }
    }
    IEnumerator DestroyObject(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossBase"))
        {
            bosshp = 4;
            slider.value = bosshp;
        }
    }
}
