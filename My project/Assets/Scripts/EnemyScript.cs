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
    [SerializeField] private bool First=true;
    [SerializeField] private float cooldown=0;

    public enum EnemyType
    {
        Distance,Melee
    }
    
    
    // Start is called before the first frame update
    public void SetPlayer(GameObject player)
    {
        Player = player;
        Debug.Log("Done");
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
        Vector3 direction = Player.transform.position - transform.position;
        
        transform.position =Vector2.MoveTowards(this.transform.position,Player.transform.position,speed*Time.deltaTime);
        if (type == EnemyType.Distance)
        {
            if (distance <= 6 && (Time.time- cooldown>1f))
            {
                Debug.Log(distance);
                Instantiate(Attackprefab, transform.position+direction.normalized, Quaternion.identity).GetComponent<Attack>().Initialize(Attack.Origin.Enemy,5,direction.normalized);  
                cooldown = Time.time;
            }
        }
        
    }
    void OnTriggerEnter2D ( Collider2D other)
    {
        if (!other.gameObject.CompareTag("Attack")) return;
        if(other.GetComponent<Attack>().attackFrom==Attack.Origin.Player) TakeDamage(other.gameObject.GetComponent<Attack>().damage);
    }

    public void TakeDamage(float attackDamage)
    {
        lifepoint-=attackDamage;
        if (lifepoint <= 0)
        {
            //Spawner.Instance.RemoveList(gameObject);
            Destroy(gameObject);
        }
    }
}
