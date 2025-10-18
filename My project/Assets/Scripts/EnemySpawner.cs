using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System;


public class EnemySpawner {
    
    [SerializeField] private List<GameObject> SpawnPoints;
    [SerializeField] private List<EnemyScript>  Enemies;
    private float roundNumber;

    void Awake()
    {
        
    }

    private void spawnNext()
    {
        //Instantiate(Enemies[roundNumber],EnemyContainer);
        roundNumber++;
    }
    
    
    
}
