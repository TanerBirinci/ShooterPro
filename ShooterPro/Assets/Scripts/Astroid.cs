using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{

    [SerializeField] private GameObject explosionPrefab,astroid;

    
    private SpawnManager _spawnManager;
    void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward*19*Time.deltaTime);
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.tag=="Laser")
        {
            
            Instantiate(explosionPrefab, astroid.transform.position, Quaternion.identity);
            
            _spawnManager.StartSpawning();
            
            Destroy(other.gameObject);
            Destroy(this.gameObject,0.2f);
        }
    }

    
        
    
    
    
    
}
