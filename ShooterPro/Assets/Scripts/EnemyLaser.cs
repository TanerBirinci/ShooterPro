using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    private int speedLaser =6;

    private Player _player;
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    
    void Update()
    {
        transform.Translate(Vector3.down*speedLaser*Time.deltaTime);
        if (transform.position.y<=-5)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            _player.Damage();
            Destroy(this.gameObject);
        }
    }
}
