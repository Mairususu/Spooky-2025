using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Vector3 pos;
    public float damage = 10f;
    public Origin attackFrom;
    public enum Origin{
        Player ,EnemyProj, EnemyRanged
    }
    
    public void Initialize(Origin from,float damage,Vector3 position)
    {
        attackFrom=from;
        this.damage=damage;
        pos = position;
        if (attackFrom==Origin.Player) Destroy(gameObject, .1f);
        else if (attackFrom==Origin.EnemyProj) Destroy(gameObject,5f);
        else Destroy(gameObject,.3f);
        transform.GetComponent<Rigidbody2D>().velocity = pos.normalized*2;
    }
}