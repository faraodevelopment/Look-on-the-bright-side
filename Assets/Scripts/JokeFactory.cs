using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokeFactory : MonoBehaviour
{
    [SerializeField]
    List<GameObject> jokePrefabs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnJokeTriggers", Random.Range(0, 3f), Random.Range(0, 4f));
    }

    void SpawnJokeTriggers()
    {
        //Debug.Log("triggering a joke");
        Instantiate(jokePrefabs[Random.Range(0, jokePrefabs.Count)],new Vector3(Random.Range(900,1000), 540.5f, Random.Range(0,90)),Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
