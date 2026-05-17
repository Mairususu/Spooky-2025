using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    
        
    [SerializeField] private List<Vector3> SpawnPoints;
    [SerializeField] private List<GameObject>  Enemies;
    [SerializeField] private List<GameObject> EnemyCorpses;
    [SerializeField] private GameObject EnemyContainer;
    [SerializeField] private List<GameObject> AliveEnemies;
    [SerializeField] private GameObject Player;
    public static  Spawner Instance;
    private int roundNumber=0;
    private bool isSpawning = false;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SpawnPoints = new List<Vector3>();
        SpawnPoints.Add(Vector3.up);
        SpawnPoints.Add(new Vector3(-11,6,0));
        SpawnPoints.Add(new Vector3(10,3,0));
        SpawnPoints.Add(new Vector3(-8,4,0));
        StartCoroutine(SpawnNextCorr());
    }

    // Update is called once per frame
    void Update()
    {
        if (roundNumber < Enemies.Count)
        {
            if (AliveEnemies.Count == 0 && !isSpawning)
            {
                
                Debug.Log("No enemies");
                roundNumber++;
                StartCoroutine(SpawnNextCorr());
            }
        }
    }
        

    IEnumerator SpawnNextCorr()
    {
        isSpawning = true;
        yield return new WaitForSeconds(5f);
        SpawnNext();
        
        yield return new WaitForSeconds(5f);
        isSpawning = false;
    }

    private void SpawnNext()
    {
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            AliveEnemies.Add( Instantiate(Enemies[roundNumber],SpawnPoints[i],Quaternion.identity)); 
            AliveEnemies[i].GetComponent<EnemyScript>().SetPlayer(Player);
        }
    }

    public void RemoveList(GameObject obj)
    {
        AliveEnemies.Remove(obj);
        if (Random.Range(0, 100) <= 10)
        {
            Instantiate(EnemyCorpses[roundNumber],obj.transform.parent.position,Quaternion.identity,obj.transform.parent);
        }
    }
}
