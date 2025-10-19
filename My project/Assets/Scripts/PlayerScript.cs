using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    [SerializeField] private float speed = 4.0f;
    
    [SerializeField] private float dashDistance = 2.0f;
    [SerializeField] private float dashCooldown = 0.5f;
    private float cooldownStart = 0.0f;
    private Vector2 lastPosition;
    private Vector2 lastLookDir;
    [SerializeField] bool gamepad = true;
    private Vector2 rightJoystick;
    [Header("Attack Prefab")]
    [SerializeField] private GameObject currentAttackPrefab;
    [SerializeField] private GameObject AttackPrefab;
    [SerializeField] private GameObject ChtuluAttackPrefab;
    [SerializeField] private GameObject ProjectilePrefab; 
    [SerializeField] private float lifepoint;
    [SerializeField] private DeathMenu deathMenu; 
    [SerializeField] private UIPersoManager uIPersoManager;

    private void Awake()
    {
        currentAttackPrefab = AttackPrefab;
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
        	Instantiate(currentAttackPrefab, (transform.position+(new Vector3(attackDir.x,attackDir.y)).normalized), 
			Quaternion.identity).GetComponent<Attack>().Initialize(Attack.Origin.Player,10,Vector3.zero);
		}else{
			Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			attackDir = mouse - transform.position;
        	Instantiate(currentAttackPrefab, (transform.position+(new Vector3(attackDir.x,attackDir.y)).normalized), 
			Quaternion.identity).GetComponent<Attack>().Initialize(Attack.Origin.Player,10,Vector3.zero);
		}
    }

    private void OnSecondarySkill()
    {
        Vector2 attackDir;
        if(gamepad){
            attackDir = (rightJoystick == Vector2.zero) ? lastLookDir : rightJoystick;	
            Instantiate(AttackPrefab, (transform.position+(new Vector3(attackDir.x,attackDir.y)).normalized), 
                Quaternion.identity).GetComponent<Attack>().Initialize(Attack.Origin.Player,10,Vector3.zero);
        }
        else
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            attackDir = mouse - transform.position;
            Instantiate(AttackPrefab, (transform.position + (new Vector3(attackDir.x, attackDir.y)).normalized),
                Quaternion.identity).GetComponent<Attack>().Initialize(Attack.Origin.Player, 10, Vector3.zero);
        }
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
            if(collision.GetComponent<Attack>().attackFrom==Attack.Origin.Enemy) TakeDamage(collision.gameObject.GetComponent<Attack>().damage);
        }

        if (collision.gameObject.CompareTag("SpiderCorpse"))
        {
            uIPersoManager.UpgradeLeg();
        }
        
        if (collision.gameObject.CompareTag("EyesCorpse"))
        {
            uIPersoManager.UpgradeTete();
        }
       
        if (collision.gameObject.CompareTag("ChtulhuCorpse"))
        {
            uIPersoManager.UpgradeBody();
        }
       
        if (collision.gameObject.CompareTag("SlendermanCorpse"))
        {
            uIPersoManager.UpgradeBody();
        }
        
    }
    #region Evolution

    public void ChangeSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }
    #endregion
    private void TakeDamage(float damage)
    {
        lifepoint-=damage;
        if (lifepoint == 0)
        {
            deathMenu.TheEnd();
        }
    }
}
