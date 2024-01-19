using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRandomizor : MonoBehaviour
{
    [SerializeField] List<GameObject> propSpawnPoints;
    [SerializeField] List<GameObject> propPrefabs;

    void Start()
    {
        SpawnProps();
    }
    
    private void SpawnProps()
    {
        foreach (GameObject point in propSpawnPoints)
        {
            int random = Random.Range(0, propPrefabs.Count);
            GameObject go = Instantiate(propPrefabs[random], point.transform.position, Quaternion.identity);
            go.transform.parent = point.transform;
        }
    }
}
