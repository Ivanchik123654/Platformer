using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 2f;
    public float jumpforce = 3f;
    private Rigidbody2D rb;
    private float horizontal;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public bool isGrounded = false;
    public Manager manager;
    [SerializeField] private float minY = -80f;
    public GameObject groundCheacker;
    private bool isonLadder = false;
    public bool canGetDamage = true;
    private TrailRenderer trailRenderer;  
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Flip();
        transform.Translate(Vector2.right * speed * Time.deltaTime * horizontal);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {          
            Jump();
        }

        if (horizontal != 0)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
        if (OutOfBounds() == true)
        {
            manager.ResetLVL();
        }
        if (isGrounded)
        {
            trailRenderer.emitting = false;
        }
        else
        {
            trailRenderer.emitting = true;
        }
    }
    void Flip()
    {
        if (horizontal > 0)
        {
            spriteRenderer.flipX = true;
        }

        if (horizontal < 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        isGrounded = true;
        animator.SetTrigger("land");
        animator.SetBool("isJumping", false);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (groundCheacker.transform.position.y > collision.transform.position.y)
            {
                if (collision.gameObject.transform.parent != null)
                {
                    GameObject bug = collision.gameObject;
                    Debug.Log(bug.name);
                    Rigidbody2D bugrb = bug.GetComponent<Rigidbody2D>();
                    Collider2D bugcl = bug.GetComponent<Collider2D>();
                    bugrb.bodyType = RigidbodyType2D.Dynamic;
                    bugcl.enabled = false;
                    GameObject bugsystem = bug.gameObject.transform.parent.gameObject;
                    Debug.Log(bugsystem.name);
                    StartCoroutine(DestroyObject(bugsystem, 2));
                    manager.CoinRecount(1);
                    Jump();
                }
            }
            else if(canGetDamage)
            {
                manager.RecountHP(-20);
                Jump();
            }
        }
        if (collision.gameObject.CompareTag("EnemyPila") && canGetDamage)
        {
            manager.RecountHP(-30);
            Jump();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        animator.SetBool("isJumping", true);       
    }
    bool OutOfBounds()
    {
        if (transform.position.y < minY)
        {
            return true;
        }
        else
        {
            return false;
        }       
    }
    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
    }
    IEnumerator DestroyObject(GameObject gameObject, float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            manager.KeysRecount(1);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Heart"))
        {
            manager.RecountHP(20);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Coin"))
        {
            manager.CoinRecount(1);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("ladder"))
        {
            isonLadder = true;
            rb.gravityScale = 0f;
        }
        if (collision.CompareTag("Dimond"))
        {
            manager.DimondRecount(1);
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {        
        if (collision.CompareTag("ladder") && isonLadder)
        {
            float vertical = Input.GetAxis("Vertical");
            transform.Translate(Vector2.up * speed * Time.deltaTime * vertical);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ladder"))
        {
            isonLadder = false;
            rb.gravityScale = 1f;
        }
    }
}
