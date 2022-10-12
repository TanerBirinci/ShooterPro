using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUP : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    private Player _player;
    [SerializeField] private int powerUpID;
    [SerializeField]
    private AudioClip _clip;
    
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    
    void Update()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        if (transform.position.y<=-5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            AudioSource.PlayClipAtPoint(_clip,transform.position);
            switch (powerUpID)
            {
                case 0:
                    _player.TripleShotActive();
                    
                    break;
                case 1:
                    _player.SpeedPowerActive();
                    break;
                case 2:
                    _player.ShieldPowerActive();
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
