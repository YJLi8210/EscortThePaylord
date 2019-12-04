using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject Items;
    public float spawntime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawning", spawntime, spawntime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawning()
    {
        int spawnindex = Random.Range(0, SpawnPoints.Length);
        Instantiate(Items, SpawnPoints[spawnindex].position, SpawnPoints[spawnindex].rotation);
    }
}
