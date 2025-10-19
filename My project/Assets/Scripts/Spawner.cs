using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
        
    [SerializeField] private List<Vector3> SpawnPoints;
    [SerializeField] private List<GameObject>  Enemies;
    [SerializeField] private GameObject EnemyContainer;
    [SerializeField] private List<GameObject> AliveEnemies;
    [SerializeField] private GameObject Player;
    public static  Spawner Instance;
    private int roundNumber=0;
    private Coroutine SpawnCorr;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        SpawnPoints = new List<Vector3>();
        SpawnPoints.Add(Vector3.zero);
        SpawnPoints.Add(new Vector3(3,0,0));
    }

    // Update is called once per frame
    void Update()
    {
        if (roundNumber < Enemies.Count)
        {
            if (AliveEnemies.Count == 0)
            {
                if (SpawnCorr==null) SpawnCorr=StartCoroutine(SpawnNextCorr());
            }
        }
        }
        

    IEnumerator SpawnNextCorr()
    {
        roundNumber++;
        yield return new WaitForSeconds(5f);
        SpawnNext();
        yield return new WaitForSeconds(5f);
        SpawnNext();
        
        roundNumber++;
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
    }
}
