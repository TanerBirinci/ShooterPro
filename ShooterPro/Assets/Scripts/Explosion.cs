using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private AudioClip astroidExplosionSound;

    private AudioSource _audioSource;

    void Start()
    {
        Destroy(this.gameObject,3f);
        _audioSource = GetComponent<AudioSource>();
        
        if (_audioSource==null)
        {
            Debug.Log("null sound");
        }
        else
        {
            _audioSource.clip = astroidExplosionSound;
        }
        _audioSource.Play();
    }

    
}
