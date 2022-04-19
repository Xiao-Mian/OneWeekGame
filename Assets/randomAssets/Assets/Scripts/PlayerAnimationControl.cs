using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimationControl : MonoBehaviour
{
    Movement _movement;
    Animator _anim;
    void Start()
    {
        _movement = GetComponent<Movement>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        bool run = _movement.Grounded && _movement.HorizontalVelocity != 0;
        _anim.SetBool("Running", run);

        if (_movement.HorizontalVelocity > 0)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else if (_movement.HorizontalVelocity < 0)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
 
        _anim.SetBool("Grounded", _movement.Grounded);

        float time = 1-(_movement.VerticalVelocity+12)/24;
        time = Mathf.Clamp(time, 0, 1);

        if (!_movement.Grounded)
            _anim.Play("Jump",0, time);
    }
}