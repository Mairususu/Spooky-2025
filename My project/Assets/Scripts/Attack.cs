using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 10f;
    public Origin attackFrom;
    public enum Origin{
        Player ,Enemy
    }

    private void Awake()
    {
        Destroy(this.gameObject, 0.1f);
    }
    public void Initialize(Origin from,float damage)
    {
        attackFrom=from;
        this.damage=damage;
    }
}