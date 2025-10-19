/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float dashSpeed = 25.0f;
    [SerializeField] private float dashDuration = 0.5f;
    [SerializeField] private float dashCooldown = 1.0f;
    private float cooldownStart = 0.0f;
    private Vector2 lastPosition;
    private Vector2 lastLookDir;
    [SerializeField] public static PlayerScript Instance;
    [SerializeField] private GameObject AttackPrefab;
	[SerializeField] bool gamepad = true;
	private Vector2 rightJoystick;

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
	    if (cooldownStart == 0.0f || (Time.time - cooldownStart >= dashDuration))
	    {
		    _rigidbody.velocity = val * speed * Time.deltaTime * 50.0f;
	    }
	    else
	    {
		    Debug.Log(val);
		    _rigidbody.velocity = val * dashSpeed * Time.deltaTime * 50.0f;
	    }
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
	        Debug.Log("dashing");
            cooldownStart = Time.time;
        }
    }
    
    private void OnSpecialSkill()
    {
        
    }
}

*/
