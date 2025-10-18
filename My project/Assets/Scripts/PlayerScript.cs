using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    [SerializeField] private float speed = 50.0f;
    [SerializeField] private float dash_distance = 0.5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void OnMove(InputValue value)
    {
        // Read value from control. The type depends on what type of controls.
        // the action is bound to.
        _rigidbody.velocity = value.Get<Vector2>() * speed;
    }

    public void OnDash()
    {
        if (_rigidbody.velocity == Vector2.zero)
        {
            _rigidbody.position += Vector2.up * dash_distance;
        }
        else
        {
            _rigidbody.position += _rigidbody.velocity.normalized * dash_distance;
        }

    }
    
    
    
}
