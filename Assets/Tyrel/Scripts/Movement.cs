using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //For Animator
    [HideInInspector] public bool Grounded;
    [HideInInspector] public bool Jumping;
    [HideInInspector] public float VerticalVelocity;
    [HideInInspector] public float HorizontalVelocity;

    public float Speed = 8;
    public float JumpSpeed = 15f;

    public bool _dash;
    public float _dashSpeed = 100;
    public float _dashCount = 1;
    public float _jumpCount = 1;

    CapsuleCollider2D _capsule;
    Rigidbody2D _rb;
    LayerMask _collisionLayers = ~(1 << 8);

    const float _groundCheckDist = 0.1f;
    const float _groundCheckSizeMulti = 0.9f;

    void Start()
    {
        _dashCount = 1;
        _capsule = GetComponent<CapsuleCollider2D>();
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
        if(_dashCount > 0)
        {
            _dash = true;
        }

    }
    public void Move(float input)
    {
        HorizontalVelocity = input * Speed;
    }
    void FixedUpdate()
    {
        Grounded = CheckGrounded();

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

        if (_dash)
        {
            HorizontalVelocity = transform.localScale.x * _dashSpeed;
            _dashCount = 0;
            //Debug.Log(HorizontalVelocity);
            StartCoroutine(Dashing());
        }


        if (Grounded)
        {
            _jumpCount = 1;
        }

        _rb.velocity = new Vector2(HorizontalVelocity, VerticalVelocity);
    }

    IEnumerator Dashing()
    {
        yield return new WaitForSeconds(.2f);
        _dash = false;
        _dashCount = 1;
    }

    bool CheckGrounded()
    {
        Vector2 pos = (Vector2)transform.position + _capsule.offset;
        Vector2 direction = new Vector2(0, -_groundCheckDist);
        Vector2 size = _capsule.size * _groundCheckSizeMulti;
        RaycastHit2D hit = Physics2D.CapsuleCast(pos, size, _capsule.direction, 0, direction, direction.magnitude, _collisionLayers);
        return hit.collider != null;
    }
}