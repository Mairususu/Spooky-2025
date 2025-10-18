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
    private Vector2 lastPosition;
    [SerializeField] public static PlayerScript Instance;
    

    private void Awake()
    {
        if (Instance != null && Instance.gameObject != null)
            Destroy(Instance.gameObject);
        Instance = this;
        
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    public void OnMove(InputValue value)
    {
        Vector2 val = value.Get<Vector2>();
        _rigidbody.velocity = val * speed;
        Debug.Log(val);
        if (val.magnitude >= 0.2) lastPosition = val;
    }

    public void OnDash()
    {
        if (Time.time - cooldownStart >= dashCooldown)
        {
            cooldownStart = Time.time;
            if (_rigidbody.velocity == Vector2.zero)
            {
                _rigidbody.position += lastPosition.normalized * dashDistance;
            }else
            {
                _rigidbody.position += _rigidbody.velocity.normalized * dashDistance;
            }
        }
    }
}
