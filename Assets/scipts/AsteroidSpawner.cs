using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{

    public float timToSpawn;
    public GameObject[] prefabs;
    public Transform[] spawners;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
             Instantiate
             (
                 prefabs[Random.Range (0, prefabs.Length)],
                 spawners[Random.Range (0, spawners.Length)].position,
                 Quaternion.identity
             );

             yield return new WaitForSeconds(timToSpawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
