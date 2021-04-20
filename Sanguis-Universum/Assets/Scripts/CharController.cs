using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.Rendering.PostProcessing;

public class CharController : MonoBehaviour
{

    public Animator animator;

    public Transform GroundCheck;
    public LayerMask m_WhatIsGround;

    public float m_JumpForce = 400f;
    const float k_GroundedRadius = .05f;
    private bool m_Grounded;
    private bool m_FacingRight = true;
    private Vector3 m_Velocity = Vector3.zero;
    private Rigidbody2D m_Rigidbody2D;
    private float m_MovementSmooth = .05f;

    bool jump = false;
    float h_Move = 0f;
    public float runSpeed = 40f;

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    void Awake ()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if(OnLandEvent == null)
        {
            OnLandEvent = new UnityEvent();
        }
    }

    void Move (float move, bool jump)
    {
        if(m_Grounded || !m_Grounded)
        {
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);

            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmooth);


            if (move > 0 && !m_FacingRight)
            {
                
                Flip();
            }
            
            else if (move < 0 && m_FacingRight)
            {
                
                Flip();
            }
        }

        if (m_Grounded && jump)
        {
            
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));

        }
    }

    void Flip()
    {
        
        m_FacingRight = !m_FacingRight;

        
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    void Update ()
    {
        h_Move = Input.GetAxisRaw("Horizontal") * runSpeed;

        //animator.SetFloat("Speed", Mathf.Abs(h_Move));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            //animator.SetTrigger("JumpStart");
            
        }

        if(Mathf.Abs(h_Move) > 0 || !m_Grounded)
        {

        }
    }

    public void OnLanding()
    {
        
        //animator.SetTrigger("Landing");
    }


    void FixedUpdate ()
    {
        //animator.ResetTrigger("Landing");
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        //Collider[] colliders = Physics.OverlapSphere(GroundCheck.position, k_GroundedRadius);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                OnLanding();
                Debug.Log(colliders[i].name);
            }
        }

        Move(h_Move * Time.fixedDeltaTime, jump);
        jump = false;
        
    }
}
