using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float lifepoint = 50f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject Player;

    [SerializeField] private EnemyType type;


    public enum EnemyType
    {
        Yeux, Slenderman, Araignée ,Tentacule, Cerveau 
    }
    // Start is called before the first frame update
    void Awake()
    {
        Player=PlayerScript.Instance.gameObject ;
    }

    // Update is called once per frame
    void Update()
    {
        GoToPlayer();
    }

    private void GoToPlayer()
    {
        
    }
    void OnTriggerEnter2D ( Collider2D other)
    {
        if (!other.gameObject.CompareTag("PlayerAttack")) return;
        TakeDamage(other.gameObject.GetComponent<Attack>().damage);
    }

    public void TakeDamage(float damage)
    {
        lifepoint-=damage;
        if(lifepoint<=0) Destroy(gameObject);
    }
}
