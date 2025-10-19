using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Vector3 pos;
    public float damage = 10f;
    public float duration;
    public Origin attackFrom;
    public enum Origin{
        Player ,Enemy
    }

    private void Awake()
    {
        
        Destroy(gameObject, duration*10f);
        transform.GetComponent<Rigidbody2D>().velocity = pos;
    }
    public void Initialize(Origin from,float damage, float duration,Vector3 position)
    {
        attackFrom=from;
        this.damage=damage;
        this.duration = duration;
        this.pos = position;
    }
}