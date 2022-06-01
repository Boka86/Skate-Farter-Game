using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float tourqPower;
    [SerializeField] private float jumpPower;
    [SerializeField] private float hitPower;
    
    //----------------------------------------
    private Animator _anim;
    private SurfaceEffector2D surfaceEffector2D;
    //----------------------------------------
    [SerializeField] private bool canJump;
    [SerializeField] private bool isDead = false;
    bool tourqeNeg;
    bool tourqePos;

    //----------------------------------------
    [SerializeField] private ParticleSystem snowFx;


    Rigidbody2D rb;
    void Start()
    {
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        StartCoroutine(SurfaceSpeed());
        isDead = false;
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController();
        Jump();
    }
    private void FixedUpdate()
    {

        ApplyTourqe();


    }
    void PlayerController()
    {
        if(Input.GetKey(KeyCode.D))
        {
            tourqeNeg = true;
            
            Debug.Log(" D IS PRESSED");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            tourqeNeg = false;
            
        }
        else if(Input.GetKey(KeyCode.A))
        {
            tourqePos = true;
            
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            tourqePos = false;
        }

    }

    void ApplyTourqe()
    {
        if (tourqeNeg)
        {
            rb.AddTorque(-tourqPower);
        }
        if (tourqePos)
        {
            rb.AddTorque(tourqPower);
        }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&canJump&&isDead==false)
        {
             rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            _anim.SetTrigger("Jump_01");
        
            
         
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            
            
        }

     
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
            snowFx.Stop();
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            snowFx.Play();
        }
       
    }
    public void HitObsEffect()
    {
       

        isDead = true;
        _anim.SetTrigger("Dead");
        rb.AddForce(Vector2.up * hitPower, ForceMode2D.Impulse);
       
    }

    IEnumerator  SurfaceSpeed ()
    {
        yield return new WaitForSeconds(2f);
        surfaceEffector2D.speed = 30;
    }
}
