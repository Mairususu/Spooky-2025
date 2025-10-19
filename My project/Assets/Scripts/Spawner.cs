using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
        
    [SerializeField] private List<GameObject> SpawnPoints;
    [SerializeField] private List<GameObject>  Enemies;
    [SerializeField] private GameObject EnemyContainer;
    [SerializeField] private List<GameObject> AliveEnemies;
    [SerializeField] private GameObject Player;
    private int roundNumber=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AliveEnemies.Count==0) SpawnNext();
    }

    private void SpawnNext()
    {
        for(int i = 0; i < SpawnPoints.Count; i++) AliveEnemies.Add( Instantiate(Enemies[roundNumber],SpawnPoints[i].transform.position,Quaternion.identity));
        roundNumber++;
    }
}
