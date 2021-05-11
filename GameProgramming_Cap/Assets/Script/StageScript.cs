using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour
{
    public float spawnTime = 5.0f;
    public float spawnCount = 10;

    public GameObject prefab;
    public Transform bugRoot;

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Instantiate(prefab, bugRoot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
