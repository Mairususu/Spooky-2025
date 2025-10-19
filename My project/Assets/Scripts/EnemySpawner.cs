using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using System;


public class EnemySpawner {
    
    [SerializeField] private List<GameObject> SpawnPoints;
    [SerializeField] private List<EnemyScript>  Enemies;
    [SerializeField] private GameObject EnemyContainer;
    private float roundNumber;

    void Awake()
    {
        
    }

    private void spawnNext()
    {
        //for (int i=0;i<5;i++) Instantiate(Enemies[roundNumber],EnemyContainer);
        roundNumber++;
    }
    
    
    
}
