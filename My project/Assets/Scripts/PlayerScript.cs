using System;
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
    private Vector2 lastLookDir;
    [SerializeField] public static PlayerScript Instance;
    [SerializeField] private GameObject AttackPrefab;
	[SerializeField] bool gamepad = true;
	private Vector2 rightJoystick;
    [SerializeField] private float lifepoint;
    [SerializeField] private DeathMenu deathMenu; 

    private void Awake()
    {
        if (Instance != null && Instance.gameObject != null)
            Destroy(Instance.gameObject);
        Instance = this;
        
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnLook(InputValue value){
        Vector2 val = value.Get<Vector2>();
		rightJoystick = val;
        if (val.magnitude >= 0.5) lastLookDir = val;
	}
 
    private void OnMove(InputValue value)
    {
        Vector2 val = value.Get<Vector2>();
        _rigidbody.velocity = val * speed;
        if (val.magnitude >= 0.2) lastPosition = val;
    }

    private void OnPrimarySkill()
    {
        Vector2 attackDir;
		if(gamepad){
			attackDir = (rightJoystick == Vector2.zero) ? lastLookDir : rightJoystick;	
        	Instantiate(AttackPrefab, (transform.position+(new Vector3(attackDir.x,attackDir.y)).normalized), 
			Quaternion.identity).GetComponent<Attack>().Initialize(Attack.Origin.Player,10,Vector3.zero);
		}else{
			Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			attackDir = mouse - transform.position;
        	Instantiate(AttackPrefab, (transform.position+(new Vector3(attackDir.x,attackDir.y)).normalized), 
			Quaternion.identity).GetComponent<Attack>().Initialize(Attack.Origin.Player,10,Vector3.zero);
		}
    }

    private void OnSecondarySkill()
    {
        
    }
    
    private void OnUtilitySkill()
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
    
    private void OnSpecialSkill()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collision.gameObject.GetComponent<EnemyScript>().damage);
        }

        if (collision.gameObject.CompareTag("Attack"))
        {
            if(collision.GetComponent<Attack>().attackFrom!=Attack.Origin.Player) TakeDamage(collision.gameObject.GetComponent<Attack>().damage);
        }
        
    }

    private void TakeDamage(float damage)
    {
        lifepoint-=damage;
        if (lifepoint == 0)
        {
            deathMenu.TheEnd();
        }
    }
}
