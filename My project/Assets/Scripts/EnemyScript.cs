using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float lifepoint = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoToPlayer();
    }

    private void GoToPlayer()
    {
        
    }

    public void TakeDamage(float damage)
    {
        
    }
}
