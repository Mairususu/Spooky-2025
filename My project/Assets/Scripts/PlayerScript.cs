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
    [SerializeField] private GameObject AttackPrefab;

    private void Awake()
    {
        if (Instance != null && Instance.gameObject != null)
            Destroy(Instance.gameObject);
        Instance = this;
        
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void OnMove(InputValue value)
    {
        Vector2 val = value.Get<Vector2>();
        _rigidbody.velocity = val * speed;
        if (val.magnitude >= 0.2) lastPosition = val;
    }

    private void OnDash()
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

    private void OnPrimarySkill()
    {
        
        Instantiate(AttackPrefab, (transform.position+(new Vector3(_rigidbody.velocity.x,_rigidbody.velocity.y)).normalized), Quaternion.identity).GetComponent<Attack>().Initialize(Attack.Origin.Player,10,0.1f);
    }

    private void OnSecondarySkill()
    {
        
    }
    
    private void OnUtilitySkill()
    {
        
    }
    
    private void OnSpecialSkill()
    {
        
    }
}
