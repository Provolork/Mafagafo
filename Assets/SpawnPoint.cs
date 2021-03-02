using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject Monster;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(Monster, transform.position, transform.rotation);
    }
}
