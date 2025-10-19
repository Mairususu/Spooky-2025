using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float lifepoint = 50f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Attackprefab;
    [SerializeField] public float damage;

    [SerializeField] private EnemyType type;


    public enum EnemyType
    {
        Distance,melee
    }
    
    
    // Start is called before the first frame update
    public void SetPlayer(GameObject player)
    {
        Player = player;
    }
    public IEnumerator AttackCor()
    {
        yield return new WaitForSeconds(1f);
    }
    // Update is called once per frame
    void Update()
    {
        GoToPlayer();
    }

    private void GoToPlayer()
    {
        float distance =Vector2.Distance(Player.transform.position, transform.position);
        Vector2 direction = Player.transform.position - transform.position;
        
        transform.position =Vector2.MoveTowards(this.transform.position,Player.transform.position,speed*Time.deltaTime);
        
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
