using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner {
    
    [SerializeField] private List<GameObject> SpawnPoints;
    [SerializeField] private List<EnemyScript>  Enemies;
    [SerializeField] private GameObject EnemyContainer;
    [SerializeField] private List<GameObject> AliveEnemies;
    private float roundNumber;

    void Awake()
    {
        
    }

    private void SpawnNext()
    {
        for (int i = 0; i < 5; i++)
        { 
            //Instantiate(AttackPrefab, (transform.position+(new Vector3(attackDir.x,attackDir.y)).normalized),Quaternion.identity).GetComponent<Attack>().Initialize(Attack.Origin.Player,10,Vector3.zero);
            
            //Instantiate(Enemies[roundNumber],EnemyContainer);
        }
        roundNumber++;
    }

    
    
    
}
