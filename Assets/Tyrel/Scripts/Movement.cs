using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [HideInInspector] public bool Grounded;
    [HideInInspector] public bool Jumping;
    [HideInInspector] public float VerticalVelocity;
    [HideInInspector] public float HorizontalVelocity;

    [SerializeField] Transform feet;
    [SerializeField] LayerMask _groundLayer;
    Rigidbody2D _rb;

    public float Speed = 8;
    public float JumpSpeed = 15f;

    
    public bool isDashing;
    public bool _dashing;
    float _dashSpeed = 20;
    public float _dashCount = 1;
    float _jumpCount = 1;
    

    //CapsuleCollider2D _capsule;
    //LayerMask _collisionLayers = ~(1 << 8);
    //const float _groundCheckDist = 0.1f;
    //const float _groundCheckSizeMulti = 0.9f;

    void Start()
    {
        _dashCount = 1;
        //_capsule = GetComponent<CapsuleCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
        
    }
    public void Jump()
    {
        if (Grounded || _jumpCount > 0)
        {
            Jumping = true;
            Grounded = false;
        }
    }
    public void Dash()
    {
        if (_dashCount > 0)
            _dashing = true;

    }
    public void Move(float input)
    {
        HorizontalVelocity = input * Speed;
    }
    void FixedUpdate()
    {
        CheckGrounded();

        

        if (Jumping)
        {
            VerticalVelocity = JumpSpeed;
            _jumpCount -= 1;
            Jumping = false;
        }
        else
        {
            VerticalVelocity = _rb.velocity.y;
            
        }

        if (_dashing)
        {
            StartCoroutine(Dashing(transform.localScale.x));
            _dashing = false;
        }
        


        if (Grounded)
        {
            _jumpCount = 1;
            if (!isDashing )
            {
                _dashCount = 1;
            }
        }

        if(!isDashing)
            _rb.velocity = new Vector2(HorizontalVelocity, VerticalVelocity);
    }

    IEnumerator Dashing(float direction)
    {
        isDashing = true;
        _dashCount = 0;
        _rb.velocity = new Vector2(_rb.velocity.x, 0f);
        _rb.AddForce(new Vector2(_dashSpeed * direction, 0f), ForceMode2D.Impulse);
        float gravity = _rb.gravityScale;
        _rb.gravityScale = 0;
        yield return new WaitForSeconds(.2f);
        isDashing = false;
        _rb.gravityScale = gravity;
        
    }

    void CheckGrounded()
    {
        if(Physics2D.OverlapCircle(feet.position, 0.2f, _groundLayer))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
    }

    //bool CheckGrounded()
    //{
    //    Vector2 pos = (Vector2)transform.position + _capsule.offset;
    //    Vector2 direction = new Vector2(0, -_groundCheckDist);
    //    Vector2 size = _capsule.size * _groundCheckSizeMulti;
    //    RaycastHit2D hit = Physics2D.CapsuleCast(pos, size, _capsule.direction, 0, direction, direction.magnitude, _collisionLayers);
        
    //    return hit.collider != null;

    //}
}