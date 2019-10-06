using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Character : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed = 10;
    public AudioClip moveSound;
    public AudioClip jumpSound;
    public AudioClip attackSound;
    Animator anim;
    private bool isFacingRight = true;
    public Transform punch1;
    public float punch1Radius = 0.75f;
    [SerializeField] private int damage = 5;
    public Camera cam;
    



    void Start()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        cam.transform.position = rb.position;
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Run", Mathf.Abs(move));
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (move > 0 && !isFacingRight)
        {
            Flip();
            SoundManager.instance.RandomizeSfx(moveSound);
        }
            

        else if (move < 0 && isFacingRight)
        {
            Flip();
            SoundManager.instance.RandomizeSfx(moveSound);
        }
          
       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            SoundManager.instance.RandomizeSfx(jumpSound);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Atack();
            SoundManager.instance.RandomizeSfx(attackSound);
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * 5000);
        anim.SetTrigger("Jump");
     
    }

    public void Atack()
    {
        Attack.Action(punch1.position, punch1Radius, 8, damage, true);
        anim.SetTrigger("Attack");
    }


   
}
