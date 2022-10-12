using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    public float speedLaser = 8;
    void Update()
    {
        transform.Translate(Vector3.up*speedLaser*Time.deltaTime);
        if (transform.position.y>=8)
        {
            if (transform.parent!=null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(gameObject);
            
        }
    }

    
}
