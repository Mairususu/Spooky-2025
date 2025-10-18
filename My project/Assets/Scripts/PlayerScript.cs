using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float dashDistance = 2.0f;
    [SerializeField] private float dashCooldown = 0.5f;
    private float cooldownStart = 0.0f;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void OnMove(InputValue value)
    {
        _rigidbody.velocity = value.Get<Vector2>() * speed;
    }

    public void OnDash()
    {
        if (Time.time - cooldownStart >= dashCooldown)
        {
            cooldownStart = Time.time;
            if (_rigidbody.velocity == Vector2.zero)
            {
                _rigidbody.position += Vector2.up * dashDistance;
            }else
            {
                _rigidbody.position += _rigidbody.velocity.normalized * dashDistance;
            }
        }
        

    }
    
    
    
}
